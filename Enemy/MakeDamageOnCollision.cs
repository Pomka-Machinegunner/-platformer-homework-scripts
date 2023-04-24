using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    public int DamageValue = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
            }
        }
    }
}
