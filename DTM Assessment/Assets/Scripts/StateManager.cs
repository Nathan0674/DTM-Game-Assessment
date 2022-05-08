using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script was taken from a tutorial: https://www.youtube.com/watch?v=HwI32elDCn0
public class StateManager : MonoBehaviour
{
    // Reloads the current scene by loading the same scene as the one currently active.
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Allows the game to change the scene according to its name.
    // Loads the scene by its name using the LoadScene Method.
    public void ChangeSceneByName(string name)
    {
        if(name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
}
