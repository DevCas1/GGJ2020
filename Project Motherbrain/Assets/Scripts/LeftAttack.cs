using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttack : MonoBehaviour
{
    [SerializeField]
    private BossBattle boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            boss.Hammer();
        }
    }
}
