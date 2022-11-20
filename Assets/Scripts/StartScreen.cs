using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartScreen : ProjectBehaviour
{
    public Toggle HardcoreToggle;
    public TMP_Text HardcoreOnOrOff;

    public Toggle RealLandingToggle;
    public TMP_Text RealLandingOnOrOff;

    void Start()
    {
        if (HardcoreMode == true)
        {
            HardcoreOnOrOff.text = "ON";
            HardcoreToggle.isOn = true;
        }
        else
        {
            HardcoreOnOrOff.text = "OFF";
            HardcoreToggle.isOn = false;
        }

        if (RealLanding == true)
        {
            RealLandingOnOrOff.text = "ON";
            RealLandingToggle.isOn = true;
        }
        else
        {
            RealLandingOnOrOff.text = "OFF";
            RealLandingToggle.isOn = false;
        }
    }

    public void HardcoreTogglePressed()
    {
        if (HardcoreMode == true)
        {
            HardcoreMode = false;
            HardcoreOnOrOff.text = "OFF";
        }
        else
        {
            HardcoreMode = true;
            HardcoreOnOrOff.text = "ON";
        }
    }

    public void RealLandingTogglePressed()
    {
        if (RealLanding == true)
        {
            RealLanding = false;
            RealLandingOnOrOff.text = "OFF";
        }
        else
        {
            RealLanding = true;
            RealLandingOnOrOff.text = "ON";
        }
    }
}