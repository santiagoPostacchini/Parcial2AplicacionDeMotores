using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rueda : MonoBehaviour//, ISlippery //PARCIAL 2 - Santiago Postacchini
{
    [Header("Que rueda soy?")] //Esto diferencia las ruedas traseras de las delanteras (principalmente para diferenciar cuales giran)
    public bool FrontRW;
    public bool FrontLW;
    public bool BackRW;
    public bool BackLW;

    [Header("Componentes")]
    public Transform wheelMesh;
    public Rigidbody carRigidbody;
    public Transform carTransform;

    [Header("Rueda")]
    [Tooltip("Radio de la rueda")]
    public float wheelRadius;
    [Tooltip("Angulo de dirección")]
    public float steerAngle;
    [Tooltip("Delay de giro")]
    public float steerTime;
    [Tooltip("Anglo de dirección actual")]
    public float currentSteerAngle;
    [Tooltip("Masa de la rueda")]
    public float tireMass;
    [Tooltip("Diametro de la rueda")]
    private float wheelDiameter;

    Motor _motor;
    Suspension _suspension;
    Deslizamiento _deslizamiento;

    private void Start()
    {
        wheelDiameter = 2 * wheelRadius;

        _motor = new Motor();
        _deslizamiento = new Deslizamiento();
        _suspension = new Suspension();
    }

    public void UpdateWheelAngle(float wheelBase, float rearTrack, float turnRadius, float steerInput)
    {
        if (FrontRW)
        {
            if (steerInput > 0) //Giro Derecha
            {
                steerAngle = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            }
            else if (steerInput < 0) //Giro Izquierda
            {
                steerAngle = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            }
            else //No giro
            {
                steerAngle = 0;
            }
        }
        else if (FrontLW)
        {
            if (steerInput > 0) //Giro Derecha
            {
                steerAngle = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            }
            else if (steerInput < 0) //Giro Izquierda
            {
                steerAngle = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;

            }
            else //No giro
            {
                steerAngle = 0;
            }
        }

        currentSteerAngle = Mathf.Lerp(currentSteerAngle, steerAngle, steerTime * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(Vector3.up * currentSteerAngle);
    }

    public void UpdateWheelPhysics(float accelInput)
    {
        Ray ray = new Ray(transform.position, -transform.up);

        var rayDidHit = Physics.Raycast(ray, out RaycastHit tireRay, _suspension.suspensionRestDistance + wheelRadius);

        if (rayDidHit)
        {
            _suspension.UpdateSuspentionForce(carTransform, carRigidbody, transform, tireRay, wheelMesh, wheelRadius);

            _deslizamiento.UpdateFrictionForce(carTransform, carRigidbody, transform, tireMass);

            _motor.UpdateMotorForce(carTransform, carRigidbody, transform, wheelMesh, accelInput, wheelDiameter);
        }

    }

    //public void Spin(float spinForce, float timeToStop)
    //{
    //    foreach (var wheel in wheels)
    //    {
    //        wheel.StartLowGrip(timeToStop);
    //        Debug.Log($"Added {timeToStop} of low grip");
    //        if (wheel.BackLW || wheel.BackRW)
    //        {
    //            carRigidBody.AddForceAtPosition(new Vector3(spinForce, 0, 0), wheel.transform.position);
    //            Debug.Log($"Added {spinForce} of force");
    //        }
    //        if (wheel.FrontLW || wheel.FrontRW)
    //        {
    //            carRigidBody.AddForceAtPosition(new Vector3(-spinForce, 0, 0), wheel.transform.position);
    //            Debug.Log($"Added {-spinForce} of force");
    //        }

    //    }
    //}

    //esto va en efectos (creo)

    /*
    public void StartSlowSpeed(float SlowedTime, float WaitTime)
    {
        StartCoroutine(SlowerSpeed(SlowedTime, WaitTime));
    }
    private IEnumerator SlowerSpeed(float SlowedTime, float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        float originalTopSpeed = carTopSpeed;
        //float originalReverseTopSpeed = carReverseTopSpeed;

        carTopSpeed = 4;
        Debug.Log("Baje la velociadad");
        yield return new WaitForSeconds(SlowedTime);

        float tlw = 0;

        while (tlw < 3f)
        {
            Debug.Log("Esta subiendo la velocidad");
            tlw += Time.deltaTime / 2;
            carTopSpeed = Mathf.Lerp(carTopSpeed, originalTopSpeed, tlw);
            yield return null;
        }
    }
    public void StartLowGrip(float t)
    {
        StartCoroutine(LowGrip(t));
    }

    private IEnumerator LowGrip(float t)
    {
        oilLeftTime += t;

        tireGripFactor = 0.01f;

        yield return new WaitForSeconds(oilLeftTime);

        float tlw = 0;

        while (tlw < 1f)
        {
            tlw += Time.deltaTime / 2f;
            tireGripFactor = Mathf.Lerp(tireGripFactor, originalGrip, tlw);
            yield return null;
        }
        oilLeftTime = 0f;
    }
    */



}