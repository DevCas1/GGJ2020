using UnityEngine;

public class JumpBoots : LegsEquipment
{
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
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
        PlayerGear.DetachLegs(this);

        // Recycle this powerup
    }
}