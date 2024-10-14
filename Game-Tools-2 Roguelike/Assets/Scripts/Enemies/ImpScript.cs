using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpScript : MonoBehaviour
{
    public PlayerHealthScript playerHealthScript;
    public Rigidbody2D body;
    public GameObject player;
    public GameObject fireball;
    public int speed;
    public float fireballSpawnDistance;
    private int speedModifier;
    private int count = 0;
    private bool fireballActive;
    // Start is called before the first frame update
    void Start()
    {
        fireballActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (count)
        {
            case 0:
                speedModifier = 0;
                break;
            case 1:
                speedModifier = 2;
                break;
            case 2:
                speedModifier = 1;
                break;
            case 3:
                break;
            default:
                break;
        }
        Vector2 velocity = body.velocity;
        Vector2 inputVelocity = -player.transform.InverseTransformPoint(transform.position).normalized;
        inputVelocity.x *= (speed * Time.deltaTime * speedModifier);
        inputVelocity.y *= (speed * Time.deltaTime * speedModifier);
        body.AddForce(inputVelocity - (velocity * 16));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
            Debug.Log(count);
            if (count == 3 && fireballActive == false)
            {
                fireballActive = true;
                Vector2 fireballSpawnDirection = -player.transform.InverseTransformPoint(transform.position).normalized;
                Debug.Log(fireballSpawnDirection);
                Vector2 fireballPosition = fireball.transform.localPosition;
                fireball.transform.localPosition = new Vector2(fireballPosition.x + (fireballSpawnDirection.x * fireballSpawnDistance), fireballPosition.y + (fireballSpawnDirection.y * fireballSpawnDistance));
                fireball.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && count == 4 && playerHealthScript.invincible >= 2)
        {
            playerHealthScript.playerHealth--;
            playerHealthScript.invincible = 0;
            Debug.Log("Player Hit! Health is now: " + playerHealthScript.playerHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count--;
            Debug.Log(count);
        }
    }
}