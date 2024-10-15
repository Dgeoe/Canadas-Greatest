using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImpFireballScript : MonoBehaviour
{
    public PlayerHealthScript playerHealthScript;
    public ImpScript impScript;
    public Rigidbody2D body;
    public GameObject player;
    public GameObject imp;
    public GameObject fireballVelocityObject;
    private Vector2 velocity;
    private Vector2 inputVelocity;
    private Vector2 fireballVelocity;
    public int speed;
    public float nearTurnSpeed;
    public float farTurnSpeed;
    public float fireballTime;
    private int impTriggerCount;
    // Start is called before the first frame update
    void Start()
    {
        impTriggerCount = 0;
        fireballVelocity = -player.transform.InverseTransformPoint(transform.position);
        //Debug.Log("Starting velocity: " + body.velocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(impTriggerCount);
        fireballTime += Time.deltaTime;
        velocity = body.velocity;
        inputVelocity = -player.transform.InverseTransformPoint(transform.position);
        fireballVelocity.x = Mathf.MoveTowards(fireballVelocity.x, inputVelocity.x, nearTurnSpeed * Mathf.Abs(inputVelocity.x));
        fireballVelocity.y = Mathf.MoveTowards(fireballVelocity.y, inputVelocity.y, nearTurnSpeed * Mathf.Abs(inputVelocity.y));
        fireballVelocityObject.transform.localPosition = fireballVelocity;
        Vector2 moveVelocity = fireballVelocity.normalized;
        //Debug.Log("Fireball: " + fireballVelocity);
        //Debug.Log("Input: " + inputVelocity);
        //Debug.Log("Move: " + moveVelocity);
        moveVelocity.x *= (speed * Time.deltaTime);
        moveVelocity.y *= (speed * Time.deltaTime);
        body.AddForce(moveVelocity - (velocity * 16));
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.localPosition = new Vector2(0, 0);
            inputVelocity = new Vector2(0, 0);
            fireballVelocity = new Vector2(0, 0);
            gameObject.SetActive(false);
            playerHealthScript.playerHealth--;
            Debug.Log("Player Hit! Health is now: " + playerHealthScript.playerHealth);
            impScript.fireballActive = false;
        }
        if (collision.gameObject.tag == "Enemy" && fireballTime >= 1)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == imp);
        {
            //Debug.Log(collision.gameObject.name);
            impTriggerCount++;
            //Debug.Log("impTrigger: " + impTriggerCount);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == gameObject.transform.parent);
        {
            //Debug.Log(collision.gameObject.name);
            impTriggerCount--;
            //Debug.Log("impTrigger: "+ impTriggerCount);
        }
    }
}