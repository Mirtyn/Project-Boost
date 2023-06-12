using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using ProjectBoost;
using System.Globalization;

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
        var version = ProjectBehaviour.Version;

        //var ladderService = new LadderClientApi(@"https://project-boost.mirtyn.be/ladder/post");
        var ladderService = new LadderClientApi(@"https://mirtyn.be/project-boost/ladder/post");

        var entryFlag = Ladder.EntryFlag.Competitive;

        if (ProjectBehaviour.RealLanding)
        {
            entryFlag = entryFlag | Ladder.EntryFlag.RealLanding;
        }

        if (ProjectBehaviour.HardcoreMode)
        {
            entryFlag = entryFlag | Ladder.EntryFlag.Hardcore;
        }

        var worldFlag = Ladder.WorldFlag.World1;

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            worldFlag = Ladder.WorldFlag.World1;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            worldFlag = Ladder.WorldFlag.World2;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            worldFlag = Ladder.WorldFlag.World3;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            worldFlag = Ladder.WorldFlag.World4;
        }


        if (ladderService.TryPost(
            new Ladder.Entry { Name = PlayerName, TimeInSeconds = TimeWhenWon, Flag = entryFlag, WorldFlag = worldFlag },
            version,
            out LadderClientApi.PostResponse response))
        {
            Debug.Log("The data was succesfully saved.");
            Debug.Log($"You are position {response.Position} on the ladder.");
        }
        else
        {
            Debug.Log("The data could not be saved.");
            Debug.Log("Please try again latter.");
        }

        SceneManager.LoadScene(0);
    }
}
