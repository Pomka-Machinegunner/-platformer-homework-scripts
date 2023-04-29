using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] float _distanceToActivate = 20f;
    bool _isActive = true;
    Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator._objectToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (_isActive)
        {
            if (distance > _distanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < _distanceToActivate)
            {
                Activate();
            }
        }
    }
    void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator._objectToActivate.Remove(this);
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, transform.forward, _distanceToActivate);
    }
#endif
}
