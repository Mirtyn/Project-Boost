using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class InGameHud : ProjectBehaviour
{
    public TextMeshProUGUI ShowVersionHud;
    public TextMeshProUGUI ShowLevelHud;
    public TextMeshProUGUI ShowTimeHud;
    public TextMeshProUGUI ShowFpsHud;
    public TextMeshProUGUI ShowWinOrLoseHud;
    public TextMeshProUGUI ShowHardcoreHud;
    public TextMeshProUGUI ShowRealLandingHud;

    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;
    float m_refreshTime = 0.5f;
    string HardCoreShow;
    string RealLandingShow;

    void Start()
    {
        if (HardcoreMode == true)
        {
            HardCoreShow = "H";
        }

        if (RealLanding == true)
        {
            RealLandingShow = "RL";
        }

        ShowHardcoreHud.text = HardCoreShow;
        ShowRealLandingHud.text = RealLandingShow;

        ShowVersionHud.text = ProjectBehaviour.Version;
        ShowLevelHud.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        float time = Time.time - StartTime;

        if (GameWon == true)
        {
            time = TimeWhenWon;
        }

        ShowTimeHud.text = "Time: " + time.ToString("0.00") + " sec";

        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        {
            //This code will break if you set your m_refreshTime to 0, which makes no sense.
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }
        ShowFpsHud.text = "FPS: " + Mathf.RoundToInt(m_lastFramerate);
    }


}
