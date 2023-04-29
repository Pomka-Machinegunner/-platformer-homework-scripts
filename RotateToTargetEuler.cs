using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] Vector3 _leftEuler;
    [SerializeField] Vector3 _rightEuler;
    [SerializeField] Vector3 _targetEuler;
    [SerializeField] float _speedRotation = 1f;

    void Update()
    {
        LerpRotator();
    }

    public void RotateLeft()
    {
        _targetEuler = _leftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = _rightEuler;
    }

    void LerpRotator()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _speedRotation);
    }
}
