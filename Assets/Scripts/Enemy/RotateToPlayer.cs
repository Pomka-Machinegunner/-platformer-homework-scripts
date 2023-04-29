using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] Vector3 _rightEuler;
    [SerializeField] Vector3 _leftEuler;
    Vector3 _targetEuler;
    [SerializeField] float _lerpRate = 5f;

    Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        EnemyRotate();
    }

    void EnemyRotate()
    {
        if (transform.position.x < _playerTransform.position.x)
        {
            _targetEuler = _rightEuler;
        }
        else
        {
            _targetEuler = _leftEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _lerpRate);
    }
}
