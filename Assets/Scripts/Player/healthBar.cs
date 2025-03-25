using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 5; // Santé maximale du joueur
    public int currentHealth; // Santé actuelle du joueur
    public Slider healthBar; // Référence à la barre de vie (UI)

    // Start est appelé une fois avant la première exécution de Update après la création du MonoBehaviour
    void Start()
    {
        currentHealth = maxHealth; // Initialiser la santé actuelle à la santé maximale
        healthBar.maxValue = maxHealth; // Initialiser la valeur maximale de la barre de vie
        healthBar.value = currentHealth; // Initialiser la valeur actuelle de la barre de vie
        InitializeLife();
    }

    private void InitializeLife()
    {
        currentHealth = maxHealth;
    }

    private void LifeUpdate()
    {
        // Logique de mise à jour de la vie
    }

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

    // Update est appelé une fois par frame
    void Update()
    {
        LifeUpdate();
    }
}