using UnityEngine;
using UnityEngine.Events;

public enum Derection
{
    left,
    right
}
public class Walker : MonoBehaviour
{
    [SerializeField] Transform _leftTarget;
    [SerializeField] Transform _rightTarget;
    [SerializeField] Derection _currentDerection;
    [SerializeField] float _speed = 1f;
    [SerializeField] float _stopTime = 1f;
    [SerializeField] bool _isStoped = false;
    [SerializeField] UnityEvent _eventOnLeftTarget;
    [SerializeField] UnityEvent _eventOnRightTarget;
    [SerializeField] Transform _rayStart;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

    private void Update()
    {
        Mover();
    }

    void Mover()
    {
        if (_isStoped) return;
        if (_currentDerection == Derection.left)
        {
            transform.position -= new Vector3 (_speed * Time.deltaTime, 0, 0);
            if (transform.position.x < _leftTarget.position.x)
            {
                _currentDerection = Derection.right;
                _isStoped = true;
                Invoke("StopSwitcher", _stopTime);
                _eventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
            if (transform.position.x > _rightTarget.position.x)
            {
                _currentDerection = Derection.left;
                _isStoped = true;
                Invoke("StopSwitcher", _stopTime);
                _eventOnRightTarget.Invoke();
            }
        }
        RayCaster();
    }

    void StopSwitcher()
    {
        _isStoped = false;
    }

    void RayCaster()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }
}
