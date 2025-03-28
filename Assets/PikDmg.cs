using UnityEngine;

public class PikDmg : MonoBehaviour
{
    private Health health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
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
