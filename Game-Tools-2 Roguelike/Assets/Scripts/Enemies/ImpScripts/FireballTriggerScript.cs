using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTriggerScript : MonoBehaviour
{
    public FireballMovementScript fireballMovementScript;
    public PlayerHealthScript playerHealthScript;
    public ImpFunctionsScript impFunctionsScript;
    public ImpAttackTriggerScript impAttackTriggerScript;
    public ImpAnimationScript impAnimationScript;
    public float timer;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            //transform.localPosition = new Vector2(0, 0);
            //fireballMovementScript.inputVelocity = new Vector2(0, 0);
            //fireballMovementScript.fireballVelocity = new Vector2(0, 0);
            //playerHealthScript.HurtPlayer(1);
            //impAttackTriggerScript.fireballActive = false;
            impAnimationScript.ExplodeFireball();
        }
        else if (collision.gameObject.tag == "Enemy" && timer >= 1)
        {
            impAttackTriggerScript.fireballActive = false;
            impFunctionsScript.HurtImp(1);
        }
    }
}
