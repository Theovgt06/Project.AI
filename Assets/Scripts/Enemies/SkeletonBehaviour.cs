using System;
using System.Collections;
using System.Linq;
using Unity.Hierarchy;
using Unity.Mathematics;
using UnityEngine;

public class MeleeEnnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float verticalSpeed = 0;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private Vector3 currentTarget;
    [SerializeField] private bool targetIsPlayer = false;
    [SerializeField] private Collider2D spotedPlayerCollider;
    [SerializeField]private bool pausing;
    public Vector3 initialTarget = new Vector3(2,0,0);
    [SerializeField] float optimalAttackDistance = 0.5f;
    private BoxCollider2D visionArea;
    private BoxCollider2D attackRange;
    private Animator animator;
    private Rigidbody2D rb;
    private bool walking = true;
    [SerializeField] private float pauseTime = 1;
    [SerializeField] private bool attacking = false;

    void Start()
    {
        visionArea = transform.GetChild(0).GetComponent<BoxCollider2D>();
        attackRange = transform.GetChild(1).GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentTarget = transform.position + initialTarget;
        if (initialTarget.x < 0) {
            Flip();
        }
        animator.SetTrigger("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking) {
            if (targetIsPlayer) {
                currentTarget = spotedPlayerCollider.transform.position;
                if ((facingRight && transform.position.x > currentTarget.x) ||
                    (!facingRight && transform.position.x < currentTarget.x)) {
                    Flip(); //to face the player
                }
                if (math.abs(currentTarget.x - transform.position.x) < optimalAttackDistance) {
                    print("I'm skelattacking");
                    walking = false;
                    animator.SetTrigger("Attack");
                    attacking = true;
                }
                else if (!walking) {
                    walking = true;
                    animator.SetTrigger("Walk");
                }
            }
            

            if (walking) {
                if (facingRight) {
                    rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
                }
                else {
                    rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
                }
                //si j'ai dépassé ma target 
                if ((facingRight && transform.position.x > currentTarget.x) ||
                    (!facingRight && transform.position.x < currentTarget.x))
                {
                    print("I'm really feeling the skeleboredom");
                    currentTarget = transform.position - initialTarget;
                    walking = false;
                    pausing = true;
                    animator.SetTrigger("Idle");
                    StartCoroutine(PauseWaitCoroutine(pauseTime));
                }
            }
            else { //rester immobile
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
    }

    // Inverser l'orientation du sprite
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        initialTarget *= -1;
    }

    private IEnumerator PauseWaitCoroutine(float timeInSeconds) {
        yield return new WaitForSeconds(timeInSeconds);
        if (pausing) {
            print("No skeletactivity detected");
            Flip();
            if (!walking) {
                walking = true;
                animator.SetTrigger("Walk");
            }
            pausing = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        if (Application.isPlaying) {
            Gizmos.DrawLine(transform.position, currentTarget);
        }
        else {
            Gizmos.DrawLine(transform.position, transform.position + initialTarget);
        }
    }

    internal void SpotPlayer(Collider2D collider)
    {
        print("That's the player!");
        targetIsPlayer = true;
        spotedPlayerCollider = collider;
        pausing = false;
    }

    internal void LosePlayer()
    {
        print("Where player?");
        targetIsPlayer = false;
        spotedPlayerCollider = null;
        currentTarget = transform.position - initialTarget;
        walking = false;
        if (!pausing) {
            pausing = true;
            StartCoroutine(PauseWaitCoroutine(pauseTime));
            animator.SetTrigger("Idle");
        }
    }
}
