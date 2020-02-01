using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public PlayerInput Input { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Transform Visuals => VisualTransform;

    [SerializeField, Header("References ~ REQUIRED")] private Transform VisualTransform;

    [SerializeField, Space(10)] private float MovementSpeed = 10;
    [SerializeField] private float RotationSpeed = 5;

    [SerializeField, Header("Jumping")] private float JumpVelocity = 5;
    [SerializeField] private float FallMultiplier = 2.5f;
    [SerializeField, Range(0.1f, 1)] private float GravityMultiplier = 1;
    [SerializeField, InspectorName("Jump Landing Check Distance")] private float JumpLandCheckDist;
    [SerializeField, Range(0.1f, 1), InspectorName("Jump Landing Check Radius")] private float JumpLandCheckRad;

    private Vector2 _movementInput;
    private bool _movementActive = true;

    private Vector3 _moveVector;
    private Vector2 _movement;

    private bool _isJumping;
    private float _jumpVelocity;
    private readonly Collider[] _jumpHitAlloc = new Collider[10];

    void Awake()
    {
        InitializeInput();
    }

    private void OnEnable() => Input.Gameplay.Enable();

    private void OnDisable() => Input.Gameplay.Disable();

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _movementActive = true;
    }

    private void Update()
    {
        RotateVisuals();

        if (_isJumping)
            UpdateJump();
    }

    private void FixedUpdate() => MovePlayer();

    private void RotateVisuals()
    {
        Vector3 lookVector = transform.TransformDirection(new Vector3(_movementInput.x, 0, _movementInput.y));

        if (Mathf.Abs(lookVector.sqrMagnitude - Vector3.zero.sqrMagnitude) <= 0.1f)
            return;

        VisualTransform.rotation = Quaternion.Slerp(VisualTransform.rotation, Quaternion.LookRotation(lookVector, Vector3.up), 1 - Mathf.Exp(-RotationSpeed * Time.deltaTime));
    }

    private void MovePlayer()
    {
        Vector3 inputMovement = (Mathf.Abs(_movementInput.sqrMagnitude - Vector3.zero.sqrMagnitude) > 0.1f) ? VisualTransform.forward : Vector3.zero;

        //if (Mathf.Abs(_movementInput.sqrMagnitude - Vector3.zero.sqrMagnitude) <= 0.1f)
        //    return;

        Vector3 velocity = _movementActive ? transform.position + inputMovement * (MovementSpeed * Time.deltaTime) : Vector3.zero;

        Rigidbody.MovePosition(velocity + new Vector3(0, _jumpVelocity, 0));
    }

    private void UpdateJump()
    {
        if (Rigidbody.velocity.y < 0)
            _jumpVelocity += GravityMultiplier * Physics.gravity.y * FallMultiplier * Time.deltaTime;
    }

    private void ResetJump()
    {
        _isJumping = false;
        _jumpVelocity = 0;
    }

    public void Jump()
    {
        if (_isJumping)
            return;

        _isJumping = true;
        _jumpVelocity = JumpVelocity;
    }

    public void Boost()
    {
        _movementActive = false;
    }

    public void ExitBoost()
    {
        _movementActive = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_isJumping)
            return;

        Vector3 position = transform.position;

        int hitCount = Physics.OverlapCapsuleNonAlloc(position + Vector3.down, position + new Vector3(0, -JumpLandCheckDist, 0),
            JumpLandCheckRad, _jumpHitAlloc);

        if (hitCount < 1)
            return;

        for (int index = 0; index < hitCount; index++)
            if (_jumpHitAlloc[index].transform.root.name != gameObject.name)
                ResetJump();
    }

    private void InitializeInput()
    {
        Input = new PlayerInput();

        Input.Gameplay.Movement.performed += context =>
        {
            _movementInput = context.ReadValue<Vector2>();
            //_activeMoveInput = true;
        };

        Input.Gameplay.Movement.canceled += context =>
        {
            _movementInput = context.ReadValue<Vector2>();
            //_activeMoveInput = false;
        };
    }
}
