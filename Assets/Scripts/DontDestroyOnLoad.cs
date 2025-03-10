using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private PlayerInput playerInput;
    // Propri�t� pour acc�der au PlayerInput depuis d'autres syst�mes
    // Cherche automatiquement le PlayerInput s'il n'a pas encore �t� d�fini
    public PlayerInput CurrentPlayerInput
    {
        get
        {
            // Si le playerInput n'est pas d�fini, on essaie de le trouver
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

        // DontDestroyOnLoad pour qu'il persiste entre les sc�nes
        DontDestroyOnLoad(gameObject);
    }

    // M�thode pour d�finir le PlayerInput quand un joueur est instanci�
    public void SetPlayerInput(PlayerInput newPlayerInput)
    {
        playerInput = newPlayerInput;
    }
}
