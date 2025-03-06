using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Références")]
    [SerializeField] private Rigidbody2D rb;

    private Vector2 moveDirection;
    private bool isFacingRight = true;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

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

    // ReSharper disable Unity.PerformanceAnalysis
    private void Move()
    {
        // Mouvement avec Rigidbody2D pour une meilleure physique
        if (rb)
        {
            // Option 1: Velocity directe (mouvement plus direct)
            rb.linearVelocity = moveDirection * moveSpeed;

            // Option 2: Force (physique plus réaliste mais plus lente)
            // rb.AddForce(moveDirection * moveSpeed);

            // Option 3: MovePosition (plus précis mais moins d'interactions physiques)
            // Vector2 position = rb.position;
            // position += moveDirection * moveSpeed * Time.fixedDeltaTime;
            // rb.MovePosition(position);
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
}