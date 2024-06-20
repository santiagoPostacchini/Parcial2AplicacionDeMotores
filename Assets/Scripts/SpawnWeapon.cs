using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public int racePosition;
    [Tooltip("Objeto a spawnear")]
    public GameObject _arma;
    [Tooltip("Punto de spawn frontal")]
    public GameObject _frontSpawnPoint;
    [Tooltip("Punto de spawn trasero")]
    public GameObject _backSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_arma, _frontSpawnPoint.transform); //Crea el objeto _arma en el punto de spawn de adelante del auto.
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(_arma, _backSpawnPoint.transform); //Crea el objeto _arma en el punto de spawn de atras del auto.
        }
    }
}
