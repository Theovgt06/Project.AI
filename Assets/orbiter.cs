using Unity.Mathematics;
using UnityEngine;

public class Orbiter : MonoBehaviour
{

    public Transform centerPoint;
    private float radius = 2f;
    public float orbitSpeed = 150f;
    private float angleActuel = 0f;

    // Update is called once per frame
    void Update()
    {
        // Mise à jour de l'angle, rayon et vitesse
        radius = math.max(math.min((centerPoint.position - transform.position).magnitude, 4f), 1f);
        // orbitSpeed = 150f - radius*15f;
        angleActuel += orbitSpeed * Time.deltaTime;

        // Calculer la nouvelle position
        float x = centerPoint.position.x + radius * Mathf.Cos(angleActuel * Mathf.Deg2Rad);
        float y = centerPoint.position.y + radius * Mathf.Sin(angleActuel * Mathf.Deg2Rad);

        // Appliquer la position
        transform.position = new Vector3(x, y, 0);

        // Faire pivoter l'objet pour qu'il pointe dans la direction du mouvement
        // +90 pour pointer vers le centre
        transform.rotation = Quaternion.Euler(0, 0, angleActuel + 90);
    }
}
