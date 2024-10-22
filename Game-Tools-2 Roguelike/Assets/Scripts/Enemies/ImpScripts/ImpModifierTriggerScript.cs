using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpModifierTriggerScript : MonoBehaviour
{
    public ImpMovementScript impMovementScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            impMovementScript.speedModifier = impMovementScript.walkModifier;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            impMovementScript.speedModifier = impMovementScript.sprintModifier;
        }
    }
}
