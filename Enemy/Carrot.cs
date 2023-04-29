using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    Transform _playerTransform;
    [SerializeField] float _speed = 3;

    private void Start()
    {
        _playerTransform = FindObjectOfType<HeadTarget>().transform;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * _speed;
    }
}
