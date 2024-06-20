using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public Target mTarget;
    public Transform spawn;
    public Transform target;
    public HomingMissile misil;

    private bool _IsActive;
    private float _recharge = 5f;

    private void Start()
    {
        _IsActive = true;
        StartCoroutine(Shoot(_recharge));
    }

    private void Update()
    {
        transform.LookAt(target);
    }

    private IEnumerator Shoot(float r)
    {
        while (_IsActive)
        {
            yield return new WaitForSeconds(0.002f);
            var newMisil = Instantiate(misil, spawn.position, transform.rotation);
            newMisil.target = mTarget;
            yield return new WaitForSeconds(r);
        }
    }
}
