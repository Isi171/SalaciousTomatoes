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

	public Button sound;
	public Button music;
	public Sprite soundButtonSpriteActive;
	public Sprite soundButtonSpriteInactive;
	public Sprite musicButtonSpriteActive;
	public Sprite musicButtonSpriteInactive;
		
    
    private void Start()
    {
        highscoreTitle.text = CustomRandom.From(highscoreTitles);
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
		if (VolumeHandler.Music)
			music.GetComponent<Image> ().sprite = musicButtonSpriteActive;
		else
			music.GetComponent<Image> ().sprite = musicButtonSpriteInactive;
		if (VolumeHandler.Sfx)
			sound.GetComponent<Image> ().sprite = soundButtonSpriteActive;
		else
			sound.GetComponent<Image> ().sprite = soundButtonSpriteInactive;
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
		VolumeHandler.Music = !VolumeHandler.Music;
		if (VolumeHandler.Music)
			music.GetComponent<Image> ().sprite = musicButtonSpriteActive;
		else
			music.GetComponent<Image> ().sprite = musicButtonSpriteInactive;
    }

    public void Sound()
    {
		VolumeHandler.Sfx = !VolumeHandler.Sfx;
		if (VolumeHandler.Sfx)
			sound.GetComponent<Image> ().sprite = soundButtonSpriteActive;
		else
			sound.GetComponent<Image> ().sprite = soundButtonSpriteInactive;
    }    
}
