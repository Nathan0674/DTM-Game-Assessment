using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Declares all relevant gameobjects, components and variables.
    // playerPos is the position of the player, this is used to determine the distance between the player and the food prefabs.
    // The references to the spawnmanager script and object are what allows us to use the currentFood variable in a different script.
    // despawnDistance is the radius around the player that food will despawn at. This is compared to the foodDistance variable to determine whether a food prefab should be despawned or not.
    // foodDistance is later assigned to the distance between the player and the food prefabs.
    private Vector2 playerPos;
    private GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    private float despawnDistance = 30.0f;
    private float foodDistance;

    // Declares the bound variables which are asigned to the position of the bound objects in the start void below.
    private float PositiveYBound;
    private float PositiveXBound;
    private float NegativeYBound;
    private float NegativeXBound;
    
    // Start is called before the first frame update
    void Start()
    {
        // Converts the raw transform values of the bound objects into more usable variables.
        PositiveYBound = GameObject.Find("TopLeftBound").GetComponent<Transform>().position.y;
        PositiveXBound = GameObject.Find("LowerRightBound").GetComponent<Transform>().position.x;
        NegativeYBound = GameObject.Find("LowerRightBound").GetComponent<Transform>().position.y;
        NegativeXBound = GameObject.Find("TopLeftBound").GetComponent<Transform>().position.x;

        // Applies a random rotation to each instantiated food prefab in order to make the spawning feel more random and interesting.
        // This also makes it more obvious that the food prefabs are not supposed to align with the tilemap grid.
        transform.Rotate(transform.forward * Random.Range(1, 180));

        // Allows me to access the "currentFood" variable:
        // Calls the SpawnManager Gameobject and grabs the SpawnManager script component.
        // Doing this lets me use the currentFood variable in a different script.
        // This is needed so that the food count can update correctly when the instantiated food prefabs despawn.
        spawnManager = GameObject.Find("SpawnManager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();

        // Detects if a food object is spawned outside of the bounds created by the tilemap.
        // Uses the x and y positions of the two "bound" objects: "TopLeftBound" and "LowerRightBound" to create a box where the food is able to sit.
        // If the position of either a "Food" or "LargeFood" object is outside of this box, it will be destroyed before the first frame using Destroy(gameObject) to destoy itself.
        // Updates the currentFood variable of the spawnmanager script by -1 if this if statement is true.
        if(transform.position.y > PositiveYBound || transform.position.y < NegativeYBound || transform.position.x > PositiveXBound || transform.position.x < NegativeXBound)
        {
            Destroy(gameObject); 
            spawnManagerScript.currentFood -= 1; 
        }
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
        // Destroy the "Food" prefab with the Destroy method. gameobject with a lower case "g" targets itself.
        // The script then references the currentFood variable from the SpawnManager script and uses this to update the currentFood by -1.
        // This Means that the player can safely move away from an area with food without worrying about losing the food permanantly, as it will despawn and update the current food accordingly.
        if (foodDistance > despawnDistance)
        {
            Destroy(gameObject); 
            spawnManagerScript.currentFood -= 1;       
        }
    }
}
