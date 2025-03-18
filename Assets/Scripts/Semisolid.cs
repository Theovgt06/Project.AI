using UnityEngine;

public class Semisolid : MonoBehaviour
{
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 lineEnd = new Vector3(transform.position.x + transform.localScale.x, transform.position.y, transform.position.z);
        Gizmos.DrawLine(transform.position, lineEnd);
    }

}
