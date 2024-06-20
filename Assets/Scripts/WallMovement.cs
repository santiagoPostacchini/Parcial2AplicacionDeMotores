using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    private float _punchTime = 0.5f;
    private float _stillTime = 3f;
    private float _rechargeTime = 0.6f;
    private bool _isActive = true;
    private Vector3 _direction = new();

    private Rigidbody _rigidbody;
    public Transform initialPosition;
    public Transform finalPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Punch());
    }


    private IEnumerator Punch()
    {
        while (_isActive)
        {
            float t = 0;

            _direction = transform.right;

            while (t < 1f)
            {
                t += Time.deltaTime / _punchTime;
                _rigidbody.MovePosition(Vector3.Lerp(initialPosition.position, finalPosition.position, t));
                yield return null;
            }

            yield return new WaitForSeconds(_stillTime);

            t = 0;

            while (t < 1f)
            {
                t += Time.deltaTime / _rechargeTime;
                _rigidbody.MovePosition(Vector3.Lerp(finalPosition.position, initialPosition.position, t));
                yield return null;
            }
            yield return new WaitForSeconds(_stillTime);
        }

    }


}
