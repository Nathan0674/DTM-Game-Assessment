using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was taken from a tutorial: https://www.youtube.com/watch?v=HwI32elDCn0
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    private void Awake()
    {
        if(LevelManager.instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        UIManager _ui = GetComponent<UIManager>();
        if(_ui != null)
        {
            _ui.ToggleDeathPanel();
        }
    }
}
