using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    public Rueda[] wheels;
    public Rigidbody carRigidBody;
    public GameObject detector;

    private void Start()
    {
        detector = transform.Find("Detector").gameObject;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            Debug.Log("Toque misil");
            Explode(collision.gameObject.GetComponent<HomingMissile>().explotionForce, collision.gameObject.GetComponent<HomingMissile>().explosionRadious);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Oil")
        {
            Spin(collision.gameObject.GetComponent<Oil>().spinForce, collision.gameObject.GetComponent<Oil>().oiledTime);
        }

        if (collision.gameObject.tag == "JumpPad")
        {
            Jump(collision.gameObject.GetComponent<JumpPad>().jumpForce);
        }

        if (collision.gameObject.tag == "SpeedPad")
        {
            Speed(collision.gameObject.GetComponent<SpeedPad>().extraForce);
        }
        if (collision.gameObject.tag == "Hammer")
        {
            Debug.Log("Toque el martillo");
            Crushed(collision.gameObject.GetComponent<Hammer>().waitTime, collision.gameObject.GetComponent<Hammer>().slowedTime);
        }
    }

    public void Crushed(float WaitTime, float SlowTime)
    {
        foreach (var wheel in wheels)
        {
            wheel.StartSlowSpeed(SlowTime, WaitTime);
        }
    }
    public void Spin(float spinForce, float timeToStop)
    {
        foreach (var wheel in wheels)
        {
            wheel.StartLowGrip(timeToStop);
            Debug.Log($"Added {timeToStop} of low grip");
            if (wheel.BackLW || wheel.BackRW)
            {
                carRigidBody.AddForceAtPosition(new Vector3(spinForce, 0, 0), wheel.transform.position);
                Debug.Log($"Added {spinForce} of force");
            }
            if (wheel.FrontLW || wheel.FrontRW)
            {
                carRigidBody.AddForceAtPosition(new Vector3(-spinForce, 0, 0), wheel.transform.position);
                Debug.Log($"Added {-spinForce} of force");
            }

        }
    }

    public void Explode(float expForce, float expRadius)
    {
        foreach (var wheel in wheels)
        {
            if (wheel.BackLW || wheel.BackRW)
            {
                carRigidBody.AddForceAtPosition(new Vector3(0, expForce, 0), wheel.transform.position);
                Debug.Log($"Added {expForce} of force");
                Debug.Log($"Exploded");
            }
        }
    }
    public void Jump(float jumpForce)
    {
        foreach (var wheel in wheels)
        {
            carRigidBody.AddForceAtPosition(new Vector3(0, jumpForce, 0), wheel.transform.position);
            Debug.Log($"Added {jumpForce} of jump");
        }
    }

    public void Speed(float extraForce)
    {
        foreach (var wheel in wheels)
        {
            carRigidBody.AddForceAtPosition(new Vector3(0, 0, extraForce), wheel.transform.position);
            Debug.Log($"Added {extraForce} of speed");
        }
    }*/
}