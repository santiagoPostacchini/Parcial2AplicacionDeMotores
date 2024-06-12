using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor //PARCIAL 2 - Santiago Postacchini
{
    [Header("Motor")]
    [Tooltip("Maximo de velocidad del auto")]
    public float carTopSpeed = 10f;
    [Tooltip("Maximo de velocidad del auto en reversa")]
    public float carReverseTopSpeed = -5f;
    [Tooltip("Esto es un valor para escalar la cantidad de efecto freno-motor que se va a aplicar al dejar de acelerar")]
    public float engineBrake = 2f; 
    

    public void UpdateMotorForce(Transform carTransform, Rigidbody carRigidbody, Transform wheelTransform, Transform wheelMesh, float accelInput, float wheelDiameter, AnimationCurve powerCurve, AnimationCurve brakeCurve)
    {
        //Debug.Log("Motor engage");
        Vector3 accelDir = wheelTransform.right;

        Vector3 brakeDir = -wheelTransform.right;

        if (accelInput > 0.0f)
        {
            float carSpeed = Vector3.Dot(carTransform.forward, carRigidbody.velocity);

            float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / carTopSpeed);

            float rpm = carSpeed / (2 * wheelDiameter);

            wheelMesh.Rotate(0, 0, -2 * (rpm / 60 * 360) * Time.fixedDeltaTime);

            float availableTorque = powerCurve.Evaluate(normalizedSpeed) * accelInput;

            carRigidbody.AddForceAtPosition(accelDir * availableTorque, wheelTransform.position);

        }
        else if (accelInput < 0.0f)
        {
            float carSpeed = Vector3.Dot(carTransform.forward, carRigidbody.velocity);

            float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / carReverseTopSpeed);

            float rpm = carSpeed / (2 * wheelDiameter);

            wheelMesh.Rotate(0, 0, 2 * (rpm / 60 * 360) * Time.fixedDeltaTime);

            float availableTorque = brakeCurve.Evaluate(normalizedSpeed) * accelInput;

            carRigidbody.AddForceAtPosition(brakeDir * -availableTorque, wheelTransform.position);
        }
        else
        {
            float carSpeed = Vector3.Dot(carTransform.forward, carRigidbody.velocity);
            if (carSpeed > 0.0f)
            {
                carRigidbody.AddForceAtPosition(brakeDir * engineBrake, wheelTransform.position);
            }
        }
    }
}
