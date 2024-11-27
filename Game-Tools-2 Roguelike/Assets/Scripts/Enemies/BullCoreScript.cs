using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BullCoreScript : MonoBehaviour
{
    public BullMovementScript bullMovementScript;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private Vector2 inputVelocity;
    public GameObject player;
    public bool startCharge;
    public bool isCharging;
    private bool isTrigger;
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
        if (!isTrigger)
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTrigger = true;
            startCharge = true;
            inputVelocity = -player.transform.InverseTransformPoint(transform.position);
            if (!isCharging)
            {
                animator.SetTrigger("charge up");
                if (Mathf.Abs(inputVelocity.x) > Mathf.Abs(inputVelocity.y))
                {
                    switch (inputVelocity.x)
                    {
                        case (> 0):
                            spriteRenderer.flipX = true;
                            bullMovementScript.moveX = 1;
                            break;
                        case (< 0):
                            spriteRenderer.flipX = false;
                            bullMovementScript.moveX = -1;
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
                            break;
                        case (< 0):
                            bullMovementScript.moveY = -1;
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
            isTrigger = false;
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
}
