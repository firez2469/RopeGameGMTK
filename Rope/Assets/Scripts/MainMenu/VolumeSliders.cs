using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
	[SerializeField]
	private Slider masterVolumeSlider;
	[SerializeField]
	private Slider musicVolumeSlider;
	[SerializeField]
	private Slider soundVolumeSlider;


	void Start()
	{
	}

	void OnEnable()
	{
		this.masterVolumeSlider.value = Options.masterVolume;
		this.musicVolumeSlider.value = Options.musicVolume;
		this.soundVolumeSlider.value = Options.soundVolume;
		this.masterVolumeSlider.onValueChanged.AddListener(this.MasterVolumeChanged);
		this.musicVolumeSlider.onValueChanged.AddListener(this.MusicVolumeChanged);
		this.soundVolumeSlider.onValueChanged.AddListener(this.SoundVolumeChanged);
	}

	void OnDisable()
	{
		this.masterVolumeSlider.onValueChanged.RemoveListener(this.MasterVolumeChanged);
		this.musicVolumeSlider.onValueChanged.RemoveListener(this.MusicVolumeChanged);
		this.soundVolumeSlider.onValueChanged.RemoveListener(this.SoundVolumeChanged);
	}

	private void MasterVolumeChanged(float value)
	{
		Options.masterVolume = value;
	}
	private void MusicVolumeChanged(float value)
	{
		Options.musicVolume = value;
	}
	private void SoundVolumeChanged(float value)
	{
		Options.soundVolume = value;
	}
}
