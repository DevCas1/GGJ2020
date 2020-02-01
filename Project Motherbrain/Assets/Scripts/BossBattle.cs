using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public int BossHealth
    {
        get { return bossHealth; }
    }

    private int bossHealth = 300;

    [SerializeField]
    private Animator anim;
    private GameObject player;

    [SerializeField]
    private float fireRate = 10.0f;
    private float nextFire = -1f;

    [SerializeField]
    private Transform playerTarget;

    private bool followTarget = true;


    public void TakeDamage(int dmg)
    {
        bossHealth -= dmg;
    }

    public void Update()
    {
        if (followTarget == true)
            transform.LookAt(playerTarget);
        else
            return;

        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
            return;
        }
        else
        {

            int rand = Random.Range(1, 5);

            if (rand == 1)
            {
                LazerAttack();
            }
            if (rand == 2)
            {
                Slash();
            }
            if (rand == 3)
            {
                Hammer();
            }
            else
            {
                Rocket();
            }

            WeaponWasFired();
        }
    }

    void WeaponWasFired()
    {
        nextFire = fireRate;
    }

    public void LazerAttack()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger("Lazer");
        anim.SetTrigger("Idle");

    }
    
    public void Slash()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger("Slash");
        anim.SetTrigger("Idle");
    }

    public void Laugh()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger("PlayerDeath");
        anim.SetTrigger("Idle");
    }

    public void Hammer()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger("Hammer");
        anim.SetTrigger("Idle");
    }

    public void Rocket()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger("Rockets");
        anim.SetTrigger("Idle");
    }

    void Ondeath()
    {
        if (bossHealth <= 0)
        {
            anim.SetTrigger("Death");
        }
    }

    IEnumerator LookAtCoolDown()
    {
        followTarget = false;

        yield return new WaitForSecondsRealtime(3);

        followTarget = true;

    }
}
