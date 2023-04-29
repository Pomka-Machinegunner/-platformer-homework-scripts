using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    Transform _playerTransform;
    [SerializeField] float _speed = 3;
    [SerializeField] float _timeToReachSpeed = 2;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / _timeToReachSpeed;

        _rigidbody.AddForce(force);
    }
}
