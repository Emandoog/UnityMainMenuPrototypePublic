using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuUIHandler : MonoBehaviour
{
   
    private MainMenuTranslationSO mainMenuTranslation;
    private OptionsHandler options;
    private MainMenuSoundHandler mainMenuSounds;

    [SerializeField] private OptionsSettingsSO settingsSO;
    [SerializeField] private MainMenuTranslationSO mainMenuENG, mainMenuPL;
    [SerializeField] private GameObject startMenuDiv,optionsMenuDiv,creditsMenuDiv,exitMenuDiv;
    //[Header("Test")]
    [SerializeField] private GameObject startGameButton, optionsButton, creditsButton, exitButton;
    [SerializeField] private GameObject optionsExitButton, optionsLanguageText, optionsMusicText, optionsSoundText;
    [SerializeField] private GameObject creditsExitButton,creditsCreatorsText;
    [SerializeField] private GameObject exitConfirmButton,exitDeclineButton,exitQuestionText;



    void Start()
    {
        mainMenuSounds = gameObject.GetComponentInChildren<MainMenuSoundHandler>();

        //start menu
        startGameButton.gameObject.GetComponentInChildren<Button>().onClick.AddListener(StartButtonPress);
        optionsButton.gameObject.GetComponentInChildren<Button>().onClick.AddListener(OptionsButtonPress);
        creditsButton.gameObject.GetComponentInChildren<Button>().onClick.AddListener(CreditsButtonPress);
        exitButton.gameObject.GetComponentInChildren<Button>().onClick.AddListener(ExitButtonPress);

        //options menu
        optionsExitButton.GetComponentInChildren<Button>().onClick.AddListener(ExitOptionMenuPress);


        //credits menu
        creditsExitButton.GetComponentInChildren<Button>().onClick.AddListener(ExitCreditsMenuPress);
       

        //exit confirm menu 
        exitConfirmButton.GetComponentInChildren<Button>().onClick.AddListener(ExitGameConfirmPress);
        exitDeclineButton.GetComponentInChildren<Button>().onClick.AddListener(ExitGameDeclinePress);


        ChangeTranslation(settingsSO.translationIndex);
        options = gameObject.GetComponent<OptionsHandler>();
        options.languageOption.onValueChanged.AddListener(delegate { ChangeTranslation(options.languageOption.value); });
        RefreshMainMenuUI();
    }


    public void ChangeTranslation( int index) 
    {
       
        switch (index)
            {

            case 0:
                mainMenuTranslation = mainMenuENG;
                break;
            case 1:
                mainMenuTranslation = mainMenuPL;
                break;

        }

         RefreshMainMenuUI();

    }
    public void RefreshMainMenuUI()
    {
        //start menu
        startGameButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.startGameButton;
        optionsButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.optionsButton;
        creditsButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.creditsButton;
        exitButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.exitButton;

        //options menu
        optionsExitButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.backButton;
        optionsLanguageText.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.languageText;
        optionsMusicText.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.musicText;
        optionsSoundText.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.soundText;
        
        //credits menu
        creditsExitButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.backButton;
        creditsCreatorsText.GetComponent<TextMeshProUGUI>().text = mainMenuTranslation.creditsText;

        //exit confirm menu
        exitConfirmButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.confirmText;
        exitDeclineButton.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.declineText;
        exitQuestionText.GetComponentInChildren<TextMeshProUGUI>().text = mainMenuTranslation.exitWindowQuestion;
    }

   
    #region StartMenuDiv
    public void StartButtonPress() 
    {
        //SceneManager.LoadScene(1);
        startMenuDiv.SetActive(false);
        ScenesManager.Instance.LoadScene("GameScene");

        ButtonSound();

    }
    public void OptionsButtonPress()
    {

        startMenuDiv.SetActive(false);
        optionsMenuDiv.SetActive(true);

        ButtonSound();
    }
    public void CreditsButtonPress()
    {
        startMenuDiv.SetActive(false);
        creditsMenuDiv.SetActive(true);

        ButtonSound();

    }
    public void ExitButtonPress()
    {
        startMenuDiv.SetActive(false);
        exitMenuDiv.SetActive(true);

        ButtonSound();

    }
    #endregion
    #region OptionMenuDiv

    public void ExitOptionMenuPress()
    {
        optionsMenuDiv.SetActive(false);
        startMenuDiv.SetActive(true);

        ButtonSound();

    }
    #endregion
    #region CreditsMenuDiv
    public void ExitCreditsMenuPress()
    {
        creditsMenuDiv.SetActive(false);
        startMenuDiv.SetActive(true);

        ButtonSound();

    }
    #endregion
    #region ConfirmMenuDiv
    public void ExitGameConfirmPress()
    {
        Application.Quit();

        ButtonSound();

    }
    public void ExitGameDeclinePress()
    {
        startMenuDiv.SetActive(true);
        exitMenuDiv.SetActive(false);

        ButtonSound();

    }

    #endregion

    public void ButtonSound() 
    {
        mainMenuSounds.PlayButtonPress();
    }
}
