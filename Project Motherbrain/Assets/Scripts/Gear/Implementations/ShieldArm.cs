using System;
using UnityEngine;

public class ShieldArm : ArmsEquipment
{
    private bool _isActive;
    private Vector3 _shieldPos;
    private Vector3 _shieldRot;
    private Transform _playConTransform;
    private Transform _visuals;

    private void Update()
    {
        if (!_isActive)
            return;

        _playConTransform.position = _shieldPos;
        _visuals.rotation = Quaternion.Euler(_shieldRot);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for Lazer
    }

    public override void Attach(PlayerController controller, PlayerGear gear)
    {
        PlayerController = controller;
        PlayerGear = gear;
        PlayerRigidbody = controller.Rigidbody;
    }

    private void Activate()
    {
        _playConTransform = PlayerController.transform;
        _visuals = PlayerController.Visuals;
        _shieldPos = _playConTransform.position;
        Vector3 lookDir = _playConTransform.root.forward;

        PlayerController.Boost();

        _shieldRot = Quaternion.LookRotation(lookDir).eulerAngles;
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