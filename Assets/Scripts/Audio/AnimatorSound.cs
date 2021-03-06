﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSound : MonoBehaviour
{

	public AudioClip sfx;

	public void PlaySfx()
	{
		VolumeHandler.SfxSource.PlayOneShot(sfx, 1);
	}

	public void PlaySfxAmp()
	{
		VolumeHandler.SfxSource.PlayOneShot(sfx, 3);
	}
}
