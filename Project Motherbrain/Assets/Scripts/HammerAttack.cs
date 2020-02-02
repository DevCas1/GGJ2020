using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    public BossBattle boss;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            boss.TakeDamage(20);
        }
    }
}
