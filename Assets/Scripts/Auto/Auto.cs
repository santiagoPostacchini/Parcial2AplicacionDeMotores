using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public abstract class Auto : MonoBehaviour, ISlippery //PARCIAL 2 - Santiago Postacchini
{
    public Rueda[] wheels;
    public Rigidbody rb;
    //public PowerUpHandler _powerUp;
    public AbstInput _input;
    public EffectHandler _effect;
    [Header("Especificaciones del auto")]
    [Tooltip("Base de las ruedas")]
    public float wheelBase;
    [Tooltip("Medida de la vía trasera")]
    public float rearTrack;
    [Tooltip("radio del giro")]
    public float turnRadius;

    public float accelInput;
    public float steerInput;

    private void Start()
    {
        _input = new InputPlayer(accelInput, steerInput, this);
    }

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

    public void RunWheel(float steer, float accel)
    {
        foreach (var wheel in wheels)
        {
            wheel.UpdateWheelAngle(wheelBase, rearTrack, turnRadius, steer);
            wheel.UpdateWheelPhysics(accel);
        }
    }

    public void RotateRB(float steer, float accel)
    {
        foreach (var wheel in wheels)
        {
            wheel.RotateBody(steer, accel);
        }
    }

    private void ResetCar()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
    }

    public IEnumerator LowGrip(float t)
    {
        throw new System.NotImplementedException();
    }

    public void StartLowGrip(float t)
    {
        throw new System.NotImplementedException();
    }
}
