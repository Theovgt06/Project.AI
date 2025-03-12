using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
   public static InputManagerScript Instance { get; private set; }
   // Propriété pour accéder au PlayerInput depuis d'autres systèmes
   [SerializeField] private PlayerInput playerInput;

    // Cherche automatiquement le PlayerInput s'il n'a pas encore été défini
    public PlayerInput CurrentPlayerInput
    {
        get
        {
            // Si le playerInput n'est pas défini, on essaie de le trouver
            if (playerInput == null)
            {
                playerInput = FindFirstObjectByType<PlayerInput>();
                if (playerInput == null)
                {
                    Debug.LogError("Missing PlayerInput in the scene");
                }
            }
            return playerInput;
        }
    }


   private void Awake()
   {
       // Singleton setup
       if (Instance != null && Instance != this)
       {
           Destroy(gameObject);
           return;
       }
      
       Instance = this;
      
       // DontDestroyOnLoad pour qu'il persiste entre les scènes
    //    DontDestroyOnLoad(gameObject);
   }
  
   // Méthode pour définir le PlayerInput quand un joueur est instancié
   public void SetPlayerInput(PlayerInput newPlayerInput)
   {
       playerInput = newPlayerInput;
   }
}