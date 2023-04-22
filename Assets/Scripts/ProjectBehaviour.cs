using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ProjectBehaviour : MonoBehaviour
{
    public static float StartTime;
    public static float TimeWhenWon;

    public static bool RealLanding = false;
    public static bool HardcoreMode = false;
    public static bool Competetive = false;
    public static bool GameWon = false;

    public static string PlayerName;

    public static string Version = "Beta 0.3.0";

    public static bool UseAmbientOcclusion = true;
    public static bool UseBloom = true;
    //public static bool UseDepthOfField = true;
    public static bool UseVignette = true;
}
