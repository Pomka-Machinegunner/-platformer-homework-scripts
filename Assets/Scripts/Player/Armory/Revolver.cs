using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Guns
{
    Coroutine _currentCorutine;
    public override void Shoot()
    {
        base.Shoot();
        if (Input.GetMouseButtonDown(0) && ShootCount < BulletCount)
        {
            AudioManager.Shot();
            _shotAnim[0].SetTrigger("Shot");
        }
        if (Input.GetMouseButtonDown(0) && ShootCount >= BulletCount)
        {
            _shotAnim[0].SetTrigger("BlankShot");
            AudioManager.BlankShot();
        }
        if (_currentCorutine != null)
        {
            StopCoroutine(RevolverReloadCorutine());
        }
        _currentCorutine = StartCoroutine(RevolverReloadCorutine());
        base.StartCoroutine(RevolverReloadCorutine());
        
    }
}
