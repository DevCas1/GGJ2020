using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("References ~ REQUIRED")]
    private Transform VisualTransform;

    [SerializeField, Space(10)] 
    private float MovementSpeed = 10;
    [SerializeField]
    private float RotationSpeed = 5;

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

    void Update()
    {
        _jumpInput = _input.Gameplay.Jump.ReadValue<bool>();

        RotateVisuals();
    }

    private void RotateVisuals()
    {
        Vector3 lookVector = new Vector3(_movementInput.x, 0, _movementInput.y);

        if (Mathf.Abs(lookVector.sqrMagnitude - Vector3.zero.sqrMagnitude) <= 0.1f)
            return;

        VisualTransform.rotation = Quaternion.Slerp(VisualTransform.rotation, Quaternion.LookRotation(lookVector, Vector3.up), 1 - Mathf.Exp(-RotationSpeed * Time.deltaTime));
        //VisualTransform.localRotation = Quaternion.LookRotation(lookVector, Vector3.up);
        //VisualTransform.Rotate(0, 10, 0);
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
