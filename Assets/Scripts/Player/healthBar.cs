using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 5; // Santé maximale du joueur
    public int currentHealth; // Santé actuelle du joueur
    public Image[] healthPoints; // Références aux images des points de vie

  
    void Start()
    {
        currentHealth = maxHealth; // Initialiser la santé actuelle à la santé maximale
        InitializeLife();
    }

    private void InitializeLife()
    {
        currentHealth = maxHealth;
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthPoints.Length; i++)
        {
            if (i < currentHealth)
            {
                healthPoints[i].enabled = true; // Activer l'image des life points
            }
            else
            {
                healthPoints[i].enabled = false; // Désactiver l'image des life points
            }
        }
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Réduire la santé actuelle
        if (currentHealth < 0)
        {
            currentHealth = 0; // pour que la santé soit pas négative
        }
        UpdateHealthUI(); // Mettre à jour l'UI des life points
    }

    // Update est appelé une fois par frame
    void Update()
    {
      
    }
}