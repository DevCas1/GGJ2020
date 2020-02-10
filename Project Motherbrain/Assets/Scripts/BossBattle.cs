using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossBattle : MonoBehaviour
{
    public float BossHealth
    {
        get => bossHealth;

        private set
        {
            bossHealth = value;
            UpdateHealthBar();

            if (bossHealth <= 0)
                Ondeath();
        }
    }

    [SerializeField]
    private float bossHealth = 100;

    [SerializeField]
    public Image bossHpImage;
    [SerializeField]
    private Animator anim;

    private PlayerController player;

    [SerializeField]
    private float actionCooldown = 10.0f;
    private float actionCooldownTimer = -1f;

    [SerializeField]
    private Transform playerTarget;
    [SerializeField]
    private float FollowSpeed = 10;

    private bool isDead;
    public GameObject Laser;

    private bool followTarget = true;

    private static readonly int Rockets = Animator.StringToHash("Rockets");
    private static readonly int Hammer = Animator.StringToHash("Hammer");
    private static readonly int PlayerDeath = Animator.StringToHash("PlayerDeath");
    private static readonly int Slash = Animator.StringToHash("Slash");
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private static readonly int Lazer = Animator.StringToHash("Lazer");

    public void TakeDamage(int dmg)
    {
        bossHealth -= dmg;
    }

    public void Update()
    {
        if (isDead)
            return;

        if (followTarget)
            transform.LookAt(playerTarget);

        if (actionCooldownTimer > 0)
        {
            actionCooldownTimer -= Time.deltaTime;
            return;
        }

        int random = Random.Range(1, 5);

        switch (random)
        {
            case 1:
                LazerAttack();
                break;
            case 2:
                SlashAttack();
                break;
            case 3:
                HammerAttack();
                break;
            case 4:
                RocketAttack();
                break;
            default:
                Laugh();
                break;
        }

        Debug.Log(random);
        OnActionPerformed();
    }

    private void OnActionPerformed()
    {
        actionCooldownTimer = actionCooldown;
    }

    public void LazerAttack()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger(Lazer);
        StartCoroutine(LaserFired());

    }

    public void SlashAttack()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger(Slash);
    }

    public void Laugh()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger(PlayerDeath);
    }

    public void HammerAttack()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger(Hammer);
    }

    public void RocketAttack()
    {
        StartCoroutine(LookAtCoolDown());
        anim.SetTrigger(Rockets);
    }

    private void Ondeath()
    {
        if (!(bossHealth <= 0))
            return;

        anim.SetBool(IsDead, true);
        isDead = true;
    }

    private IEnumerator LookAtCoolDown()
    {
        followTarget = false;

        yield return new WaitForSecondsRealtime(3);

        followTarget = true;

    }

    public void UpdateHealthBar() => bossHpImage.fillAmount = BossHealth / 100f;

    IEnumerator LaserFired()
    {
        yield return new WaitForSecondsRealtime(0.8f);

        Laser.SetActive(true);

        yield return new WaitForSecondsRealtime(1.5f);

        Laser.SetActive(false);
    }
}
