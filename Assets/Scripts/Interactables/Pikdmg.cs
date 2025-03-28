using UnityEngine;

public class PikDmg : MonoBehaviour
{
    // OnTriggerEnter2D est appel� lorsqu'une collision avec un trigger est d�tect�e
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null && !health.invulnerability)
            {
                health.TakeDamage(1);
            }
        }
    }
}