using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImpFireballScript : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject player;
    private Vector2 fireballVelocity;
    public int speed;
    public float nearTurnSpeed;
    public float farTurnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting velocity: " + body.velocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = body.velocity;
        Vector2 inputVelocity = -player.transform.InverseTransformPoint(transform.position).normalized;
        fireballVelocity = fireballVelocity.normalized;
        /*
        if ((inputVelocity.x * fireballVelocity.x) < 0)
        {
            if (inputVelocity.y > fireballVelocity.y)
            {

            }
        }
        */
        fireballVelocity.x = Mathf.MoveTowards(fireballVelocity.x, inputVelocity.x, nearTurnSpeed);
        fireballVelocity.y = Mathf.MoveTowards(fireballVelocity.y, inputVelocity.y, nearTurnSpeed);
        Debug.Log("Fireball: " + fireballVelocity);
        Debug.Log("Input: " + inputVelocity);
        fireballVelocity.x *= (speed * Time.deltaTime);
        fireballVelocity.y *= (speed * Time.deltaTime);
        body.AddForce(fireballVelocity - (velocity * 16));
    }
}
