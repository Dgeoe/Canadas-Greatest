using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullMovementScript : MonoBehaviour
{
    public BullCoreScript bullCoreScript;
    public GameObject player;
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Vector2 inputVelocity;
    public float speed;
    public float speedModifier;
    public float moveX;
    public float moveY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inputVelocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = body.velocity;
        Debug.Log(velocity);
        inputVelocity = new Vector2(moveX, moveY);
        inputVelocity.x *= (speed * Time.deltaTime * speedModifier);
        inputVelocity.y *= (speed * Time.deltaTime * speedModifier);
        body.AddForce(inputVelocity - (velocity * 16));
    }
    private void Update()
    {
        if (body.velocity == Vector2.zero)
        {
            animator.SetTrigger("crash");
            bullCoreScript.isCharging = false;
            this.enabled = false;
        }
    }
}
