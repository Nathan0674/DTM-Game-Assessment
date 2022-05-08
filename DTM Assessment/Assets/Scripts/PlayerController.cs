using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declares relevant gameobjects and compnents.
    private Rigidbody2D rb2D;
    private GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    
    // Variables relating to the players movement and rotation.
    // Movespeed is the distance that the player moves in each frame when the corresponding keys are pressed.
    // Turnspeed is the angle that the player object turns per frame when the corresponding keys are pressed.
    public float moveSpeed;
    public float turnSpeed = 250.0f;
    public float currentSpeed;

    // The score variable is declared in the playercontroller script rather than the score script because the first use of this variable is when the player colldies with food.
    // This variable is tied to the text object in the top left of the screen, this updates according to the value of this variable.
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the players rigid body component so that I can use the .Addforce method, which allows for smooth movement.
        // Gets the spawnmanager gameobject and script to allow me to use the currentfood variable.
        rb2D = GetComponent<Rigidbody2D>();
        spawnManager = GameObject.Find("SpawnManager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Simple movement using the .Addforce method, this gives the player smooth acceleration and deceleration when the corresponding keys are pressed. 
        // [INPUT]: When either the up or down arrows are pressed:
        // [OUTPUT]:
        // Applies a force to the rigid body of the player, which moves the player forward.
        // This force is dependant on the movespeed variable and the forcemode is set to impulse which is the best in this scenario as it applies and instant force that is dependant on the objects mass.
        if(Input.GetKey(KeyCode.UpArrow))
            rb2D.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
        
        // movespeed is * -1 here to reverse the direction of the movement output.
        else if(Input.GetKey(KeyCode.DownArrow))
            rb2D.AddForce(transform.up * -moveSpeed, ForceMode2D.Impulse); 
        

        // Simple rotation using the transform.rotate method.
        // [INPUT]: If either the left or right arrow keys are pressed:
        // [OUTPUT]:
        // Rotates along the forward direction of the vector3, which is the z axis, this results in a top down rotation from the 2D pov of the user.
        // This rotation is dependant on the turnspeed variable.
        // The rotation is then * by Time.deltaTime to slow the rotation, essentially adding a tiny delay between each rotation.
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime); 
    }

    // This void lets the user "eat" food prefabs using the OnTriggerEnter method, which triggers on the first frame of its condition. 
    // This also allows the game round to end when the player collides with an enemy.
    // [INPUT]: If the user contacts a gameobject/prefab with a tag of either "Food" or "Largefood":
    // [OUTPUT]:
    // The other.gameobject (food prefab) is destroyed, which removed it from the scene and the player can no longer interact with it.
    // Uses the currentFood variable from the spawnmanager script to update the currentFood variable. This frees up the spot in the food cap that was being taken up and allows for more food to spawn.
    // Adds a value to the score value depending on the type of food it is. This then updates the text in the top left of the screen.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food" || other.gameObject.tag == "LargeFood")
        {
            Destroy(other.gameObject);
            spawnManagerScript.currentFood -= 1;
            score += 1;
            
            // The above if statement is triggered if either food related tag is collided with. 
            // This if statement is only true if specifically the large food tag was collided with. 
            // If this statement is true, then the player is awarded a score bonus as this type fo food object is rarer that the regular food.
            if(other.gameObject.tag == "LargeFood")
            {
                score += 4;
            }
        }

        // This if statement checks if the player has collided with an enemy.
        // If this statement is true, the script runs PlayerDeath().
        if (other.gameObject.tag == "Enemy")
        {
            PlayerDeath();
        }
    } 

    // This specific part of this script was taken from a tutorial: https://www.youtube.com/watch?v=HwI32elDCn0
    // This changes the scene to the "DeathScreen" under the canvas gameobject. 
    // This opens an overlaying scene that notifies the player that they have been killed and allows them to respawn using a button.
    private void PlayerDeath()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}
