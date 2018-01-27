using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour 
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Score()
    {
        SceneManager.LoadScene("Score");
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Music()
    {
        
    }

    public void Sound()
    {
        
    }    
}
