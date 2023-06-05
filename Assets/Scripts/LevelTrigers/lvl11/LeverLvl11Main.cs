using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLvl11Main : MonoBehaviour
{
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



    [SerializeField] GameObject Lighn1;
    [SerializeField] GameObject Lighn2;
    [SerializeField] GameObject Lighn3;
    [SerializeField] GameObject Lighn4;
    [SerializeField] GameObject Lighn5;
    [SerializeField] GameObject Lighn6;

    [SerializeField] GameObject Lighn1_1;
    [SerializeField] GameObject Lighn2_1;
    [SerializeField] GameObject Lighn3_1;
    [SerializeField] GameObject Lighn4_1;
    [SerializeField] GameObject Lighn5_1;
    [SerializeField] GameObject Lighn6_1;

    [SerializeField] GameObject Lighn1_2;
    [SerializeField] GameObject Lighn2_2;
    [SerializeField] GameObject Lighn3_2;
    [SerializeField] GameObject Lighn4_2;
    [SerializeField] GameObject Lighn5_2;
    [SerializeField] GameObject Lighn6_2;



    [SerializeField] GameObject DesLighn1;
    [SerializeField] GameObject DesLighn2;
    [SerializeField] GameObject DesLighn3;
    [SerializeField] GameObject DesLighn4;
    [SerializeField] GameObject DesLighn5;


    [SerializeField] GameObject LeverStick;
    bool triggered = false;

    void Start()
    {
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

            Beam1.SetActive(false);
            Beam2.SetActive(false);
            Beam3.SetActive(false);
            Beam4.SetActive(false);
            Beam5.SetActive(false);
            Beam6.SetActive(false);

            DesLighn1.SetActive(false);
            DesLighn2.SetActive(false);
            DesLighn3.SetActive(false);
            DesLighn4.SetActive(false);
            DesLighn5.SetActive(false);

            StartCoroutine(LeverMove());
        }
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
}
