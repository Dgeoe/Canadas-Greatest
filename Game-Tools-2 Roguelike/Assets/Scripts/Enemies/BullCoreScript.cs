using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BullCoreScript : MonoBehaviour
{
    public BullMovementScript bullMovementScript;
    public SpriteRenderer spriteRenderer;
    public EnemyHealthScript enemyHealthScript;
    public Rigidbody2D body;
    public Animator animator;
    private Vector2 inputVelocity;
    public GameObject player;
    public GameObject damageTrigger;
    private bool startCharge;
    private bool isCharging;
    private float chargeTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (startCharge)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= 1)
            {
                animator.SetTrigger("charge");
                bullMovementScript.enabled = true;
                startCharge = false;
                chargeTimer = 0;
            }
        }
        if (enemyHealthScript.health <= 0)
        {
            DeathAnim();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inputVelocity = -player.transform.InverseTransformPoint(transform.position);
            if (!isCharging)
            {
                startCharge = true;
                animator.SetTrigger("charge up");
                if (Mathf.Abs(inputVelocity.x) > Mathf.Abs(inputVelocity.y))
                {
                    switch (inputVelocity.x)
                    {
                        case (> 0):
                            spriteRenderer.flipX = true;
                            bullMovementScript.moveX = 1;
                            damageTrigger.transform.localPosition = new Vector2(1.95f, -0.1f);
                            damageTrigger.transform.localScale = new Vector2(1.5f, 1.5f);
                            break;
                        case (< 0):
                            spriteRenderer.flipX = false;
                            bullMovementScript.moveX = -1;
                            damageTrigger.transform.localPosition = new Vector2(-1.95f, -0.1f);
                            damageTrigger.transform.localScale = new Vector2(1.5f, 1.5f);
                            break;
                        default:
                            break;
                    }
                }
                else if (Mathf.Abs(inputVelocity.y) > Mathf.Abs(inputVelocity.x))
                {
                    switch (inputVelocity.y)
                    {
                        case (> 0):
                            bullMovementScript.moveY = 1;
                            damageTrigger.transform.localPosition = new Vector2(-0.1f, 1f);
                            damageTrigger.transform.localScale = new Vector2(2f, 1.5f);
                            break;
                        case (< 0):
                            bullMovementScript.moveY = -1;
                            damageTrigger.transform.localPosition = new Vector2(-0.1f, -1.5f);
                            damageTrigger.transform.localScale = new Vector2(2f, 1.5f);
                            break;
                        default:
                            break;
                    }
                }
            }
            isCharging = true;
        }
        else
        {
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //bullMovementScript.inputVelocity.x = 0;
            //bullMovementScript.inputVelocity.y = 0;
        }
    }
    public void DestroySelf()
    {
        Object.Destroy(gameObject);
    }
    public void StopImpMovement()
    {
        body.velocity = new Vector2(0, 0);
        bullMovementScript.enabled = false;
    }
    public void StopCharging()
    {
        isCharging = false;
    }
    public void DeathAnim()
    {
        StopImpMovement();
        animator.SetTrigger("death");
    }
}