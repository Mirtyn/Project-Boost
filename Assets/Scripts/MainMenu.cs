using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : ProjectBehaviour
{
    public GameObject OptionsScreen;
    public GameObject StartScreen;
    public Button CompetetiveButton;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject selectLevelPanel;

    void Start()
    {
        
    }

    void Update()
    {
        //if (HardcoreMode == true || RealLanding == true )
        //{
        //    CompetetiveButton.enabled = false;
        //}
        //else
        //{
        //    CompetetiveButton.enabled = true;
        //}
    }

    public void StartFreePlay()
    {
        selectLevelPanel.SetActive(true);
        //float InGameTimeStartPressed = Time.time;
        //PlayerPrefs.SetFloat("GameStart", InGameTimeStartPressed);
        //PlayerPrefs.SetFloat("GameTimer", InGameTimeStartPressed);

        Competetive = false;
        HardcoreMode = false;
    }

    public void StartCompetetive()
    {
        selectLevelPanel.SetActive(true);
        //float InGameTimeStartPressed = Time.time;
        //PlayerPrefs.SetFloat("GameStart", InGameTimeStartPressed);
        //PlayerPrefs.SetFloat("GameTimer", InGameTimeStartPressed);

        Competetive = true;
    }

    public void OpenStart()
    {
        StartScreen.SetActive(true);
    }

    public void CloseStart()
    {
        StartScreen.SetActive(false);
    }

    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenHelp()
    {
        helpPanel.SetActive(true);
    }
}
