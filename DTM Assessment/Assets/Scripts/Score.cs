using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private GameObject playerController;
    private PlayerController playerControllerScript;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player");
        playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerControllerScript.score.ToString();
    }
}
