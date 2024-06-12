using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstInput : MonoBehaviour
{
    public float accelInput;
    public float steerInput;

    public virtual void ArtificialUpdate()
    {
        Debug.Log("Cambia el input panflin");
    }
}
