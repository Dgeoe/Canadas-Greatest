using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpFireballCoreScript : MonoBehaviour
{
    public ImpFireballMovementScript impFireballMovementScript;
    public ImpCoreScript impCoreScript;
    public PlayerHealthScript playerHealthScript;
    public EnemyHealthScript enemyHealthScript;
    public Animator animator;
    public Rigidbody2D body;
    public GameObject player;
    public GameObject imp;
    public float fireballTime;
    public int target;
    
    // Find the player in the scene and assigns the PlayerHealthScript script variable
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealthScript>();
    }

    // A timer for how long the fireball has been in flight
    void Update()
    {
        if (impCoreScript.fireballActive == true)
        {
            fireballTime += Time.deltaTime;
        }
        if (enemyHealthScript.health <= 0)
        {
            FireballImpactAnim();
        }
    }

    // Checks if the fireball has collided with the player, or another enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            playerHealthScript.TakeDamage(1);
            FireballImpactAnim();
        }
        else if (collision.gameObject.tag == "Enemy" && fireballTime >= 1)
        {
            Debug.Log("Other enemy hit");
            collision.GetComponentInParent<EnemyHealthScript>().TakeDamage(1);
            FireballImpactAnim();
        }
    }

    // This function plays from an event in the fireball's impact animation.
    // It
    public void ResetFireball()
    {
        fireballTime = 0;
        transform.localPosition = new Vector2(0, 0);
        impFireballMovementScript.velocity = new Vector2(0, 0);
        impFireballMovementScript.inputVelocity = new Vector2(0, 0);
        impFireballMovementScript.fireballVelocity = new Vector2(0, 0);
        impCoreScript.fireballActive = false;
        impFireballMovementScript.enabled = true;
        gameObject.SetActive(false);
    }
    public void FireballImpactAnim()
    {
        impFireballMovementScript.enabled = false;
        body.velocity = new Vector2(0, 0);
        animator.SetTrigger("impact");
    }
}
