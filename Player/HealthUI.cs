using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameObject _heartPrefabIcon;
    [SerializeField] List<GameObject> _heartIcon = new List<GameObject>();
    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon =Instantiate(_heartPrefabIcon, transform);
            _heartIcon.Add(newIcon);
        }
    }

    public void Display(int health)
    {
        for (int i = 0; i < _heartIcon.Count; i++)
        {
            if (i< health)
            {
                _heartIcon[i].SetActive(true);
            }
            else
            {
                _heartIcon[i].SetActive(false);
            }
        }
    }
}
