using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back4 : MonoBehaviour
{
    [SerializeField] GameObject Back3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Back3.transform.position, 10f);
        transform.LookAt(Back3.transform);
    }
}
