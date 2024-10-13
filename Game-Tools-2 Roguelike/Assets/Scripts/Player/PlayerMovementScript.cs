using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private Vector2 inputVelocity;
    private Vector2 dashVelocity;
    public float speed;
    private float speedModifier;
    private float walkModifier;
    public float sprintModifier;
    private bool isSprinting;
    public bool isCutscene;
    private float timeCount;
    private float cooldownCount;
    public float dashTime;
    public float dashModifier;
    public float dashCooldown;
    private bool isDashing;
    InputAction moveAction;
    InputAction sprintAction;
    InputAction dashAction;

    // Start is called before the first frame update
    void Start()
    {
        isSprinting = false;
        isDashing = false;
        timeCount = 0;
        cooldownCount = dashCooldown;
        walkModifier = 1f;
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        dashAction = InputSystem.actions.FindAction("Dash");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputVelocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (inputVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (!isCutscene)
        {
            cooldownCount += Time.deltaTime;
            if (dashAction.IsPressed() && cooldownCount >= dashCooldown)
            {
                cooldownCount = 0;
                Debug.Log("Dash");
                isDashing = true;
            }
            if (isDashing)
            {
                timeCount += Time.deltaTime;
                animator.SetTrigger("roll");
                if (timeCount < dashTime)
                {
                    Vector2 velocity = body.velocity;
                    dashVelocity = inputVelocity.normalized;
                    dashVelocity.x *= (speed * dashModifier * Time.deltaTime);
                    dashVelocity.y *= (speed * dashModifier * Time.deltaTime);
                    body.AddForce((dashVelocity - (velocity * 16)) * (1/speedModifier));
                    //Debug.Log(velocity);
                }
                else
                {
                    timeCount = 0;
                    isDashing = false;
                }
            }
            else
            {
                if (sprintAction.IsPressed())
                {
                    isSprinting = true;
                    speedModifier = sprintModifier;
                }
                else
                {
                    isSprinting = false;
                    speedModifier = walkModifier;
                }
                Vector2 velocity = body.velocity;
                inputVelocity = moveAction.ReadValue<Vector2>();
                Vector2 animVelocity = inputVelocity;
                inputVelocity.x *= (speed * Time.deltaTime * speedModifier);
                inputVelocity.y *= (speed * Time.deltaTime * speedModifier);
                body.AddForce(inputVelocity - (velocity * 16));
                if (isSprinting)
                {
                    animator.SetTrigger("run");
                }
                else if (animVelocity != Vector2.zero)
                {
                    animator.SetTrigger("walk");
                }
                else
                {
                    animator.SetTrigger("idle");
                }
            }
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
}