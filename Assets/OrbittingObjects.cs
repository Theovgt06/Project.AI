using UnityEngine;

public class OrbitingObjects : MonoBehaviour
{
    public Transform centerPoint;
    public int numberOfObjects = 4;
    public float radius = 2f;
    public GameObject orbitingPrefab;

    private GameObject[] orbitingObjects;
    private float[] angles;

    void Start()
    {
        // Initialiser le tableau d'objets
        orbitingObjects = new GameObject[numberOfObjects];
        angles = new float[numberOfObjects];

        // Créer les objets en orbite
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Calculer l'angle de départ réparti sur 360 degrés
            angles[i] = i * (360f / numberOfObjects);

            // Calculer la position initiale
            float x = centerPoint.position.x + radius * Mathf.Cos(angles[i] * Mathf.Deg2Rad);
            float y = centerPoint.position.y + radius * Mathf.Sin(angles[i] * Mathf.Deg2Rad);

            // Créer l'objet
            orbitingObjects[i] = Instantiate(orbitingPrefab, new Vector3(x, y, 0), Quaternion.identity);
            orbitingObjects[i].name = "Orbiter_" + i;
            Orbiter orbiter = orbitingObjects[i].GetComponent<Orbiter>();
            orbiter.centerPoint = centerPoint;
        }
    }

    void Update()
    {
        // // Mettre à jour la position des objets
        // for (int i = 0; i < numberOfObjects; i++)
        // {
        //     // Mise à jour de l'angle
        //     angles[i] += orbitSpeed * Time.deltaTime;

        //     // Calculer la nouvelle position
        //     float x = centerPoint.position.x + radius * Mathf.Cos(angles[i] * Mathf.Deg2Rad);
        //     float y = centerPoint.position.y + radius * Mathf.Sin(angles[i] * Mathf.Deg2Rad);

        //     // Appliquer la position
        //     orbitingObjects[i].transform.position = new Vector3(x, y, 0);

        //     // Faire pivoter l'objet pour qu'il pointe dans la direction du mouvement
        //     float angle = angles[i] + 90;  // +90 pour pointer vers le centre
        //     orbitingObjects[i].transform.rotation = Quaternion.Euler(0, 0, angle);
        // }
    }
}