using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    private float _closeTime = 1f;
    private float _waitTime = 2f;
    private float _openTime = 1.2f;
    private bool _isActive = true;
    private Vector3 _direction = new();

    private Rigidbody _rigidbody;
    public Transform initialPosition;
    public Transform finalPosition;

    private void Start()
    {
        float randomTime = Random.Range(0, 10);
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Doormovement(randomTime));
    }


    private IEnumerator Doormovement(float r)
    {
        _isActive = !_isActive;
        yield return new WaitForSeconds(r);
        _isActive = !_isActive;

        while (_isActive)
        {
            float t = 0;

            _direction = transform.up;

            while (t < 1f)
            {
                t += Time.deltaTime / _closeTime;
                _rigidbody.MovePosition(Vector3.Lerp(finalPosition.position, initialPosition.position, t));
                yield return null;
            }

            yield return new WaitForSeconds(_waitTime);

            t = 0;

            while (t < 1f)
            {
                t += Time.deltaTime / _openTime;
                _rigidbody.MovePosition(Vector3.Lerp(initialPosition.position, finalPosition.position, t));
                yield return null;
            }
            yield return new WaitForSeconds(_waitTime);
        }

    }

}
