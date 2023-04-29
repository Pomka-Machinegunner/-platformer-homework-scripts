using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;
    [SerializeField] Collider _player;
    [SerializeField] Collider _hook;
    [SerializeField] RopeGun _ropeGun;

    private void Start()
    {
        Physics.IgnoreCollision(_hook, _player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropeGun.CreateSpring();
        }

    }

    public void StopFix()
    {
        if (_fixedJoint != null)
        {
            Destroy(_fixedJoint);
        }
    }
}
