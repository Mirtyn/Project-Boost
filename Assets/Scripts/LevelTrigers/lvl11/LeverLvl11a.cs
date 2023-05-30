using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLvl11a : MonoBehaviour
{
    [SerializeField] GameObject OpenPortal;
    [SerializeField] GameObject OpenParticles;
    [SerializeField] GameObject OpenLight;

    [SerializeField] GameObject LeverStick;
    bool triggered = false;

    void Start()
    {
        Invoke(nameof(DeActivateStuff), 0.1f);
    }

    void DeActivateStuff()
    {
        OpenPortal.SetActive(false);
        OpenParticles.SetActive(false);
        OpenLight.SetActive(false);
    }

    public void TriggerLever()
    {
        if (!triggered)
        {
            triggered = true;
            OpenPortal.SetActive(true);
            OpenParticles.SetActive(true);
            OpenLight.SetActive(true);

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
