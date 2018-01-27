using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private static readonly System.Random random = new System.Random();
    [SerializeField] private Text highscoreTitle;
    [SerializeField] private Text highscore;
    private readonly string[] highscoreTitles =
    {
        "Highscore",
        "DNA sequences sampled",
        "Gene samples analyzed",
        "Test subjects treated",
        "Organic matter processed (kg)"
    };
    
    private void Start()
    {
        highscoreTitle.text = highscoreTitles[random.Next(highscoreTitles.Length)];
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Game");
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
