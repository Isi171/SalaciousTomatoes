using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameContextualMenuController : MonoBehaviour
{
    public InputHandler inputHandler;
    public RectTransform panel;
    
    public void Pause()
    {
        Time.timeScale = 0;
        panel.localScale = new Vector3(1, 1, 1);
        inputHandler.stopInput = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        panel.localScale = new Vector3(0, 0, 1);
        inputHandler.stopInput = false;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Music()
    {
        
    }

    public void Sound()
    {
        
    }
}
