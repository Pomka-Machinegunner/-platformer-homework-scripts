using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform _aimTarget;
    [SerializeField] Transform _gun;
    [SerializeField] Transform _playerEyeL;
    [SerializeField] Transform _playerEyeR;
    [SerializeField] Transform _aim;
    [SerializeField] Camera _playerCamera;

    void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        MoveAim();
        GunMove();
        EyeMove();
    }

    void MoveAim()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        _aim.position = point;
    }

    void EyeMove()
    {
        Vector3 directionL = (_aim.position + new Vector3 (0,0,-15)) - _playerEyeL.position;
        _playerEyeL.rotation = Quaternion.LookRotation(directionL);
        Vector3 directionR = (_aim.position + new Vector3(0, 0, -15)) - _playerEyeR.position;
        _playerEyeR.rotation = Quaternion.LookRotation(directionR);
    }

    void GunMove()
    {
        Vector3 toTarget = _aimTarget.position - _gun.position;
        _gun.rotation = Quaternion.LookRotation(toTarget);
    }
}
