using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject Head;
    [SerializeField] GameObject Back1;
    [SerializeField] GameObject Back2;
    [SerializeField] GameObject Back3;
    [SerializeField] GameObject Back4;
    [SerializeField] GameObject Back5;
    [SerializeField] GameObject Tail;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(StartHead), 0.1f);
        Invoke(nameof(StartBack1), 0.45f);
        Invoke(nameof(StartBack2), 0.8f);
        Invoke(nameof(StartBack3), 1.15f);
        Invoke(nameof(StartBack4), 1.5f);
        Invoke(nameof(StartBack5), 1.85f);
        Invoke(nameof(StartTail), 2.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartHead()
    {
        Head.GetComponent<PathFollower>().enabled = true;
    }

    void StartBack1()
    {
        Back1.GetComponent<PathFollower>().enabled = true;
    }

    void StartBack2()
    {
        Back2.GetComponent<PathFollower>().enabled = true;
    }

    void StartBack3()
    {
        Back3.GetComponent<PathFollower>().enabled = true;
    }

    void StartBack4()
    {
        Back4.GetComponent<PathFollower>().enabled = true;
    }

    void StartBack5()
    {
        Back5.GetComponent<PathFollower>().enabled = true;
    }
    void StartTail()
    {
        Tail.GetComponent<PathFollower>().enabled = true;
    }
}
