using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameWonTab : ProjectBehaviour
{
    public TMP_Text TimeText;
    public Button BackButton;
    public Button SubmitButton;

    public TMP_Text InputText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeText.text = "Your time is:" + TimeWhenWon.ToString("00.00") + "sec.";
        PlayerName = InputText.text;
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void SubmitButtonPressed()
    {
        Debug.Log(PlayerName);
        Debug.Log(TimeWhenWon);
    }
}
