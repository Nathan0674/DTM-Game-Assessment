using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Vector2 playerPos;
    private GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    public float DespawnDistance = 30.0f;
    public float foodDistance;

    public float PositiveYBound;
    public float PositiveXBound;
    public float NegativeYBound;
    public float NegativeXBound;
    
    // Start is called before the first frame update
    void Start()
    {
        PositiveYBound = 20.0f;//GameObject.Find("TopLeftBound").GetComponent<Transform>().position.y;
        PositiveXBound = 28.0f;//GameObject.Find("LowerRightBound").GetComponent<Transform>().position.x;
        NegativeYBound = -22.0f;//GameObject.Find("LowerRightBound").GetComponent<Transform>().position.y;
        NegativeXBound = -26.0f;//GameObject.Find("TopLeftBound").GetComponent<Transform>().position.x;

        // Allows me to access the "currentFood" variable:
        // Calls the SpawnManager Gameobject and grabs the SpawnManager script component.
        // Doing this lets me use the currentFood variable in a different script.
        // This is needed so that the food count can update correctly when the instantiated food prefabs despawn.
        spawnManager = GameObject.Find("SpawnManager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the player position as a Vector2 and asigns this value to the "playerPos" vector variable.
        playerPos = GameObject.Find("Player").transform.position;

        // Gets the distance between the "Player" Object and individual "Food" prefabs using the Vector2.Distance method.
        // Assigns this value to the foodDistance variable.
        foodDistance = Vector2.Distance(playerPos, transform.position);

        // This if statement destroys food prefabs when they are out of a certain radius of the player.
        // Its condition is that if the distance between the "Food" prefab and the "Player" GameObject is greater than the fixed value of the "despawnDistance" float:
        // Destroy the "Food" prefab with the Destroy method. gameobject with a lower case "g" taregets itself.
        // The script then references the currentFood variable from the SpawnManager script and uses this to update the currentFood by -1.
        // This Means that the player can safely move away from an area with food without worrying about losing the food permanantly, as it will despawn and update the current food accordingly.
        if (foodDistance > DespawnDistance)
        {
            Destroy(gameObject); 
            spawnManagerScript.currentFood -= 1;
        }

        if(transform.position.y > PositiveYBound || transform.position.y < NegativeYBound )
        {
            Destroy(gameObject); 
            Debug.Log("Detected");
            spawnManagerScript.currentFood -= 1; 
        }

        if(transform.position.x > PositiveXBound || transform.position.x < NegativeXBound )
        {
            Destroy(gameObject); 
            Debug.Log("Detected");
            spawnManagerScript.currentFood -= 1; 
        }
    }

    void FindSpawnBounds()
    {
        
    }

}
