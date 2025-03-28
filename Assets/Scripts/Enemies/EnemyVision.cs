using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private MeleeEnnemy parentScript;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            parentScript.SpotPlayer(collision.GetComponent<Collider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            parentScript.LosePlayer();
        }
    }
}
