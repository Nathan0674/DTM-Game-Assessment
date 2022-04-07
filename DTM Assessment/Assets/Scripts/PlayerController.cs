using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rb2D;
    private GameObject spawnManager;
    
    public float moveSpeed;
    public float currentSpeed;
    public float maxSpeed = 4.0f;
    public float turnSpeed = 250.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Detects if Up arrow is pressed, if yes, checks if the current player speed is less than the max speed.
        // If this is true, slowly increases player speed until the maximum velocity is reached.
        // If already at maximum speed, constant speed is maintained.
        if(Input.GetKey(KeyCode.UpArrow))
            rb2D.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse); // transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
        
            //if (currentSpeed < maxSpeed)
            //{
                //currentSpeed *= 1.001f;
            //}
        
        if(Input.GetKey(KeyCode.DownArrow))
            rb2D.AddForce(transform.up * -moveSpeed, ForceMode2D.Impulse); // transform.Translate(-Vector3.up * currentSpeed * Time.deltaTime);

            //if (currentSpeed < maxSpeed)
            //{
               //currentSpeed *= 1.001f;
            //}
        
        // Reducing speed to 0 if both up and down arrows are NOT pressed.
        // When both keys are not pressed, slowly decreased speed to the minimum speed.
        // If the currentSpeed variable is lower than 0.0, sets the currentSpeed to minSpeed. (minSpeed = 0.0f)
        if(!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = moveSpeed;
        }

        // Detects the left and right arrow key presses and rotates the player in the corresponsing direction at a constant rate.
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
           // currentFood = currentFood - 1;
        }
    } 
}
