using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private const int MAX_HEALTH = 5; // Sant� maximale du joueur
    public int currentHealth; // Sant� actuelle du joueur
    public LifeBar lifeBar; // R�f�rence � la barre de vie (UI)

    private void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    // M�thode pour infliger des d�g�ts au joueur
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // R�duire la sant� actuelle
        if (currentHealth < 0)
        {
            currentHealth = 0; // S'assurer que la sant� ne soit pas n�gative
        }
        lifeBar.UpdateHealth(currentHealth); // Mettre � jour la barre de vie
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazards"))
        {
            TakeDamage(1);
        }
    }
}
