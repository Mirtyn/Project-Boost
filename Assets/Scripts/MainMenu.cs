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

    void Start()
    {
        
    }

    void Update()
    {
        if (HardcoreMode == true || RealLanding == true )
        {
            CompetetiveButton.enabled = false;
        }
        else
        {
            CompetetiveButton.enabled = true;
        }
    }

    public void StartFreePlay()
    {
        SceneManager.LoadScene(1);
        //float InGameTimeStartPressed = Time.time;
        StartTime = Time.time;
        //PlayerPrefs.SetFloat("GameStart", InGameTimeStartPressed);
        //PlayerPrefs.SetFloat("GameTimer", InGameTimeStartPressed);

        Competetive = false;
        GameWon = false;
    }

    public void StartCompetetive()
    {
        SceneManager.LoadScene(1);
        //float InGameTimeStartPressed = Time.time;
        StartTime = Time.time;
        //PlayerPrefs.SetFloat("GameStart", InGameTimeStartPressed);
        //PlayerPrefs.SetFloat("GameTimer", InGameTimeStartPressed);

        Competetive = true;
        GameWon = false;
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
}
