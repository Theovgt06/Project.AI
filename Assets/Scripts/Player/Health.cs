using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private const int MAX_HEALTH = 5; // Maximum health of the player
    public int currentHealth; // Current health of the player
    public LifeBar lifeBar; // Reference to the life bar (UI)
    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        currentHealth = MAX_HEALTH;
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Method to inflict damage to the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health
        if (currentHealth < 0)
        {
            currentHealth = 0; // Ensure health does not go negative
        }
        lifeBar.UpdateHealth(currentHealth); // Update the life bar
        animator.SetTrigger("Elf_hit"); // Trigger the Elf_hit animation
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazards"))
        {
            TakeDamage(1);
        }
    }
}
