using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaintanance : MonoBehaviour
{

    public AudioSource mainBackground;

    // Start is called before the first frame update
    void Start()
    {
        mainBackground.volume = Options.GetVolume(Options.PlayerPrefsPrefix+Options.MasterVolumeName);
    }

}
