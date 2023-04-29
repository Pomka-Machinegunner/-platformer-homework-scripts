using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _rotationSpeed;
    Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = FindObjectOfType<HeadTarget>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        RoketMove();
    }

    void RoketMove()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime *_rotationSpeed);
    }
}
