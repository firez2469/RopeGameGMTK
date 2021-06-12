
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
	private const string PlayerPrefsPrefix = "options.";
	private const string MasterVolumeName = "masterVolume";
	private const string MusicVolumeName = "musicVolume";
	private const string SoundVolumeName = "soundVolume";
	private static Options instance;

	public static float masterVolume
	{
		get
		{
			return GetVolume(MasterVolumeName);
		}
		set
		{
			SetVolume(MasterVolumeName, value);
		}
	}
	public static float musicVolume
	{
		get
		{
			return GetVolume(MusicVolumeName);
		}
		set
		{
			SetVolume(MusicVolumeName, value);
		}
	}
	public static float soundVolume
	{
		get
		{
			return GetVolume(SoundVolumeName);
		}
		set
		{
			SetVolume(SoundVolumeName, value);
		}
	}


	[SerializeField]
	private AudioMixer mixer;


	void Start()
	{
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(this.gameObject);
			this.InitializeSettings();
		}
		else
		{
			Object.Destroy(this.gameObject);
		}
	}
	
	private void InitializeSettings()
	{
		SetVolume(MasterVolumeName, PlayerPrefs.GetFloat(PlayerPrefsPrefix + MasterVolumeName, 1), false);
		SetVolume(MusicVolumeName, PlayerPrefs.GetFloat(PlayerPrefsPrefix + MusicVolumeName, 1), false);
		SetVolume(SoundVolumeName, PlayerPrefs.GetFloat(PlayerPrefsPrefix + SoundVolumeName, 1), false);
	}

	private static void SetVolume(string name, float percentage, bool storeInPrefs = true)
	{
		float before = GetVolume(name);
		var input = Mathf.Max(float.Epsilon, percentage);
		var level = Mathf.Log(input) * 20;
		instance.mixer.SetFloat(name, level);
		if (storeInPrefs)
		{
			PlayerPrefs.SetFloat(PlayerPrefsPrefix + name, percentage);
		}
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
