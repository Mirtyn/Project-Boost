using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLvl11Main : MonoBehaviour
{
    [SerializeField] GameObject teleportParticle;
    GameObject player;

    [SerializeField] GameObject Beam1;
    [SerializeField] GameObject Beam2;
    [SerializeField] GameObject Beam3;
    [SerializeField] GameObject Beam4;
    [SerializeField] GameObject Beam5;
    [SerializeField] GameObject Beam6;

    [SerializeField] GameObject Expl1;
    [SerializeField] GameObject Expl2;
    [SerializeField] GameObject Expl3;
    [SerializeField] GameObject Expl4;
    [SerializeField] GameObject Expl5;
    [SerializeField] GameObject Expl6;



    [SerializeField] GameObject[] Lightning;



    [SerializeField] GameObject DesLighn1;
    [SerializeField] GameObject DesLighn2;
    [SerializeField] GameObject DesLighn3;
    [SerializeField] GameObject DesLighn4;
    [SerializeField] GameObject DesLighn5;

    [SerializeField] GameObject Platform;


    [SerializeField] GameObject LeverStick;
    bool triggered = false;

    [SerializeField] GameObject BossHead;

    [SerializeField] GameObject LandingPad;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MyPlayer");

        Invoke(nameof(DeActivateStuff), 0.1f);
    }

    void DeActivateStuff()
    {
        
    }

    public void TriggerLever()
    {
        if (!triggered)
        {
            triggered = true;

            Platform.SetActive(true);

            Instantiate(teleportParticle, player.transform.position, Quaternion.identity);

            Invoke(nameof(teleportPLayer), 0.2f);

            Invoke(nameof(TheBoom), 1f);

            Invoke(nameof(EndLevel), 30f);

            StartCoroutine(LeverMove());
        }
    }

    void teleportPLayer()
    {
        Vector3 playerPos = player.transform.position;
        Quaternion playerRotation = player.transform.rotation;

        Vector3 otherPos = new Vector3(81, 117, 0);

        Rigidbody playerRB = player.GetComponent<Rigidbody>();

        Vector3 teleportPos = otherPos;

        playerRB.velocity /= 2;

        player.transform.position = teleportPos;

        playerPos = player.transform.position;
        Instantiate(teleportParticle, playerPos, Quaternion.identity);
    }

    void TheBoom()
    {
        Beam1.SetActive(false);
        Beam2.SetActive(false);
        Beam3.SetActive(false);
        Beam4.SetActive(false);
        Beam5.SetActive(false);
        Beam6.SetActive(false);

        Expl1.SetActive(true);
        Expl2.SetActive(true);
        Expl3.SetActive(true);
        Expl4.SetActive(true);
        Expl5.SetActive(true);
        Expl6.SetActive(true);

        var i = 0;
        foreach (GameObject _ in Lightning)
        {
            Lightning[i].SetActive(true);
            i++;
        }

        DesLighn1.SetActive(false);
        DesLighn2.SetActive(false);
        DesLighn3.SetActive(false);
        DesLighn4.SetActive(false);
        DesLighn5.SetActive(false);

        Invoke(nameof(StartBoss), 2f);
    }

    IEnumerator LeverMove()
    {
        for (var i = LeverStick.transform.eulerAngles.z; i < 390;)
        {
            i += 0.4f;
            LeverStick.transform.eulerAngles = new Vector3(LeverStick.transform.eulerAngles.x, LeverStick.transform.eulerAngles.y, i);
            yield return new WaitForSeconds(0.00025f);
        }
    }

    void StartBoss()
    {
        BossHead.SetActive(true);
    }

    void EndLevel()
    {
        LandingPad.SetActive(true);
    }
}
