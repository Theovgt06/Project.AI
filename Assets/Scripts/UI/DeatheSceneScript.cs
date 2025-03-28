using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeathSceneScript : MonoBehaviour
{
    public Image deathImage; // Reference to the death image

    private void Start()
    {
        // Ensure the image is fullscreen
        RectTransform deathImageRectTransform = deathImage.GetComponent<RectTransform>();
        RectTransform rectTransform = deathImageRectTransform;
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1920, 1080);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }

    public void ReplayGame()
    {
        // Reload the main game scene
        SceneManager.LoadScene("niveau 1 (en cours)");
    }
}

