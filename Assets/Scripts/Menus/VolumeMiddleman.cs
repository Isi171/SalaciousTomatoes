using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMiddleman : MonoBehaviour {
	public AudioSource music;
	public AudioSource sfx;

	void Start () {
		VolumeHandler.MusicSource = music;
		VolumeHandler.SfxSource = sfx;
	}
}
