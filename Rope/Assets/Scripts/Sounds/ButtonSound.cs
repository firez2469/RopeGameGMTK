using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
	[SerializeField]
	private SoundEffectSource soundSourcePrefab;
	[SerializeField]
	private AudioClip soundEffect;

	void Start()
	{
		var button = this.GetComponent<Button>();
		button.onClick.AddListener(this.ButtonClicked);
	}

	void ButtonClicked()
	{
		this.soundSourcePrefab.PlayStationary(this.soundEffect, Vector3.zero, 1, SoundEffectOptions.AcrossScenes);
	}
}
