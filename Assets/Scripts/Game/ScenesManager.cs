using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScenesManager : MonoBehaviour
{

    private LoadingTipsSO loadingTips;
    public static ScenesManager Instance { get; private set; }
    [SerializeField] string scene1, scene2, scene3;
    [SerializeField] GameObject background;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject fade;
   
    [SerializeField] TextMeshProUGUI tipBox;
    [SerializeField] Slider loadingBar;
    [SerializeField] LoadingTipsSO loadingTipsEng, loadingTipsPL;
    private AsyncOperation asyncLoad;

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }

    private void Start()
    {
        loadingTips = loadingTipsEng;

        continueButton.gameObject.GetComponentInChildren<Button>().onClick.AddListener(ContinueButtonPress);
        background.SetActive(false);
        continueButton.SetActive(false);
    }

    public void LoadScene(string sceneName) 
    {
        //open Loading

        StartCoroutine(LoadSceneAsync(sceneName));
        StartCoroutine(ChangeTip());
        background.SetActive(true);
    

    }

   
    IEnumerator LoadSceneAsync(string sceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            //Slider max value is 0.9
            loadingBar.value = asyncLoad.progress;
            continueButton.SetActive(true);
            yield return null;


        }
            

    }
    IEnumerator ChangeTip()
    {
     
        tipBox.text = loadingTips.tips[Random.Range(0, loadingTips.tips.Length)];
        yield return new WaitForSeconds(5);
        if (background.activeSelf)
            {
                StartCoroutine(ChangeTip());
            }
    

    }
    private void ContinueButtonPress() 
    {
        //play sound
        fade.SetActive(true);
        fade.GetComponent<Animator>().Play("FadeIn");
        //continueButton.SetActive(false);
        //background.SetActive(false);
        //asyncLoad.allowSceneActivation = true;
     

    }
    public void TransistionOut()
    {

       
        continueButton.SetActive(false);
        background.SetActive(false);
        asyncLoad.allowSceneActivation = true;
        



    }

    public void ChangeLanguage(int index)
    {
        //there is propably better way of doing it 
        switch (index)
        { 
            case 0:
              loadingTips = loadingTipsEng;
              break;

            case 1:
              loadingTips = loadingTipsEng;
              break;
        }
    }

}

