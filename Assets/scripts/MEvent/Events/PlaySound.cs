using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MEventComponent {
	public AudioClip clip;

    public override void Fire()
    {
		AudioSource audioSource = GetAudioSource();
        audioSource.clip = clip;
		audioSource.Play();
    }

	AudioSource GetAudioSource()
	{
		AudioSource audioSource = GetComponent<AudioSource>();
		if (audioSource != null)
		{
			return audioSource;
		}
		gameObject.AddComponent<AudioSource>();
		return GetComponent<AudioSource>();
	}
}
