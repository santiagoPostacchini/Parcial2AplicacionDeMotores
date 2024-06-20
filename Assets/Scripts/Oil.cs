using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    [Tooltip("Fuerza que se le agregara a las ruedas cuando el auto pase por una mancha de aceite para que gire")]
    public float spinForce;
    [Tooltip("Tiempo que la rueda se mantendrá aceitada")]
    public float oiledTime;
}
