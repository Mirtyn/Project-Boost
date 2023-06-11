using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillers : MonoBehaviour
{
    [SerializeField] GameObject Lazer;
    GameObject BossHealth;

    [SerializeField] GameObject LeverStick;
    bool triggered = false;

    void Start()
    {
        BossHealth = GameObject.FindGameObjectWithTag("BossHealth");
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
            Lazer.SetActive(true);
            BossHealth.GetComponent<BossHealth>().Health -= 1;

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
