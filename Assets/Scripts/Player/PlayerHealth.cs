using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxYealth = 10;
    bool _invulnerable = false;
    [SerializeField] AudioManager _audioManager;
    [SerializeField] HealthUI HealthUI;
    [SerializeField] Image _innerGlow;
    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxYealth);
        HealthUI.Display(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            Health -= damageValue;
            _audioManager.PlayerTakeDamage();
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }
        HealthUI.Display(Health);
        StartCoroutine(InnerGlowAlfaUpper());
        
        _invulnerable = true;
        Invoke("StopInvulnerable",1f);
        EventOnTakeDamage.Invoke();
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void TakeHealth(int healthValue)
    {
        Health += healthValue;
        HealthUI.Display(Health);
        if (Health >= 10)
        {
            Health = 10;
        }
    }

    void Die()
    {
        _audioManager.PlayerDie();
    }

    IEnumerator InnerGlowAlfaUpper()
    {
        for (float t = 1f; t > 0f; t -=Time.deltaTime * 2f)
        {
            _innerGlow.color = new Color(1,0,0,t);
            yield return null;
        }
    }

   
}
