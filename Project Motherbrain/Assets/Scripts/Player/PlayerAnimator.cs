using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator PlayerAnim;

    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsShielding = Animator.StringToHash("isShielding");
    private static readonly int IsUsingMagnet = Animator.StringToHash("isUsingMagnet");

    private static readonly int IsDying = Animator.StringToHash("isDying");
    private static readonly int GotHit = Animator.StringToHash("gotHit");

    private void Start()
    {
        //PlayerAnim = GetComponent<Animator>();
        Idle();
    }

    public void Idle() 
    {
        PlayerAnim.SetBool(IsJumping, false);
        PlayerAnim.SetBool(IsWalking, false);
        PlayerAnim.SetBool(IsUsingMagnet, false);
    }

    public void Jump(bool state) => PlayerAnim.SetBool(IsJumping, state);

    public void Walk(bool state) => PlayerAnim.SetBool(IsWalking, state);

    public void Shield(bool state) => PlayerAnim.SetBool(IsShielding, state);

    public void UseMagnet(bool state) => PlayerAnim.SetBool(IsUsingMagnet, state);

    public void GetHit() => PlayerAnim.SetTrigger(GotHit);

    public void Die()
    {
        PlayerAnim.SetTrigger(IsDying);
    }
}