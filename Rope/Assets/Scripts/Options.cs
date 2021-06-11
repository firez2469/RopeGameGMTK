using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
	private static Options instance;

	public static float masterVolume
	{
		get
		{
			return GetVolume("masterVolume");
		}
		set
		{
			SetVolume("masterVolume", value);
		}
	}
	public static float musicVolume
	{
		get
		{
			return GetVolume("musicVolume");
		}
		set
		{
			SetVolume("musicVolume", value);
		}
	}
	public static float soundVolume
	{
		get
		{
			return GetVolume("soundVolume");
		}
		set
		{
			SetVolume("soundVolume", value);
		}
	}


	[SerializeField]
	private AudioMixer mixer;


	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Object.Destroy(this.gameObject);
		}
	}

	private static void SetVolume(string name, float percentage)
	{
		var input = Mathf.Max(float.MinValue, percentage);
		var level = Mathf.Log(input) * 20;
		instance.mixer.SetFloat(name, level);
	}
	private static float GetVolume(string name)
	{
		float level;
		if (instance.mixer.GetFloat(name, out level))
		{
			var output = Mathf.Exp(level / 20);
			var percentage = output >= float.MinValue * 2 ? output : 0;
			return percentage;
		}
		else
		{
			return 0;
		}
	}
}
