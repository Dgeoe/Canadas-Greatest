using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int playerHealth;
    public float invincible;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
        invincible = 0;
    }

    // Update is called once per frame
    void Update()
    {
        invincible += Time.deltaTime;
    }
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Damage taken. Health is " +  playerHealth);
    }
}