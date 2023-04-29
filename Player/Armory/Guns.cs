using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public AudioManager AudioManager;
    [SerializeField] GameObject _shootBulletPrefab;
    [SerializeField] GameObject _shootEffectPrefab;
    [SerializeField] Transform _spawnBullet;
    [SerializeField] int _bulletSpeed;
    public int NumberOfBullets;
    public float ShootPeriod;
    public float Timer;
    public int BulletCount = 6;
    public int ShootCount = 0;
    public Animator[] _shotAnim;
    public ParticleSystem _shotParticles;


    void Start()
    {

    }

    void Update()
    {
        Shoot();
    }

    public virtual void Shoot()
    {
        Timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && ShootCount < BulletCount && Timer >= ShootPeriod)
        {
            NumberOfBullets -= 1;
            _shotAnim[1].SetTrigger("Shot");
            _shootEffectPrefab.SetActive(true);
            GameObject newBulet = Instantiate(_shootBulletPrefab, _spawnBullet.position, _spawnBullet.rotation);
            newBulet.GetComponent<Rigidbody>().velocity = _spawnBullet.forward * _bulletSpeed;
            ShootCount++;   
            Invoke("HideFlash",0.1f);
            Timer = 0;
            _shotParticles.Play();
        }
    }

    void HideFlash()
    {
        _shootEffectPrefab.SetActive(false);
    }
    
    public virtual IEnumerator RevolverReloadCorutine()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _shotAnim[0].SetTrigger("Reloded");
            AudioManager.Reload();
            ShootCount = 6;
            yield return new WaitForSeconds(7f);
            ShootCount = 0;
        }
    }
    
    public virtual IEnumerator ThompsonGunReloadCorutine()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _shotAnim[2].SetTrigger("ReloadThompsonGun");
            AudioManager.ReloadThompsonGun();
            ShootCount = 50;
            yield return new WaitForSeconds(1f);
            ShootCount = 0;
        }
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets (int numberOfBullets)
    {

    }
}
