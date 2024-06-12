using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension //PARCIAL 2 - Santiago Postacchini
{
    [Header("Valores de suspension")]
    [Tooltip("Esta es la fuerza del resorte")]
    [SerializeField] public float springStiffness;
    [Tooltip("Esto es como el \"largo\" de la suspension antes de que cualquier fuerza se aplique")]
    [SerializeField] public float suspensionRestDistance;
    [Tooltip("Esto actua como la viscosidad del liquido hidraulico, lo que determina que tan rapido se estabiliza la suspension")]
    [SerializeField] public float damperStiffness;

    public void UpdateSuspentionForce(Transform carTransform, Rigidbody carRigidbody, Transform wheelTransform, RaycastHit tireRay, Transform wheelMesh, float wheelRadius)
    {
        wheelMesh.transform.localPosition = new Vector3(0f, -wheelTransform.position.y * Mathf.Clamp((tireRay.distance - wheelRadius), 0f, suspensionRestDistance), 0f);

        Vector3 springDirection = wheelTransform.up;

        Vector3 tireWorldVel = carRigidbody.GetPointVelocity(wheelTransform.position);

        float offset = suspensionRestDistance - tireRay.distance;

        float vel = Vector3.Dot(springDirection, tireWorldVel);

        float force = (offset * springStiffness) - (vel * damperStiffness);

        carRigidbody.AddForceAtPosition(springDirection * force, wheelTransform.position); //Fuerza en el eje de la suspension
    }
}
