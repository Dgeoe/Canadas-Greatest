using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAttackTriggerScript : MonoBehaviour
{
    public ImpAnimationScript impAnimationScript;
    public bool fireballActive;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !fireballActive)
        {
            impAnimationScript.AttackAnim();
            fireballActive = true;
        }
    }
}
