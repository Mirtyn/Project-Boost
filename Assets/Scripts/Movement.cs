using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ProjectBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1.5f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] ParticleSystem sideLeftThrustParticle;
    [SerializeField] ParticleSystem sideRightThrustParticle;
    [SerializeField] ParticleSystem mainThrustParticle;
    public Transform RocketFollowEmpty;

    // Start is called before the first frame update
    void Start()
    {
        RocketFollowEmpty = this.transform.Find("RocketFollowEmpty");
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        ZoomCam();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad0))
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
        if (transform.rotation.x != 0.0)
        {
            transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }

        if (transform.rotation.y != 0.0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        }

        //bool sideThrusterLeft;
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            StartRotatingLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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

    void ZoomCam()
    {
        RocketFollowEmpty.position += new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * 5.0f);

        if (RocketFollowEmpty.position.z < -100)
        {
            RocketFollowEmpty.position = new Vector3(RocketFollowEmpty.position.x, RocketFollowEmpty.position.y, -100);
        }

        if (RocketFollowEmpty.position.z > 12)
        {
            RocketFollowEmpty.position = new Vector3(RocketFollowEmpty.position.x, RocketFollowEmpty.position.y, 12);
        }

        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{

        //}

        //else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{

        //}
    }
}
