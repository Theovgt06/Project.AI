using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private const int MAX_HEALTH = 5; // Maximum health of the player
    public int currentHealth; // Current health of the player
    public LifeBar lifeBar; // Reference to the life bar (UI)
    private Animator animator; // Reference to the Animator component
    private PlayerInput playerInput;
    public bool invulnerability;
    [SerializeField] private float invulnerabilityTime = 1;
    [SerializeField] private string deathSceneName = "DeathScene"; // Name of the death scene

    private void Start()
    {
        currentHealth = MAX_HEALTH;
        animator = GetComponent<Animator>(); // Get the Animator component
        playerInput = GetComponent<PlayerInput>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("LAMORKITU") && !invulnerability)
        {
            TakeDamage(100000);
        }
    }

    // Method to inflict damage to the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce current health
        animator.SetBool("OVERRIDE", true); //Empèche la plupart des transitions
        if (currentHealth <= 0)
        {
            animator.SetBool("Dead", true);
            currentHealth = 0; // Ensure health does not go negative
            playerInput.enabled = false;
            Debug.Log("Player is dead. Waiting for death animation to finish.");
            StartCoroutine(LoadDeathSceneBeforeAnimationEnds());
        }
        else
        {
            animator.SetBool("Hit", true); // Trigger the Elf_hit animation
            StartCoroutine(InvulnerabilityCoroutine(invulnerabilityTime));
        }
        lifeBar.UpdateHealth(currentHealth); // Update the life bar
    }

    private IEnumerator InvulnerabilityCoroutine(float timeInSeconds)
    {
        invulnerability = true;
        yield return new WaitForSeconds(timeInSeconds);
        invulnerability = false;
        animator.SetBool("Hit", false);
        animator.SetBool("OVERRIDE", false);
    }

    private IEnumerator LoadDeathSceneBeforeAnimationEnds()
    {
        // Wait for the death animation to almost finish (1 second before the end)
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength - 1.0f);
        Debug.Log("Loading death scene 1 second before the animation ends.");
        SceneManager.LoadScene("DeathScene"); // Load the death scene
    }
}
