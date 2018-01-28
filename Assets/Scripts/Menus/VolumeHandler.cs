using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VolumeHandler {
	// if true, the source is active
	private static bool sfx = true;
	private static bool music = true;
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
		get{ return musicSource; }
		set{ musicSource = value; }
	}

	public static AudioSource SfxSource{
		get{ return sfxSource; }
		set{ sfxSource = value; }
	}

	static void ToggleVolume (AudioSource source, bool value){
		if (value)
			source.volume = 1;
		else
			source.volume = 0;
	}
}
