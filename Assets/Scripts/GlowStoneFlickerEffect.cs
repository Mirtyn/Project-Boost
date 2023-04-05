using UnityEngine;
using System.Collections.Generic;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class GlowStoneFlickerEffect : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light Light;
    public new GameObject MatChild1;
    public new GameObject MatChild2;
    public new GameObject MatChild3;
    [Tooltip("Minimum random light intensity")]
    public float LightMinIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float LightMaxIntensity = 1f;
    [Tooltip("Minimum random material intensity")]
    public float MatMinIntensity = 0f;
    [Tooltip("Maximum random material intensity")]
    public float MatMaxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueueLight;
    float lastSumLight = 0;
    Queue<float> smoothQueueMat;
    float lastSumMat = 0;


    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueueLight.Clear();
        lastSumLight = 0;
        smoothQueueMat.Clear();
        lastSumMat = 0;
    }

    void Start()
    {
        smoothQueueLight = new Queue<float>(smoothing);
        smoothQueueMat = new Queue<float>(smoothing);
        // External or internal light?
        if (Light == null)
        {
            Light = GetComponentInChildren<Light>();
        }
    }

    void Update()
    {
        if (Light == null)
            return;

        // pop off an item if too big
        while (smoothQueueLight.Count >= smoothing)
        {
            lastSumLight -= smoothQueueLight.Dequeue();
        }

        while (smoothQueueMat.Count >= smoothing)
        {
            lastSumMat -= smoothQueueMat.Dequeue();
        }

        // Generate random new item, calculate new average
        float newValLight = Random.Range(LightMinIntensity, LightMaxIntensity);
        smoothQueueLight.Enqueue(newValLight);
        lastSumLight += newValLight;

        float newValMat = Random.Range(MatMinIntensity, MatMaxIntensity);
        smoothQueueMat.Enqueue(newValMat);
        lastSumMat += newValMat;

        // Calculate new smoothed average
        Light.intensity = lastSumLight / (float)smoothQueueLight.Count;

        float emissiveIntensity = lastSumMat / (float)smoothQueueMat.Count;
        Color emissiveColor = MatChild1.GetComponent<Renderer>().material.color;

        MatChild1.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
        MatChild2.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
        MatChild3.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
    }
}