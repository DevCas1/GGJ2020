using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(PlayerController))]
public class PlayerGear : MonoBehaviour
{
    [SerializeField] private SphereCollider PickupTrigger;

    [SerializeField, Space(10)] private Transform HeadGearTransform;
    [SerializeField] private Transform BodyGearTransform;
    [SerializeField, Header("Arms")] private Transform LeftArmGearTransform;
    [SerializeField] private Transform RightArmGearTransform;
    [SerializeField, Header("Legs")] private Transform LeftLegGearTransform;
    [SerializeField] private Transform RightLegGearTransform;

    private PlayerController _controller;

    private HeadEquipment _headEquipment;
    private BodyEquipment _bodyEquipment;
    private ArmsEquipment _armsEquipment;
    private LegsEquipment _legsEquipment;

    //private IEquipable _attachableEquipment;

    private void Reset()
    {
        PickupTrigger.isTrigger = true;

        _controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        if (_controller == null)
            _controller = GetComponent<PlayerController>();

        PickupTrigger.isTrigger = true;
    }

    private void Update()
    {
        CheckInputs();
        MoveGearTransforms();
    }

    private void CheckInputs()
    {
        //if (_controller.Input.Gameplay.Attach.ReadValue<bool>())
        //{
        //    _attachableEquipment?.Attach(_controller, this);
        //}

        if (_controller.Input.Gameplay.Head.triggered && _headEquipment != null)
        {
            _headEquipment.Use();
        }

        if (_controller.Input.Gameplay.Body.triggered && _bodyEquipment != null)
        {
            _bodyEquipment.Use();
        }

        if (_controller.Input.Gameplay.Arms.triggered && _armsEquipment != null)
        {
            _armsEquipment.Use();
        }

        if (_controller.Input.Gameplay.Legs.triggered && _legsEquipment != null)
        {
            _legsEquipment.Use();
        }
    }

    private void MoveGearTransforms()
    {
        if (_headEquipment != null)
        {
            Transform head = _headEquipment.transform;
            head.position = HeadGearTransform.position;
            head.rotation = HeadGearTransform.rotation;
        }

        if (_bodyEquipment != null)
        {
            Transform body = _bodyEquipment.transform;
            body.position = BodyGearTransform.position;
            body.rotation = BodyGearTransform.rotation;
        }

        if (_armsEquipment != null)
        {
            Transform leftArm = _armsEquipment.LeftArm.transform;
            Transform leftGearTransform = LeftArmGearTransform.transform;
            leftArm.position = leftGearTransform.position;
            leftArm.rotation = leftGearTransform.rotation;

            Transform rightArm = _armsEquipment.RightArm.transform;
            Transform rightGearTransform = RightArmGearTransform.transform;
            rightArm.position = rightGearTransform.position;
            rightArm.rotation = rightGearTransform.rotation;
        }

        if (_legsEquipment != null)
        {
            Transform leftLeg = _legsEquipment.LeftLeg.transform;
            Transform leftGearTransform = LeftLegGearTransform.transform;
            leftLeg.position = leftGearTransform.position;
            leftLeg.rotation = leftGearTransform.rotation;

            Transform rightLeg = _legsEquipment.RightLeg.transform;
            Transform rightGearTransform = RightLegGearTransform.transform;
            rightLeg.position = rightGearTransform.position;
            rightLeg.rotation = rightGearTransform.rotation;
        }
    }

    private void AttachHead(HeadEquipment head) => _headEquipment = head;

    private void AttachBody(BodyEquipment body) =>_bodyEquipment = body;

    private void AttachArms(ArmsEquipment arms) => _armsEquipment = arms;

    private void AttachLegs(LegsEquipment legs) => _legsEquipment = legs;

    public void DetachHead(HeadEquipment head)
    {
        if (head == _headEquipment)
            _headEquipment = null;
    }

    public void DetachBody(BodyEquipment body)
    {
        if (body == _bodyEquipment)
            _bodyEquipment = null;
    }

    public void DetachArms(ArmsEquipment arms)
    {
        if (arms == _armsEquipment)
            _armsEquipment = null;
    }

    public void DetachLegs(LegsEquipment legs)
    {
        if (legs == _legsEquipment)
            _legsEquipment = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(typeof(Equipment), out Component equipment))
            return;

        switch (equipment)
        {
            case HeadEquipment h:
                if (_headEquipment != null)
                    return;

                h.Attach(_controller, this);
                AttachHead(h);
                return;

            case BodyEquipment b:
                if (_bodyEquipment != null)
                    return;

                b.Attach(_controller, this);
                AttachBody(b);
                return;

            case ArmsEquipment a:
                if (_armsEquipment != null)
                    return;

                a.Attach(_controller, this);
                AttachArms(a);
                return;

            case LegsEquipment l:
                if (_legsEquipment != null)
                    return;

                l.Attach(_controller, this);
                AttachLegs(l);
                return;

            default:
                return;

            case null:
                throw new ArgumentNullException(nameof(equipment));
        }
    }
}