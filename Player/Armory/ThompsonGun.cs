using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThompsonGun : Guns
{
    [Space(10)]
    [Header("ThompsonGun")]
    [SerializeField] TextMeshProUGUI _text;
    Coroutine _currentCorutine;
    [SerializeField] PlayerArmory _playerArmory;

    public override void Shoot()
    {
        base.Shoot();
        if (Input.GetMouseButton(0) && ShootCount < BulletCount)
        {
            AudioManager.ShotThompsonGun();
            _shotAnim[2].SetBool("ShotThompsonGun", true);
        }
        else
        {
            _shotAnim[2].SetBool("ShotThompsonGun", false);
        }
        if (Input.GetMouseButton(0) && ShootCount >= BulletCount)
        {
            AudioManager.BlankShot();
        }
        _text.text = "Пули: " + NumberOfBullets.ToString();
        if (_currentCorutine != null)
        {
            StopCoroutine(ThompsonGunReloadCorutine());
        }
        _currentCorutine = StartCoroutine(ThompsonGunReloadCorutine());
        base.StartCoroutine(ThompsonGunReloadCorutine());
        if (NumberOfBullets == 0)
        {
            _playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        _text.enabled = true;
        base.Activate();
    }

    public override void Deactivate()
    {
        _text.enabled = false;
        base.Deactivate();
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(NumberOfBullets);
        NumberOfBullets += numberOfBullets;
        _text.text = "Пули: " + NumberOfBullets.ToString();
        _playerArmory.TakeGunByIndex(1);
    }
}
