using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstInput 
{
    public float accelInput;
    public float steerInput;

    public AbstInput(float accel, float steer)
    {
        accelInput = accel;
        steerInput = steer;
    }
    public virtual void ArtificialUpdate()
    {
        Debug.Log("Cambia el input panflin");
    }

    public virtual void ChangeControl(string name)
    {

    }
}
