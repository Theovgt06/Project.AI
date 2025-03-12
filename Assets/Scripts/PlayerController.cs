using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float initialJumpSpeed = 20f;
    [SerializeField] private float fallAcceleration = 0.5f;
    [SerializeField] private float jumpAcceleration = 0.4f;
    [SerializeField] public float verticalSpeed = 0f;
    [SerializeField] private ContactFilter2D groundContactFilter;
    public bool IsGrounded => rb.IsTouching(groundContactFilter);

    [Header("Références")]
    [SerializeField] private Rigidbody2D rb;
    // [SerializeField] private GroudDetector groundTrigger;
    [SerializeField] private Animator anim;

    CharacterController h;
    private Vector2 moveDirection;
    private bool isFacingRight = true;
    private bool jumping = false;

    private void Start()
    {
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
            if (IsGrounded) {
                verticalSpeed = math.max(0, verticalSpeed);
                if (verticalSpeed == 0) {
                    anim.SetBool("Airborne", false);
                }
            }
            else if (jumping) {
                verticalSpeed -= jumpAcceleration;
            }
            else {
                verticalSpeed -= fallAcceleration;
            }
            rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, verticalSpeed);

            if (moveDirection.x == 0) {
                anim.SetBool("Moving", false);
            }
            else {
                anim.SetBool("Moving", true);
            }
            if (verticalSpeed != 0) {
                anim.SetBool("Airborne", true);
            }
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
        if (IsGrounded) {
        // if (canJump) {
            jumping = true;
            verticalSpeed = initialJumpSpeed;
        }
    }

    internal void JumpEnd()
    {
        jumping = false;
    }
}