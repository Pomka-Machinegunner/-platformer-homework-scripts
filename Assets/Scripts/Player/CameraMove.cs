using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _lerpRate;

    void LateUpdate()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position, Time.deltaTime * _lerpRate);
    }
}
