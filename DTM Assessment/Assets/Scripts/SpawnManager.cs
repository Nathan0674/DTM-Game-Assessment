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
    public int currentFood = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 5.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;
    }

    void SpawnFood()
    {
        if (currentFood < foodCap)
        {
            Instantiate(Food, new Vector2(playerPos.x + Random.Range(-spawnX, spawnX), playerPos.y + Random.Range(-spawnY, spawnY)), Food.transform.rotation);
            currentFood = currentFood + 1;
        }
        
    }
}
