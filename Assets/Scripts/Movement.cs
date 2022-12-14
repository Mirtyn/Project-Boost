using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ProjectBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] ParticleSystem sideLeftThrustParticle;
    [SerializeField] ParticleSystem sideRightThrustParticle;
    [SerializeField] ParticleSystem mainThrustParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }

        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if (!mainThrustParticle.isPlaying)
        {
            mainThrustParticle.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainThrustParticle.Stop();
    }

    void ProcessRotation()
    {
        //bool sideThrusterLeft;
        if (Input.GetKey(KeyCode.Q))
        {
            StartRotatingLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartRotatingRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StartRotatingLeft()
    {
        //sideThrusterLeft = false;
        ApplyRotation(rotationThrust);
        if (!sideRightThrustParticle.isPlaying)
        {
            sideRightThrustParticle.Play();
        }
    }

    private void StartRotatingRight()
    {
        //sideThrusterLeft = true;
        ApplyRotation(-rotationThrust);
        if (!sideLeftThrustParticle.isPlaying)
        {
            sideLeftThrustParticle.Play();
        }
    }

    private void StopRotating()
    {
        sideRightThrustParticle.Stop();
        sideLeftThrustParticle.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        //if (sideThrust)
        //{
        //    sideLeftThrustParticle.Play();
        //}
        //else
        //{
        //    sideRightThrustParticle.Play();
        //}
        rb.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation so the physics system can take over
    }
}
