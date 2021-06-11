using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderSound : MonoBehaviour
{
	[SerializeField]
	private SoundEffectSource soundEffectSource;
	[SerializeField]
	private AudioClip soundEffect;
	[SerializeField]
	private float minDelay = 0.1f;

	private float lastSound = 0;


	void Start()
	{
		var slider = this.GetComponent<Slider>();
		slider.onValueChanged.AddListener(this.ValueChanged);
	}

	private void ValueChanged(float value)
	{
		if (Time.unscaledTime >= this.lastSound + this.minDelay)
		{
			this.lastSound = Time.unscaledTime;
			this.soundEffectSource.PlayStationary(this.soundEffect, Vector3.zero, 1);
		}
	}
}
