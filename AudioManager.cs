using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] _revolverClips;
    [SerializeField] AudioSource _revolver;
    [SerializeField] AudioSource _background;

    public void PlayBackground(bool play)
    {
        if (play)
        {
            _background.UnPause();
        }
        else
        {
            _background.Pause();
        }
    }

    public void Shot()
    {
        _revolver.clip = _revolverClips[0];
        _revolver.Play();
    }

    public void ShotThompsonGun()
    {
        _revolver.clip = _revolverClips[8];
        _revolver.Play();
    }

    public void ReloadThompsonGun()
    {
        _revolver.clip = _revolverClips[9];
        _revolver.Play();
    }

    public void BlankShot()
    {
        _revolver.clip = _revolverClips[1];
        _revolver.Play();
    }

    public void Reload()
    {
        StartCoroutine(RelodCorutine());
    }

    IEnumerator RelodCorutine()
    {
        _revolver.clip = _revolverClips[2];
        _revolver.Play();
        yield return new WaitForSeconds(_revolver.clip.length);
        _revolver.clip = _revolverClips[3];
        _revolver.Play();
        yield return new WaitForSeconds(_revolver.clip.length);
        _revolver.clip = _revolverClips[4];
        for (int i = 0; i < 5; i++)
        {
            _revolver.Play();
            yield return new WaitForSeconds(_revolver.clip.length);
        }
        _revolver.clip = _revolverClips[5];
        _revolver.Play();
        yield return new WaitForSeconds(_revolver.clip.length);
        Debug.Log(Time.time);
    }
    public void PlayerTakeDamage()
    {
        _revolver.clip = _revolverClips[6];
        _revolver.Play();
    }

    public void PlayerDie()
    {
        _revolver.clip = _revolverClips[7];
        _revolver.Play();
    }

    public void ChickenTakeDamage()
    {
        _revolver.clip = _revolverClips[8];
        _revolver.Play();
    }
}
