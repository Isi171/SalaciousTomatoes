using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VolumeHandler {
	// if true, the source is active
	private static bool sfx;
	private static bool music;
	private static AudioSource musicSource;
	private static AudioSource sfxSource;



	public static bool Sfx {
		get{ return sfx; }
		set{ 
			sfx = value;
			ToggleVolume (sfxSource, sfx);
		}
	}
	public static bool Music {
		get{ return music; }
		set{
			music = value;
			ToggleVolume (musicSource, music);
		}
	}

	public static AudioSource MusicSource{
		set{ musicSource = value; }
	}

	public static AudioSource SfxSource{
		set{ sfxSource = value; }
	}

	static void ToggleVolume (AudioSource source, bool value){
		if (value)
			source.volume = 1;
		else
			source.volume = 0;
	}
}
