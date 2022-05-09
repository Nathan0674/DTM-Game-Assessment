using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawn x and y are paramaters that define an area around the player in which food can spawn.
    public float spawnX;
    public float spawnY;

    // Declares the gameobejcts used in the script.
    public GameObject Food;
    public GameObject LargeFood;
    public GameObject Enemy;

    // playerPos is the current position of the player, this is used several times throughout the script for spawning objects.
    private Vector2 playerPos;

    // Food cap is used to limit the number of instantiated food prefabs that are able to spawn. 
    // This reduces lag and means that the player has to eat food for it to respawn once it reaches the cap.
    public int foodCap = 50;
    public  int currentFood = 0;

    // Used to define the spawning bounds for the instantiated enemy prefabs.
    // These reference the "TopLeftBound" and "LowerRightBound" game objects like in the Food script.
    public float PositiveYBound;
    public float PositiveXBound;
    public float NegativeYBound;
    public float NegativeXBound;

    // Start is called before the first frame update
    void Start()
    {
        // Asigns the positions of the bound objects to an easier to use variable.
        PositiveYBound = GameObject.Find("TopLeftBound").GetComponent<Transform>().position.y;
        PositiveXBound = GameObject.Find("LowerRightBound").GetComponent<Transform>().position.x;
        NegativeYBound = GameObject.Find("LowerRightBound").GetComponent<Transform>().position.y;
        NegativeXBound = GameObject.Find("TopLeftBound").GetComponent<Transform>().position.x;

        // Calls the spawnfood, spawnlargefood and spawnenemy functions in the first frame and repeats it.
        InvokeRepeating("SpawnFood", 1.0f, 0.8f);
        InvokeRepeating("SpawnLargeFood", 1.0f, 4.0f);
        InvokeRepeating("SpawnEnemy", 4.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the player position so that the food can be spawned around the player and not in any random position. 
        // Asigns the Player's position to the playerPos variable.
        if (GameObject.Find("Player") != null)
        {
            playerPos = GameObject.Find("Player").transform.position;
        }
        
    }

    // This function is used to spawn food. It is called in "start" and is set to repeat, giving the player an endless supply of food.
    // The function will only spawn food if the current number of food prefabs on the map is lower than the food cap.
    // If the if statement's condition is true, the function uses the instantiate method to clone the food prefab and place it in a random location around the player.
    // Increases the current food by 1. This means that the potential food that can spawn is smaller, as it is closer to the cap.
    public void SpawnFood()
    {
        if (currentFood < foodCap)
        {
            Instantiate(Food, new Vector2(playerPos.x + Random.Range(-spawnX, spawnX), playerPos.y + Random.Range(-spawnY, spawnY)), Food.transform.rotation);
            currentFood = currentFood + 1;
        }    
    }

    // Same as spawnfood, but with the LargeFood object. 
    // In start, the delay on the spawn is higher because the object is not only larger, but rewards more points as seen in the PlayerController script. 
    public void SpawnLargeFood()
    {
        if (currentFood < foodCap)
        {
            Instantiate(LargeFood, new Vector2(playerPos.x + Random.Range(-spawnX, spawnX), playerPos.y + Random.Range(-spawnY, spawnY)), LargeFood.transform.rotation);
            currentFood = currentFood + 1;
        }    
    }

    // Similar concept to the food spawning methods, however this method uses the bounds of the map to randomly spawn the enemies.
    // This was done to give the player more space and reduce the risk of the player running straight into an enemy object and losing without having time to react.
    // There is no cap on the number of enemy objects that can be on the map at once, as the increasing number of enemy prefabs is how the arcade-style difficulty of the game increases.
    public void SpawnEnemy()
    {
            Instantiate(Enemy, new Vector2(Random.Range(NegativeXBound, PositiveXBound), Random.Range(NegativeYBound, PositiveYBound)), Enemy.transform.rotation);
    }
}
