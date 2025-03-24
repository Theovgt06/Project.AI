using System;
using Unity.Hierarchy;
using UnityEngine;

public class MeleeEnnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool facingRight = true;
    [SerializeField] private Vector3 currentTarget;
    [SerializeField] private bool targetIsPlayer = false;
    public Vector3 initialTarget = new Vector3(2,0,0);
    [SerializeField] float optimalAttackDistance = 0.5f;
    private BoxCollider2D visionArea;
    private BoxCollider2D attackRange;

    void Start()
    {
        visionArea = transform.GetChild(0).GetComponent<BoxCollider2D>();
        attackRange = transform.GetChild(1).GetComponent<BoxCollider2D>();
        currentTarget = transform.position + initialTarget;
        if (initialTarget.x < 0) {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetIsPlayer) {
            if (currentTarget.x - transform.position.x < optimalAttackDistance && facingRight) {
                Attack();
            } 
            else if (transform.position.x - currentTarget.x < optimalAttackDistance && !facingRight){
                Attack();
            }
            else {
                Walk();
            }
        }
        else if (!facingRight) {

        }
        //si j'ai dépassé ma target
        if (currentTarget.x > transform.position.x != facingRight) {
            Flip();

        }
        
    }

    private void Flip()
    {
        // Inverser l'orientation du sprite
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void Attack()
    {
        throw new NotImplementedException();
    }
    
    private void Walk() {
        throw new NotImplementedException();
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
}
