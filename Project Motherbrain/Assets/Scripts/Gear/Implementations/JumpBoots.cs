using UnityEngine;

public class JumpBoots : LegsEquipment
{
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
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

        _collider.enabled = true;
    }
}