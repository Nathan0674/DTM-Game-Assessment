using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was taken from a tutorial: https://www.youtube.com/watch?v=HwI32elDCn0
public class UIManager : MonoBehaviour
{
    // deathpanel refers to the DeathScreen object under the canvas gameobject.
    [SerializeField] GameObject deathPanel;

    // Changes the scene to the scene that is not currently active.
    // Essentially, this toggles the death scene.
    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
