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

	public Image sound;
	public Image music;
	public Sprite soundButtonSpriteActive;
	public Sprite soundButtonSpriteInactive;
	public Sprite musicButtonSpriteActive;
	public Sprite musicButtonSpriteInactive;
	public AudioClip ac_Tap;
		
    
    private void Start()
    {
        highscoreTitle.text = CustomRandom.From(highscoreTitles);
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
		if (VolumeHandler.Music)
			music.sprite = musicButtonSpriteActive;
		else
			music.sprite = musicButtonSpriteInactive;
		if (VolumeHandler.Sfx)
			sound.sprite = soundButtonSpriteActive;
		else
			sound.sprite = soundButtonSpriteInactive;
    }
    
    public void Play()
    {
		VolumeHandler.SfxSource.PlayOneShot (ac_Tap, 1);
		SceneManager.LoadScene("Game(WithSoundManagement)");
    }
    
    public void Credits()
	{
		VolumeHandler.SfxSource.PlayOneShot (ac_Tap, 1);
        SceneManager.LoadScene("Credits");
    }

    public void Music()
	{
		VolumeHandler.SfxSource.PlayOneShot (ac_Tap, 1);
		VolumeHandler.Music = !VolumeHandler.Music;
		if (VolumeHandler.Music)
			music.sprite = musicButtonSpriteActive;
		else
			music.sprite = musicButtonSpriteInactive;
    }

    public void Sound()
	{
		VolumeHandler.SfxSource.PlayOneShot (ac_Tap, 1);
		VolumeHandler.Sfx = !VolumeHandler.Sfx;
		if (VolumeHandler.Sfx)
			sound.sprite = soundButtonSpriteActive;
		else
			sound.sprite = soundButtonSpriteInactive;
    }    
}
