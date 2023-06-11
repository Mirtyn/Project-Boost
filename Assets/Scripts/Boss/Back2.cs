using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back2 : MonoBehaviour
{
    [SerializeField] GameObject Back1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Back1.transform.position, 10f);
        transform.LookAt(Back1.transform);
    }
}
