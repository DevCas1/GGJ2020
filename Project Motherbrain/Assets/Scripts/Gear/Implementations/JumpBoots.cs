using UnityEngine;

public class JumpBoots : LegsEquipment
{
    private Collider _collider;

    private float _detachTimer = 0.2f;
    private bool _hasJumped;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (!_hasJumped)
            return;

        if (_detachTimer > 0)
        {
            _detachTimer -= Time.deltaTime;
            return;
        }

        if (PlayerRigidbody.velocity.y < 0)
            PlayerGear.DetachLegs(this);

        // Recycle powerup
    }

    public override void Attach(PlayerController controller, PlayerGear gear)
    {
        _collider.enabled = false;
        PlayerController = controller;
        PlayerGear = gear;
        PlayerRigidbody = controller.Rigidbody;
    }

    public override void Use()
    {
        PlayerController.Jump();
        _hasJumped = true;

        //PlayerGear.DetachLegs(this);
    }
}