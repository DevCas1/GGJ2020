using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("References ~ REQUIRED")]
    private Transform VisualTransform;

    [SerializeField, Space(10)] 
    private float MovementSpeed = 10;
    [SerializeField]
    private float RotationSpeed = 5;

    private Rigidbody _rb;
    private PlayerInput _input;
    private Vector2 _movementInput;
    private bool _activeMoveInput;
    private bool _jumpInput;

    private Vector2 _movement;

    private bool _isJumping;

    void Awake()
    {
        InitializeInput();
    }

    private void OnEnable() =>_input.Gameplay.Enable();

    private void OnDisable() => _input.Gameplay.Disable();

    private void Start() => _rb = GetComponent<Rigidbody>();

    private void Update()
    {
        _jumpInput = _input.Gameplay.Jump.ReadValue<bool>();

        RotateVisuals();
        //MovePlayer();
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
        if (Mathf.Abs(_movementInput.sqrMagnitude - Vector3.zero.sqrMagnitude) <= 0.1f)
            return;

        _rb.MovePosition(transform.position + VisualTransform.forward * (MovementSpeed * Time.deltaTime));
    }

    private void InitializeInput()
    {
        _input = new PlayerInput();

        _input.Gameplay.Movement.performed += context =>
        {
            _movementInput = context.ReadValue<Vector2>();
            _activeMoveInput = true;
        };

        _input.Gameplay.Movement.canceled += context =>
        {
            _movementInput = context.ReadValue<Vector2>();
            _activeMoveInput = false;
        };
    }
}
