using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deslizamiento //PARCIAL 2 - Santiago Postacchini
{
    [Tooltip("Factor de agarre de la rueda")]
    public float tireGripFactor;

    public void UpdateFrictionForce(Transform carTransform, Rigidbody carRigidbody, Transform wheelTransform, float tireMass)
    {
        Vector3 tireWorldVel = carRigidbody.GetPointVelocity(wheelTransform.position);

        Vector3 steeringDir = wheelTransform.right;

        float steeringVel = Vector3.Dot(steeringDir, tireWorldVel);

        float desiredVelChange = -steeringVel * tireGripFactor;

        float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

        carRigidbody.AddForceAtPosition(steeringDir * tireMass * desiredAccel, wheelTransform.position); //Fuerza en el eje de la direccion
    }
}
