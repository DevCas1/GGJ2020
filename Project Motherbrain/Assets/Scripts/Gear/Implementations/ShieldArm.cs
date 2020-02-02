using UnityEngine;

public class ShieldArm : ArmsEquipment
{
    private bool _isActive;

    public override void Attach(PlayerController controller, PlayerGear gear)
    {
        PlayerController = controller;
        PlayerGear = gear;
        PlayerRigidbody = controller.Rigidbody;
    }

    private void Activate()
    {
        PlayerController.Boost();
    }

    private void Deactivate()
    {
        PlayerController.ExitBoost();
    }

    public override void Use()
    {
        _isActive = !_isActive;

        if (_isActive)
            Activate();
        else
            Deactivate();
    }
}