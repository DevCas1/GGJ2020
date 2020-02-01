using UnityEngine;

public abstract class Equipment : MonoBehaviour, IEquipable
{
    protected PlayerController PlayerController;
    protected PlayerGear PlayerGear;
    protected Rigidbody PlayerRigidbody;

    public abstract void Attach(PlayerController controller, PlayerGear gear);
    public abstract void Use();
}