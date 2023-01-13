using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingPreset", menuName = "SO/Settings/New Preset", order = 1)]
public class OptionsSettingsSO : ScriptableObject
{

    public float musicVolume = 0.3f;
    public float soundVolume = 0.3f;
    public int translationIndex;
}