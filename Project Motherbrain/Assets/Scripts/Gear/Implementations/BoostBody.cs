using UnityEngine;

public class BoostBody : BodyEquipment
{
    [SerializeField] private float BoostSpeed = 5;
    [SerializeField] private float BoostDuration = 2;

    private bool _isBoosting;
    private Vector3 _boostDirection;
    private float _boostTimer;

    private void Update()
    {
        if (!_isBoosting)
            return;

        if (_boostTimer <= 0)
        {
            PlayerGear.DetachBody(this);
            _isBoosting = false;
            return;
        }

        PlayerController.Rigidbody.MovePosition(PlayerController.transform.position + _boostDirection * (BoostSpeed * Time.deltaTime));
        _boostTimer -= Time.deltaTime;
    }

    public override void Attach(PlayerController controller, PlayerGear gear)
    {
        PlayerController = controller;
        PlayerGear = gear;
        PlayerRigidbody = controller.Rigidbody;
    }

    public override void Use()
    {
        _boostDirection = PlayerController.Visuals.forward;
        _isBoosting = true;
        _boostTimer = BoostDuration;
    }
}