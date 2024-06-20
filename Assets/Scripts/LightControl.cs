using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightControl : MonoBehaviour
{
    public Animator anim;
    public GameObject leftLight;
    public GameObject rightLight;
    public GameObject leftBlinkLight;
    public GameObject rightBlinkLight;
    public GameObject brakeLightRight;
    public GameObject brakeLightLeft;
    public Rigidbody carRigidbody;
    public Transform carTransform;
    private bool lightOn;

    void Start()
    {
        leftLight.SetActive(false);
        rightLight.SetActive(false);
        leftBlinkLight.SetActive(false);
        rightBlinkLight.SetActive(false);
        lightOn = false;
        anim.SetBool("IsLightOn", lightOn);
    }

    public void turnLights()
    {
        if(lightOn)
        {
            leftLight.SetActive(true);
            rightLight.SetActive(true);
            leftBlinkLight.SetActive(true);
            rightBlinkLight.SetActive(true);
        } if(!lightOn) 
        {
            leftLight.SetActive(false);
            rightLight.SetActive(false);
            leftBlinkLight.SetActive(false);
            rightBlinkLight.SetActive(false);
        }
    }

    void Update()
    {
        float carSpeed = Vector3.Dot(carTransform.forward, carRigidbody.velocity);
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            lightOn = !lightOn;
            anim.SetBool("IsLightOn", lightOn);
        }

        if (Input.GetAxis("Vertical") < 0.0f && carSpeed > 0.0f)
        {
            brakeLightRight.SetActive(true);
            brakeLightLeft.SetActive(true);
        } else 
        {
            brakeLightRight.SetActive(false);
            brakeLightLeft.SetActive(false);
        }
    }
}
