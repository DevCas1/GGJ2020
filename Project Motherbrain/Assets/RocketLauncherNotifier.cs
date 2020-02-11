using UnityEngine;

public class RocketLauncherNotifier : StateMachineBehaviour
{
    public RocketLauncher Launcher;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Launcher == null)
            Launcher = FindObjectOfType<RocketLauncher>();

        Launcher.Launch();
    }
}