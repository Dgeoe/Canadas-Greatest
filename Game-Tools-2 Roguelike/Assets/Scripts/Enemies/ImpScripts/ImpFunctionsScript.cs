using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ImpFunctionsScript : MonoBehaviour
{
    public ImpMovementScript impMovementScript;
    public ImpAnimationScript impAnimationScript;
    public FireballMovementScript fireballMovementScript;
    public GameObject fireball;
    public Rigidbody2D body;
    public Rigidbody2D fireballBody;
    public float fireballSpawnDistance;
    private bool fireballActive;
    private int impHealth;
    public void SpawnFireball()
    {
        fireballActive = true;
        Vector2 fireballSpawnDirection = -impMovementScript.player.transform.InverseTransformPoint(transform.position).normalized;
        Debug.Log(fireballSpawnDirection);
        //Debug.Log(fireballSpawnDirection);
        Vector2 fireballPosition = fireball.transform.localPosition;
        fireball.transform.localPosition = new Vector2(fireballPosition.x + (fireballSpawnDirection.x * fireballSpawnDistance), fireballPosition.y + (fireballSpawnDirection.y * fireballSpawnDistance));
        fireball.SetActive(true);
    }
    public void DisableFireball()
    {
        fireball.SetActive(false);
    }
    public void StopImp()
    {
        body.velocity = new Vector2(0, 0);
        impMovementScript.enabled = false;
    }
    public void StartImp()
    {
        impMovementScript.enabled = true;
    }
    public void StopFireball()
    {
        fireballBody.velocity = new Vector2(0, 0);
        fireballMovementScript.enabled = false;

    }
    public void HurtImp(int damage)
    {
        impHealth -= damage;
        if (impHealth <= 0)
        {
            impAnimationScript.DeathAnim();
        }
    }
    public void DestroyImp()
    {
        Destroy(gameObject);
    }
}
