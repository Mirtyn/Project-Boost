using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back5 : MonoBehaviour
{
    [SerializeField] GameObject Back4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Back4.transform.position, 10f);
        transform.LookAt(Back4.transform);
    }
}
