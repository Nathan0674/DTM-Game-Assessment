using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoddMovement : MonoBehaviour
{
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    // If player collides with food, destroy the food.
    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("e");
        }
    } 
}
