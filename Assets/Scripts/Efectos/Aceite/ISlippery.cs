using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlippery
{
    IEnumerator LowGrip(float t);

    void StartLowGrip(float t);
}
