using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeathSceneScript : MonoBehaviour
{
    public Image deathImage; // Reference to the death image

   
    public void ReplayGame()
    {
        // Reload the main game scene
        SceneManager.LoadScene("niveau 1 (en cours)");
    }
}

