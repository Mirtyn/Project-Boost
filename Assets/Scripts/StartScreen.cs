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
        ToggleStatus(HardcoreMode, HardcoreToggle, HardcoreOnOrOff);
        ToggleStatus(RealLanding, RealLandingToggle, RealLandingOnOrOff);
    }

    public void HardcoreTogglePressed()
    {
        HardcoreMode = !HardcoreMode;

        ToggleStatus(HardcoreMode, HardcoreToggle, HardcoreOnOrOff);
    }

    public void RealLandingTogglePressed()
    {
        RealLanding = !RealLanding;

        ToggleStatus(RealLanding, RealLandingToggle, RealLandingOnOrOff);
    }

    private void ToggleStatus(bool value, Toggle toggle, TMP_Text text)
    {
        toggle.SetIsOnWithoutNotify(value);
        text.text = value ? "ON" : "OFF";
    }
}