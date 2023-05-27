using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTowerBeam : MonoBehaviour
{
    public float intensity = 80f;
    public float target = 80f;
    //public float speed;
    Material mat;

    public float smoothTime = 0.23f;
    public float yVelocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Smooth towards the height of the target

    

    void Update()
    {
        float newIntensity = Mathf.SmoothDamp(intensity, target, ref yVelocity, smoothTime);
        intensity = newIntensity;
        mat.SetColor("_EmissionColor", new Color(0.74902f, 0.02353f, 0.0f) * intensity);
        if (Mathf.Round(target) == Mathf.Round(intensity))
        {
            target = Mathf.Round(Random.Range(10f, 300f));
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    StartCoroutine(ChangeSpeed(intensity, Random.Range(25f, 400f), 1f));


    //    //float target = 80f;

    //    //float delta = target - intensity;
    //    //delta *= Time.deltaTime;

    //    //intensity += delta;

    //    //if (intensity == target)
    //    //{
    //    //    target = Random.Range(25f, 400f);
    //    //}
        
    //    mat.SetColor("_EmissionColor", new Color(0.74902f, 0.02353f, 0.0f) * intensity);
    //}

    //IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    //{
    //    float elapsed = 0.0f;
    //    while (elapsed < duration)
    //    {
    //        intensity = Mathf.Lerp(v_start, v_end, elapsed / duration);
    //        elapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    intensity = v_end;
    //}
}