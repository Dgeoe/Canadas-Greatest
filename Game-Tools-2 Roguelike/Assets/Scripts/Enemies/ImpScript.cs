using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpScript : MonoBehaviour
{
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
            Debug.Log(count);
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