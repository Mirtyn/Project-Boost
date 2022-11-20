using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CollisionHandeler : ProjectBehaviour
{
    [SerializeField] float winOrLoseDelay = 2f;
    [SerializeField] AudioClip winAudioClip;
    [SerializeField] AudioClip loseAudioClip;

    [SerializeField] ParticleSystem winParticle;
    [SerializeField] ParticleSystem loseParticle;

    public TMP_Text WinOrLoseTextOnHud;
    public GameObject GameWonPanel;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool unKilleableOn = false;

    float DeathRotationIndegrees = 22.5f;

    private float ConvertToRadians(float angle)
    {
        return (Mathf.PI / 180f) * angle;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Competetive == false)
        {
            CheckCheatOrDebugKeys();
        }
    }

    void CheckCheatOrDebugKeys()
    {
        CheatCodeLoadNextLevel();
        CheatCodeTogleCollision();
        CheatCodeReloadLevel();
        CheatCodeUnKilleable();
    }

    void CheatCodeLoadNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartNextLevelSequence();
        }
    }

    void CheatCodeTogleCollision()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GetComponent<BoxCollider>().enabled == true)
            {
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
            }
            else
            {
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }

    void CheatCodeReloadLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCrashSequence();
        }
    }

    void CheatCodeUnKilleable()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            unKilleableOn = !unKilleableOn;

            //if (unKilleableOn == false)
            //{
            //    unKilleableOn = true;
            //}
            //else
            //{
            //    unKilleableOn = false;
            //}
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly.");
                break;
            case "Finish":
                StartNextLevelSequence();
                break;
            //case "Fuel":
            //    Debug.Log("You filled up your fuel tank.");
            //    break;
            default:
                if (unKilleableOn == false)
                {
                    StartCrashSequence();
                }
                break;
        }
    }

    void StartNextLevelSequence()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) == SceneManager.sceneCountInBuildSettings)
        {
            GameWon = true;
            TimeWhenWon = Time.time - StartTime;
            WinOrLoseTextOnHud.color = new Color(0, 231, 0, 255);
            WinOrLoseTextOnHud.text = "CONGRATS YOU DID IT!";
            if (Competetive == false)
            {
                isTransitioning = true;
                audioSource.Stop();
                GetComponent<Movement>().enabled = false;
                audioSource.PlayOneShot(winAudioClip);
                winParticle.Play();
                Invoke("LoadSceneWinFreePlay", winOrLoseDelay * 2);
            }
            else
            {
                isTransitioning = true;
                audioSource.Stop();
                GetComponent<Movement>().enabled = false;
                audioSource.PlayOneShot(winAudioClip);
                winParticle.Play();
                Invoke("LoadSceneWinCompetetive", winOrLoseDelay * 2);

                // toon scherm met tijd en submit knop


            }

            return;
        }

        var deathRotationInRadiants = ConvertToRadians(DeathRotationIndegrees);

        if (RealLanding == false || (GetComponent<Transform>().rotation.z < deathRotationInRadiants && GetComponent<Transform>().rotation.z > -deathRotationInRadiants))
        {
            isTransitioning = true;
            audioSource.Stop();
            GetComponent<Movement>().enabled = false;
            audioSource.PlayOneShot(winAudioClip);
            winParticle.Play();
            Invoke("LoadNextLevel", winOrLoseDelay);
        }
        else
        {
            if (unKilleableOn == false)
            {
                StartCrashSequence();
            }
            else
            {
                isTransitioning = true;
                audioSource.Stop();
                GetComponent<Movement>().enabled = false;
                audioSource.PlayOneShot(winAudioClip);
                winParticle.Play();
                Invoke("LoadNextLevel", winOrLoseDelay);
            }
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(loseAudioClip);
        loseParticle.Play();
        if (HardcoreMode == false)
        {
            Invoke("ReloadLevel", winOrLoseDelay);
        }
        else
        {
            WinOrLoseTextOnHud.color = new Color (255, 0, 0, 255);
            WinOrLoseTextOnHud.text = "GAME OVER!";
            Invoke("LoadSceneDeadHardcore", winOrLoseDelay * 2);
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    void LoadSceneDeadHardcore()
    {
        SceneManager.LoadScene(0);
    }

    void LoadSceneWinFreePlay()
    {
        SceneManager.LoadScene(0);
    }

    void LoadSceneWinCompetetive()
    {
        GameWonPanel.SetActive(true);
    }
}