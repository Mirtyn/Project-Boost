using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLvl10 : MonoBehaviour
{
    [SerializeField] GameObject OpenDoor;

    [SerializeField] GameObject LeverStick;
    bool triggered = false;

    public void TriggerLever()
    {
        if (!triggered)
        {
            triggered = true;
            OpenDoor.GetComponent<Oscillator>().enabled = true;

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
