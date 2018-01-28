using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameContextualMenuController : MonoBehaviour
{
    public InputHandler inputHandler;
    public RectTransform panel;
	public GameObject menuBackdrop;
	public Button sound;
	public Button music;
	public Sprite soundButtonSpriteActive;
	public Sprite soundButtonSpriteInactive;
	public Sprite musicButtonSpriteActive;
	public Sprite musicButtonSpriteInactive;
    
	void Start(){
		if (VolumeHandler.Music)
			music.GetComponent<Image> ().sprite = musicButtonSpriteActive;
		else
			music.GetComponent<Image> ().sprite = musicButtonSpriteInactive;
		if (VolumeHandler.Sfx)
			sound.GetComponent<Image> ().sprite = soundButtonSpriteActive;
		else
			sound.GetComponent<Image> ().sprite = soundButtonSpriteInactive;
	}

    public void Pause()
    {
        Time.timeScale = 0;
		panel.localScale = new Vector3 (1, 1, 1);
		menuBackdrop.transform.localScale = new Vector3 (1, 1, 1);
        inputHandler.stopInput = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
		panel.localScale = new Vector3(0, 0, 1);
		menuBackdrop.transform.localScale = new Vector3 (0, 0, 1);
        inputHandler.stopInput = false;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
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
