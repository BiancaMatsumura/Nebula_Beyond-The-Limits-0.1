using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class settings : MonoBehaviour
{
    private static string Msc_VolumeLevel = "MUSICVolumeLevel";
    public static float MscVolumeLevel
    {
        get
        {
            return PlayerPrefs.GetFloat(Msc_VolumeLevel, 1);
        }
        set
        {
            PlayerPrefs.SetFloat(Msc_VolumeLevel, value);
        }
    }

    private static string Sfx_VolumeLevel = "SFXVolumeLevel";
    public static float SfxVolumeLevel
    {
        get
        {
            return PlayerPrefs.GetFloat(Sfx_VolumeLevel, 1);
        }
        set
        {
            PlayerPrefs.SetFloat(Sfx_VolumeLevel, value);
        }
    }
}