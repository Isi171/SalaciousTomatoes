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
	public AudioClip tap;
		
    
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
		VolumeHandler.SfxSource.PlayOneShot (tap, 1);
		SceneManager.LoadScene("Game");
    }
    
    public void Credits()
	{
		VolumeHandler.SfxSource.PlayOneShot (tap, 1);
        SceneManager.LoadScene("Credits");
    }

    public void Music()
	{
		VolumeHandler.SfxSource.PlayOneShot (tap, 1);
		VolumeHandler.Music = !VolumeHandler.Music;
		if (VolumeHandler.Music)
			music.sprite = musicButtonSpriteActive;
		else
			music.sprite = musicButtonSpriteInactive;
    }

    public void Sound()
	{
		VolumeHandler.SfxSource.PlayOneShot (tap, 1);
		VolumeHandler.Sfx = !VolumeHandler.Sfx;
		if (VolumeHandler.Sfx)
			sound.sprite = soundButtonSpriteActive;
		else
			sound.sprite = soundButtonSpriteInactive;
    }    
}
