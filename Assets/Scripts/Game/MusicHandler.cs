using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public static MusicHandler Instance { get; private set; }
    private AudioSource gameMusic;
  
    
    [SerializeField] private OptionsSettingsSO settingsSO;
    [SerializeField] private AudioClip Song1;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
   
    
    // Start is called before the first frame update
    void Start()
    {
        gameMusic = gameObject.GetComponent<AudioSource>();
        gameMusic.volume = settingsSO.musicVolume;
    }

  
    public void ChangeChangeMusicVolume(float Value)
    {
        gameMusic.volume = Value;
        //settingsSO.musicVolume =
    }
}
