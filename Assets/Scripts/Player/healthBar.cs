using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 5; // Sant� maximale du joueur
    public int currentHealth; // Sant� actuelle du joueur
    public Image[] healthPoints; // R�f�rences aux images des points de vie

  
    void Start()
    {
        currentHealth = maxHealth; // Initialiser la sant� actuelle � la sant� maximale
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
                healthPoints[i].enabled = false; // D�sactiver l'image des life points
            }
        }
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // R�duire la sant� actuelle
        if (currentHealth < 0)
        {
            currentHealth = 0; // pour que la sant� soit pas n�gative
        }
        UpdateHealthUI(); // Mettre � jour l'UI des life points
    }

    // Update est appel� une fois par frame
    void Update()
    {
      
    }
}