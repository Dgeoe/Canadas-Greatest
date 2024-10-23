using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballFunctionsScript : MonoBehaviour
{
    public FireballMovementScript fireballMovementScript;
    public PlayerHealthScript playerHealthScript;
    public ImpAttackTriggerScript impAttackTriggerScript;
    public void DisableFireball()
    {
        transform.localPosition = new Vector2(0, 0);
        fireballMovementScript.inputVelocity = new Vector2(0, 0);
        fireballMovementScript.fireballVelocity = new Vector2(0, 0);
        playerHealthScript.HurtPlayer(1);
        impAttackTriggerScript.fireballActive = false;
        gameObject.SetActive(false);
    }
}
