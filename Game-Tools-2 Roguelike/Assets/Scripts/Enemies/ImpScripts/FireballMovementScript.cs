using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovementScript : MonoBehaviour
{
    public GameObject player;
    public GameObject fireballVelocityObject;
    public Rigidbody2D body;
    private Vector2 velocity;
    public float fireballTime;
    public int speed;
    public float turnSpeed;
    [HideInInspector]
    public Vector2 inputVelocity;
    public Vector2 fireballVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fireballTime += Time.deltaTime;
        velocity = body.velocity;
        inputVelocity = -player.transform.InverseTransformPoint(transform.position);
        fireballVelocity.x = Mathf.MoveTowards(fireballVelocity.x, inputVelocity.x, turnSpeed * Mathf.Abs(inputVelocity.x));
        fireballVelocity.y = Mathf.MoveTowards(fireballVelocity.y, inputVelocity.y, turnSpeed * Mathf.Abs(inputVelocity.y));
        fireballVelocityObject.transform.localPosition = fireballVelocity;
        Vector2 moveVelocity = fireballVelocity.normalized;
        moveVelocity.x *= (speed * Time.deltaTime);
        moveVelocity.y *= (speed * Time.deltaTime);
        body.AddForce(moveVelocity - (velocity * 16));
    }
}