using UnityEngine;
using UnityEngine.UI;

public class Damages : MonoBehaviour
{
    
    public int currentHealth; // Santé actuelle du joueur
    public Slider healthBar; // Référence à la barre de vie (UI)

    // Méthode pour infliger des dégâts au joueur
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Réduire la santé actuelle
        if (currentHealth < 0)
        {
            currentHealth = 0; // S'assurer que la santé ne soit pas négative
        }
        healthBar.value = currentHealth; // Mettre à jour la barre de vie
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazards"))
        {
            GetComponent<healthBar>().TakeDamage(1);
        }
    }
}
