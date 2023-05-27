using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTowerBeam : MonoBehaviour
{
    public float intensity = 4.0f;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        intensity += Random.Range(-0.1f, 0.1f);
        mat.SetColor("_EmissionColor", new Color(0.74902f, 0.02353f, 0.0f) * intensity);
    }
}