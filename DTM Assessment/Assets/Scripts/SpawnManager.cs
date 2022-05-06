using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnX;
    public float spawnY;

    public GameObject Food;

    private Vector2 playerPos;

    public int foodCap = 50;
    public  int currentFood = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Calls the spawnfood function in the first frame and repeats it.
        InvokeRepeating("SpawnFood", 1.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the player position so that the food can be spawned around the player and not in any random position.
        playerPos = GameObject.Find("Player").transform.position;
        
    }

    // This function clones the food prefab and spawns the prefab in a random position within a radius of the player.
    // Increases a counter that tracks the number of food in the scene. The maximum number of food prefabs is 50, if this is reached, stops spawning food.
    public void SpawnFood()
    {
        if (currentFood < foodCap)
        {
            Instantiate(Food, new Vector2(playerPos.x + Random.Range(-spawnX, spawnX), playerPos.y + Random.Range(-spawnY, spawnY)), Food.transform.rotation);
            currentFood = currentFood + 1;
        }    
    }
}
