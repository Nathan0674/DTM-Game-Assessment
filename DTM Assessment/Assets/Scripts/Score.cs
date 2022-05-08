using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Declares relevant gameobjects and components.
    private GameObject playerController;
    private PlayerController playerControllerScript;
    // The score text, as its name suggests, displays the players score variable.
    // This variable originates in the PlayerController script, so the declarations above allow us to use this variable from another script, in this one.
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the gameobjects and script associated with the score variable.
        playerController = GameObject.Find("Player");
        playerControllerScript = playerController.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // This updates the score text in the top left corner of the screen.
        // The score text object is assinged the value of the score variable, this is from the Playercontrollerscript, which is put before the variable.
        // This value will be an integer (int) and is unable to be used in a text object, which requires a string.
        // The "ToString" method converts the int value of score into a string which is now usable for a text object and can be displayed and updated.
        scoreText.text = playerControllerScript.score.ToString();
    }
}
