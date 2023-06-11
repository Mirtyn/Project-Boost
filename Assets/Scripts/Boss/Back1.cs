using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back1 : MonoBehaviour
{
    [SerializeField] GameObject Head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Head.transform.position, 10f);
        transform.LookAt(Head.transform);
    }
}
