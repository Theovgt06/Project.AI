using Unity.Hierarchy;
using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private Vector3 target;
    [SerializeField] private bool targetIsPlayer = false;

    public Vector3 initialTarget = new Vector3(2,0,0);
    private BoxCollider2D visionArea;
    void Start()
    {
        visionArea = transform.GetChild(0).GetComponent<BoxCollider2D>();

        target = transform.position + initialTarget;
        if (facingRight) {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target.x > transform.position.x != facingRight) {
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, target);
    }
}
