using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [Header("Componentes")]
    [Tooltip("Transform del auto del jugador al que va a seguir")]
    public Transform targetCar;
    [Tooltip("RigidBody del auto")]
    private Rigidbody _carRB;

    [Header("Settings")]
    [Tooltip("Offset de la camara")]
    public Vector3 offset;
    [Tooltip("Velocidad que va a tener la camara")]
    public float speed = 2f;
    [Tooltip("Posicion final de la camara")]
    private Vector3 _finalCamPos = new();
    
    void Start()
    {
        _carRB = targetCar.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //calcula la direccion en la que se mueve el auto, así diferencia si va para adelante o para atras
        Vector3 carForward = (_carRB.velocity + targetCar.transform.forward).normalized;

        //Calcula la direccion final (aka a la que va a ir) de la camara, el -3 es para que tenga esa distancia hacia atras del auto.
        _finalCamPos = Vector3.Lerp(transform.position, targetCar.position + targetCar.TransformVector(offset) + carForward * (-3f), speed * Time.deltaTime); //para que siempre este viendo hacia su target (el auto) asi si el auto gira, la camara gira para ver en su direccion
        transform.LookAt(targetCar);
        //pasa al posicion antes calculada a la posicion de la camara
        transform.position = _finalCamPos;
    }
}
