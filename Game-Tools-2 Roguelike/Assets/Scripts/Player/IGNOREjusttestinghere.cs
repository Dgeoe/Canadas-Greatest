using UnityEngine;

public class IGNOREjusttestinghere : MonoBehaviour
{

    //IGNORE + DELETE LATER 
    //Just testing player collisions and mask triggers atm 
    public float moveSpeed = 5f;  
    private Vector2 movement;

    void Update()
    {
        // Get input from WASD keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the player
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
