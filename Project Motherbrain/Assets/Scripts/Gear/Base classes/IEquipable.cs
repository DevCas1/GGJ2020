using UnityEngine;

public interface IEquipable
{
    void Attach(PlayerController controller, PlayerGear gear);
    void Use();
}