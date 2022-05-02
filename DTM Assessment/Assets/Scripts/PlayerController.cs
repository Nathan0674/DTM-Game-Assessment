using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rb2D;
    private GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    
    public float moveSpeed;
    public float turnSpeed = 250.0f;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spawnManager = GameObject.Find("SpawnManager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            rb2D.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
        
        else if(Input.GetKey(KeyCode.DownArrow))
            rb2D.AddForce(transform.up * -moveSpeed, ForceMode2D.Impulse); 
        

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
            spawnManagerScript.currentFood -= 1;
        }
    } 
}
