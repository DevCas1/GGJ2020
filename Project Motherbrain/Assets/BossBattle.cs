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

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int dmg)
    {
        bossHealth -= dmg;
    }

    public void LazerAttack()
    {
        anim.SetTrigger("Lazer");
    }
    
    public void Swing()
    {
        anim.SetTrigger("Swing");
    }

    public void Rocket()
    {
        anim.SetTrigger("Rockets");
    }

    public void Hammer()
    {
        anim.SetTrigger("Hammer");
    }

    void Ondeath()
    {
        if (bossHealth <= 0)
        {
            anim.SetTrigger("Death");
        }
    }
}
