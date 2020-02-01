using DG.Tweening;
using UnityEngine;

public class BoostBody : BodyEquipment
{
    [SerializeField] private float BoostDistance = 3;
    [SerializeField] private float BoostDuration = 2;

    private Collider _collider;

    private bool _isBoosting;
    private Vector3 _boostDirection;
    private float _boostTimer;

    private void Start() => _collider = GetComponent<Collider>();

    private void Finish()
    {
        PlayerController.ExitBoost();
        PlayerGear.DetachBody(this);
        _isBoosting = false;
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
        _isBoosting = true;
        _boostTimer = BoostDuration;
        PlayerController.Boost();
        PlayerRigidbody.DOMove(PlayerController.Visuals.forward * BoostDistance, BoostDuration).OnComplete(Finish);
    }
}