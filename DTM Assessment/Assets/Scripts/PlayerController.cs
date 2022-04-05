using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    
    public float moveSpeed;
    public float currentSpeed;
    public float maxSpeed = 4.0f;

    public float turnSpeed = 250.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
        
            if (currentSpeed < maxSpeed)
            {
                currentSpeed *= 1.001f;
            }
        
        if(Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.up * currentSpeed * Time.deltaTime);

            if (currentSpeed < maxSpeed)
            {
                currentSpeed *= 1.001f;
            }
        
        // Setting speed to 0 if not moving
        if(!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = moveSpeed;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        
    }

    // If player collides with food, destroy the food.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
           Destroy(other.gameObject);
        }
    } 
}
