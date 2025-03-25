using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 5; // Sant� maximale du joueur
    public int currentHealth; // Sant� actuelle du joueur
    public Slider healthBar; // R�f�rence � la barre de vie (UI)

    // Start est appel� une fois avant la premi�re ex�cution de Update apr�s la cr�ation du MonoBehaviour
    void Start()
    {
        currentHealth = maxHealth; // Initialiser la sant� actuelle � la sant� maximale
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
        // Logique de mise � jour de la vie
    }

    // M�thode pour infliger des d�g�ts au joueur
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // R�duire la sant� actuelle
        if (currentHealth < 0)
        {
            currentHealth = 0; // S'assurer que la sant� ne soit pas n�gative
        }
        healthBar.value = currentHealth; // Mettre � jour la barre de vie
    }

    // Update est appel� une fois par frame
    void Update()
    {
        LifeUpdate();
    }
}