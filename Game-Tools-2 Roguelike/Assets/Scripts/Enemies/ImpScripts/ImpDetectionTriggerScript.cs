using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpDetectionTriggerScript : MonoBehaviour
{
    public ImpFunctionsScript impFunctionsScript;
    public ImpMovementScript impMovementScript;
    public ImpDamageTriggerScript impDamageTriggerScript;
    public ImpAnimationScript impAnimationScript;
    public FireballMovementScript fireballMovementScript;
    public FireballTriggerScript fireballTriggerScript;
    public FireballFunctionsScript fireballFunctionsScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            impFunctionsScript.StartImp();
            impMovementScript.player = collision.gameObject;
            fireballMovementScript.player = collision.gameObject;
            fireballTriggerScript.playerHealthScript = collision.gameObject.GetComponent<PlayerHealthScript>();
            impDamageTriggerScript.playerHealthScript = collision.gameObject.GetComponent<PlayerHealthScript>();
            fireballFunctionsScript.playerHealthScript = collision.gameObject.GetComponent<PlayerHealthScript>();
            impAnimationScript.WalkAnim();
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            impFunctionsScript.StopImp();
            impMovementScript.player = null;
            impAnimationScript.IdleAnim();
        }
    }
}
