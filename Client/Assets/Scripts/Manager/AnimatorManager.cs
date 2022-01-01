using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public void PlayTargetAnimation(string targetAnim, bool isInteracting)
    {
       // anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);
    }

    public void EnemyPlayTargetAnimation(string targetAnim, bool isInteracting)
    {
        //anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.4f);
    }

    public void PlayTargetAnimationWithRootRotation(string targetAnim, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isRotatingWithRootMotion", true);
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);
    }
    public virtual void TakeCriticalDamageAnimationEvent()
    {

    }
}
