using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] EnemyHealth _enemyHealth;
    [SerializeField] bool _dieOnAnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.TakeDamage(1);
            }
        }
        if (_dieOnAnyCollision)
        {
            if (!other.isTrigger)
            {
                Destroy(gameObject);
            }
        }
    }
}
