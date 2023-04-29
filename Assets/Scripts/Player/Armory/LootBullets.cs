using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] int _gunIndex;
    [SerializeField] int _numberOfbullet;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(_gunIndex, _numberOfbullet);
            Destroy(gameObject);
        }
    }
}
