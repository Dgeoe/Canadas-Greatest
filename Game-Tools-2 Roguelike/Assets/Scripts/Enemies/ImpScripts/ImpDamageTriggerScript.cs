using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpDamageTriggerScript : MonoBehaviour
{
    public PlayerHealthScript playerHealthScript;
    private float hitCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hitCooldown = Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCooldown >= 4)
        {
            playerHealthScript.HurtPlayer(1);
        }
    }
}
