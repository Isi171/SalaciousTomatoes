using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
  	public Image sound;
	public Image music;
	public Sprite soundButtonSpriteActive;
	public Sprite soundButtonSpriteInactive;
	public Sprite musicButtonSpriteActive;
	public Sprite musicButtonSpriteInactive;
		
    
    private void Start()
    {
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
			music.sprite = musicButtonSpriteActive;
		else
			music.sprite = musicButtonSpriteInactive;
    }

    public void Sound()
    {
		VolumeHandler.Sfx = !VolumeHandler.Sfx;
		if (VolumeHandler.Sfx)
			sound.sprite = soundButtonSpriteActive;
		else
			sound.sprite = soundButtonSpriteInactive;
    }    
}
