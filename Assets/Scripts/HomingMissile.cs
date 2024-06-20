using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [Header("RB y Target")]
    [SerializeField] public Rigidbody rb;
    [Tooltip("Referencia al script Target que tienen los targets")]
    [SerializeField] public Target target;

    [Header("Variables Movimiento")]
    [Tooltip("Velocidad de Movimiento")]
    [SerializeField] private float _speed = 15f;
    [Tooltip("Velocidad de Rotacion")]
    [SerializeField] private float _rotateSpeed = 95f;
    //[Tooltip("Timer de aumento de velocidad")]
    //[SerializeField] private int _timer;

    [Header("Variables de prediccion")]
    [Tooltip("Maxima distancia que el misil predice de donde estara el target")]
    [SerializeField] private float _maxDistancePredict = 100f;

    [Tooltip("Minima distancia que el misil predice de donde estara el target")]
    [SerializeField] private float _minDistancePredict = 5f;

    [Tooltip("Tiempo max de la prediccion de posicion del target")]
    [SerializeField] private float _maxTimePrediction = 5f; //predice la posicion que tendra el target dentro de x segundos o menos

    //Vectores de la prediccion de posicion plana y la prediccion con desvio (suma realismo al camino del misil)
    private Vector3 _standardPrediction;
    private Vector3 _deviatedPrediction;

    [Header("Valores de desviacion")]
    [Tooltip("Que tanto se desvia el misil")]
    [SerializeField] private float _deviationAmount = 50f;
    [Tooltip("La velocidad con la que se devia el misil (fuerza de la inercia del misil al girrar)")]
    [SerializeField] private float _deviationSpeed = 2f;

    public float explotionForce = 5000f;
    public float explosionRadious = 150f;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * _speed; //Hace que avance el misil

        float leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, target.transform.position)); //Calcula cuanta distancia debe predecir segun la distancia al target

        PredictMovement(leadTimePercentage);

        AddDeviation(leadTimePercentage);

        RotateRocket();
    }

    private void PredictMovement(float leadTimePercentage)
    {
        var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage); //Que tanto debe predecir la posicion

        _standardPrediction = target.Rb.position + target.Rb.velocity * predictionTime; //Calculo de la posicion predecida
    }

    private void AddDeviation(float leadTimePercentage)
    {
        var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0); //Calculo de la desviacion

        var predictionOffset = transform.TransformDirection(deviation) * _deviationAmount * leadTimePercentage; //Calculo del transform de la desviacion

        _deviatedPrediction = _standardPrediction + predictionOffset; //Suma de la prediccion original mas la desviacion calculada
    }

    private void RotateRocket()
    {
        var heading = _deviatedPrediction - transform.position; //Desviacion de la rotacion

        var rotation = Quaternion.LookRotation(heading); 
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime)); //Rota el cohete
    }
}
