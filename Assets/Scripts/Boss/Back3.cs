using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back3 : MonoBehaviour
{
    [SerializeField] GameObject Back2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Back2.transform.position, 10f);
        transform.LookAt(Back2.transform);
    }
}
