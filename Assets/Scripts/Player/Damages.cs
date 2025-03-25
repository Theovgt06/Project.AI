using UnityEngine;
using UnityEngine.UI;

public class Damages : MonoBehaviour
{
    
    public int currentHealth; // Sant� actuelle du joueur
    public Slider healthBar; // R�f�rence � la barre de vie (UI)

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazards"))
        {
            GetComponent<healthBar>().TakeDamage(1);
        }
    }
}
