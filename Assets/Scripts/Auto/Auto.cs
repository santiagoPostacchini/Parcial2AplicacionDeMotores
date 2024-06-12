using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Auto : MonoBehaviour //PARCIAL 2 - Santiago Postacchini
{
    public Rueda[] wheels;
    public Rigidbody rb;
    //public PowerUpHandler _powerUp;
    protected AbstInput _input;
    public EffectHandler _effect;
    [Header("Especificaciones del auto")]
    [Tooltip("Base de las ruedas")]
    public float wheelBase;
    [Tooltip("Medida de la vía trasera")]
    public float rearTrack;
    [Tooltip("radio del giro")]
    public float turnRadius;

    private void Update()
    {
        _input.ArtificialUpdate();
    }

    private void FixedUpdate()
    {
        foreach (var wheel in wheels)
        {
            wheel.UpdateWheelAngle(wheelBase, rearTrack, turnRadius, _input.steerInput);
            wheel.UpdateWheelPhysics(_input.accelInput);
        }
    }

    private void ResetCar()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
    }
}
