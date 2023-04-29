using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour
{
    [SerializeField] Animator _bootsAnimator;
    [SerializeField] float _blandValue;
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] Transform _targetTransfotm;

    private void Update()
    {
        _blandValue = Mathf.Abs(_playerRigidbody.velocity.x / 9);
        _bootsAnimator.SetFloat("Blend", _blandValue);
        _bootsAnimator.speed = _blandValue;

        transform.position = _targetTransfotm.position;
        transform.rotation = _targetTransfotm.rotation;
    }
}
