using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsHandler : MonoBehaviour
{


    [SerializeField] public Slider musicVolumeSlider, soundVolumeSlider;
    [SerializeField] public TMP_Dropdown languageOption;
    [SerializeField] private OptionsSettingsSO settingsSO;
  
    void Start()
    {

        languageOption.onValueChanged.AddListener(delegate { SaveChangeLanguage(); });
        languageOption.value = settingsSO.translationIndex;

        musicVolumeSlider.onValueChanged.AddListener(delegate { SaveChangeMusicVolume(); });
        soundVolumeSlider.onValueChanged.AddListener(delegate { SaveChangeSoundVolume(); });

        musicVolumeSlider.value = settingsSO.musicVolume;
        soundVolumeSlider.value = settingsSO.soundVolume;
    }

    //this part and the one in MainMenuSoundhadler need real refactoring
    public void SaveChangeMusicVolume() 
    {
        settingsSO.musicVolume = musicVolumeSlider.value;
        MusicHandler.Instance.ChangeChangeMusicVolume(settingsSO.musicVolume);

    }
    public void SaveChangeSoundVolume()
    {
        settingsSO.soundVolume = soundVolumeSlider.value;

    }
    public void SaveChangeLanguage() 
    {

       settingsSO.translationIndex = languageOption.value;
       ScenesManager.Instance.ChangeLanguage(settingsSO.translationIndex);
        //Debug.Log(languageOption.value) ;


    }
}
