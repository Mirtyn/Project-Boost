using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelScript : ProjectBehaviour
{
    int lvl = 0;

    public void PlayWorld1()
    {
        lvl = 1;
        StartWorld(lvl);
    }

    public void PlayWorld2()
    {
        lvl = 4;
        StartWorld(lvl);
    }

    public void PlayWorld3()
    {
        lvl = 7;
        StartWorld(lvl);
    }

    public void PlayWorld4()
    {
        lvl = 10;
        StartWorld(lvl);
    }

    void StartWorld(int level)
    {
        SceneManager.LoadScene(level);
        StartTime = Time.time;
        GameWon = false;
    }

    public void BackButton()
    {
        this.gameObject.SetActive(false);
    }
}
