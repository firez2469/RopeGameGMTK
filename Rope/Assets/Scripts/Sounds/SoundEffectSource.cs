using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectSource : MonoBehaviour
{
	public void PlayStationary(AudioClip soundEffect, Vector3 position, float volume, SoundEffectOptions options = default)
	{
		var instance = PrepareSource(volume, options);
		instance.transform.position = position;
		instance.PlaySound(soundEffect, options);
	}
	public void PlayStationary(AudioClip soundEffect, Transform transform, float volume, SoundEffectOptions options = default)
	{
		PlayStationary(soundEffect, transform.position, volume, options);
	}
	public void PlayAsChild(AudioClip soundEffect, Transform parent, float volume, SoundEffectOptions options = default)
	{
		// requires DontDestroyOnLoad, which doesn't work for children
		options = options & ~SoundEffectOptions.AcrossScenes;
		var instance = PrepareSource(volume, options);
		instance.transform.SetParent(parent);
		instance.PlaySound(soundEffect, options);
	}
	public void PlayAsFollowing(AudioClip soundEffect, Transform parent, float volume, SoundEffectOptions options = default)
	{
		var instance = PrepareSource(volume, options);
		instance.transform.position = parent.position;
		instance.PlaySound(soundEffect, options);
	}
	private SoundEffectSource PrepareSource(float volume, SoundEffectOptions options)
	{
		// Can be appended by an object pool later on.
		var instance = Object.Instantiate<SoundEffectSource>(this);
		instance.gameObject.name = "SoundSource";
		instance.following = null;
		instance.audioSource = instance.GetComponent<AudioSource>();
		instance.audioSource.volume = volume;
		if ((options & SoundEffectOptions.AcrossScenes) != 0)
		{
			Object.DontDestroyOnLoad(instance.gameObject);
		}

		return instance;
	}

	private Transform following;
	private AudioSource audioSource;
	private float endTime;

	private void PlaySound(AudioClip soundEffect, SoundEffectOptions options)
	{
		this.audioSource = this.GetComponent<AudioSource>();
		this.audioSource.clip = soundEffect;
		this.audioSource.loop = false;
		this.audioSource.Play();
		// this.audioSource.PlayOneShot(soundEffect);
		this.endTime = Time.time + soundEffect.length;
	}

	void LateUpdate()
	{
		if (this.following != null)
		{
			this.transform.position = this.following.position;
		}

		if (Time.time > this.endTime)
		{
			// Object.Destroy(this.gameObject);
		}
	}
}

[System.Flags]
public enum SoundEffectOptions
{
	AcrossScenes = 1
}
