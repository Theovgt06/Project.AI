using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float initialJumpSpeed = 20f;
    [SerializeField] private float fallAcceleration = 0.8f;
    [SerializeField] private float jumpAcceleration = 0.4f;
    [SerializeField] public float verticalSpeed = 0f;
    [SerializeField] private float fallSpeedCap = 30f;
    [SerializeField] private ContactFilter2D groundContactFilter;
    public bool IsGrounded => rb.IsTouching(groundContactFilter);

    [Header("Références")]
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private float attackDuration = 1f; // Duration of the attack animation

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDirection;
    private bool isFacingRight = true;
    private bool jumpKey = false;
    private bool canAttack = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Récupérer le PlayerInput et l'enregistrer auprès de l'InputManager
        PlayerInput playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            if (InputManagerScript.Instance != null)
            {
                InputManagerScript.Instance.SetPlayerInput(playerInput);
            }
            else
            {
                Debug.LogError("InputManager is not in the scene");
            }
        }
        else
        {
            Debug.LogError("Missing PlayerInput on GameObject");
        }
    }

    public void SetMoveDirection(Vector2 direction)
    {
        direction.y = 0;
        moveDirection = direction;

        // Gestion de l'orientation du sprite
        if (direction.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        // On utilise FixedUpdate pour le mouvement physique
        Move();
    }

    private void Move()
    {
        // Mouvement avec Rigidbody2D pour une meilleure physique
        if (rb)
        {
            // print(IsGrounded);
            if (IsGrounded)
            {
                // verticalSpeed = math.max(0, verticalSpeed);
                if (verticalSpeed < 0)
                {
                    verticalSpeed = 0;
                    // print("test");
                    anim.SetTrigger("Landing");
                    anim.SetBool("Airborne", false);
                }
            }
            else
            {
                anim.SetBool("Airborne", true);
                if (jumpKey)
                {
                    verticalSpeed -= jumpAcceleration;
                }
                else
                {
                    verticalSpeed -= fallAcceleration;
                }
                verticalSpeed = math.max(verticalSpeed, -fallSpeedCap);

            }
            anim.SetBool("Moving", moveDirection.x != 0);
            anim.SetFloat("VerticalSpeed", verticalSpeed);

            rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, verticalSpeed);
        }
        else
        {
            Debug.LogError("Rigidbody2D is missing on PlayerController");
        }
    }

    private void Flip()
    {
        // Inverser l'orientation du sprite
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    internal void JumpStart()
    {
        if (IsGrounded)
        {
            jumpKey = true;
            verticalSpeed = initialJumpSpeed;
            anim.SetTrigger("Jumping");
        }
    }

    internal void JumpEnd()
    {
        //increases the downward acceleration once the jump button is released to jump lower
        jumpKey = false;
    }

    internal void AttackStart()
    {
        if (canAttack)
        {
            if (attackPrefab != null)
            {
                canAttack = false;
                Instantiate(attackPrefab, transform);
                anim.SetTrigger("Attack"); // Trigger the attack animation
                anim.SetBool("OVERRIDE", true); // Set OVERRIDE to true
                print("J'attaque! ^^");
                StartCoroutine(ResetOverrideAfterAnimation(attackDuration));
            }
            else
            {
                Debug.LogError("attackPrefab is not assigned in PlayerController");
            }
        }
    }

    private IEnumerator ResetOverrideAfterAnimation(float duration)
    {
        // Wait for the attack animation to finish
        yield return new WaitForSeconds(duration);
        anim.SetBool("OVERRIDE", false); // Set OVERRIDE to false
        canAttack = true; // Allow attacking again
    }
}
