using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAnimationScript : MonoBehaviour
{
    public Animator impAnimator;
    public Animator fireballAnimator;
    public void IdleAnim()
    {
        impAnimator.SetTrigger("idle");
    }
    public void WalkAnim()
    {
        impAnimator.SetTrigger("walk");
    }
    public void AttackAnim()
    {
        impAnimator.SetTrigger("attack");
    }
    public void DeathAnim()
    {
        impAnimator.SetTrigger("death");
    }
    public void ExplodeFireball()
    {
        fireballAnimator.SetTrigger("explode");
    }
}
