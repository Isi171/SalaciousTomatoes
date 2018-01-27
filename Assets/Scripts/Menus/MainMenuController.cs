using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Text highscoreTitle;
    [SerializeField] private Text highscore;
    private readonly string[] highscoreTitles =
    {
        "Highscore",
        "DNA sequences sampled",
        "Gene samples analyzed",
        "Test subjects treated",
        "Organic matter processed (kg)",
        "RNA splices performed",
        "Biological matter liquified (kg)",
        "Ectobiological recombinations performed",
        "Traits inherited"
    };
    
    private void Start()
    {
        highscoreTitle.text = CustomRandom.From(highscoreTitles);
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
