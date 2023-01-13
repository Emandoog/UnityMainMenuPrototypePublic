using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundHandler : MonoBehaviour
{
    private OptionsHandler options;

    [SerializeField] private AudioSource mainMenuSoundEffects,mainMenuMusic;
    [SerializeField] private AudioClip buttonPress;
    [SerializeField] private OptionsSettingsSO settingsSO;
  

    //saving options preset should work if we build the project, otherwise opening the project again will reset it 

    private void Start()
    {
        mainMenuSoundEffects.volume = settingsSO.soundVolume;
        mainMenuMusic.volume = settingsSO.musicVolume;

        options = gameObject.GetComponent<OptionsHandler>();
        mainMenuSoundEffects = gameObject.GetComponent<AudioSource>();

        options.soundVolumeSlider.onValueChanged.AddListener(delegate { ChangeSoundEffectVolume(); });
        options.musicVolumeSlider.onValueChanged.AddListener(delegate { ChangeChangeMusicVolume(); });
    }

    //this part and the one in OptionsHandler need real refactoring
    public void PlayButtonPress()
    {
        mainMenuSoundEffects.clip = buttonPress;
        mainMenuSoundEffects.PlayOneShot(buttonPress);
    }
    public void ChangeSoundEffectVolume()
    {
        mainMenuSoundEffects.volume = options.soundVolumeSlider.value;
        settingsSO.soundVolume = options.soundVolumeSlider.value;
        mainMenuSoundEffects.PlayOneShot(buttonPress);
    }
    public void ChangeChangeMusicVolume()
    {
        mainMenuMusic.volume = options.musicVolumeSlider.value;
        settingsSO.musicVolume = options.musicVolumeSlider.value;
    }
    
}
