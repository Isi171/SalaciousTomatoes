using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMiddleman : MonoBehaviour {
	public AudioSource music;
	public AudioSource sfx;

	void Start () {
		if (VolumeHandler.Music)
			music.volume = 1;
		else
			music.volume = 0;
		if (VolumeHandler.Sfx)
			sfx.volume = 1;
		else
			sfx.volume = 0;
		VolumeHandler.MusicSource = music;
		VolumeHandler.SfxSource = sfx;
	}
}
