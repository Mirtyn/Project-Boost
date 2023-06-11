using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazers : MonoBehaviour
{
    GameObject target;
    [SerializeField] GameObject LazerHead;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BossHead");
    }

    
    void Update()
    {
        LazerHead.transform.LookAt(target.transform);
    }
}
