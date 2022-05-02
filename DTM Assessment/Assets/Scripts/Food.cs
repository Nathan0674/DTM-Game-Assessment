using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoddMovement : MonoBehaviour
{
    private Vector2 playerPos;
    private GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    
    

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;

        if (Mathf.Abs(transform.position.y) <= playerPos.y + 15 || Mathf.Abs(transform.position.x) <= playerPos.x + 15)
        {
            Destroy(gameObject); 
            spawnManagerScript.currentFood -= 1;       
        }


    }

}
