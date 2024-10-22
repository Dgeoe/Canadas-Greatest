using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ImpMovementScript : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject player;
    public float walkModifier;
    public float sprintModifier;
    private Vector2 inputVelocity;
    [SerializeField]
    private float speed;
    [HideInInspector]
    public float speedModifier;
    // Start is called before the first frame update
    void Start()
    {
        speedModifier = sprintModifier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            Vector2 velocity = body.velocity;
            inputVelocity = -player.transform.InverseTransformPoint(transform.position).normalized;
            //Debug.Log(-player.transform.InverseTransformPoint(transform.position));
            inputVelocity.x *= (speed * Time.deltaTime * speedModifier);
            inputVelocity.y *= (speed * Time.deltaTime * speedModifier);
            body.AddForce(inputVelocity - (velocity * 16));
        }
        else
        {
            
        }
    }
}
