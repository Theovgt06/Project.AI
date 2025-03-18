using UnityEngine;
using UnityEngine.InputSystem;


public abstract class InputHandler : MonoBehaviour
{
   protected virtual void Start()
   {
       // Vérifier que l'InputManager existe et a un PlayerInput valide
       if (InputManagerScript.Instance != null && InputManagerScript.Instance.CurrentPlayerInput != null)
       {
           // Enregistrer les actions
           RegisterInputActions();
       }
       else
       {
        Debug.LogError($"InputHandler in {gameObject.name} can't be Init: InputManager not find or PlayerInput null");


       }
   }
  
   protected virtual void OnEnable()
   {
       // Si déjà démarré, on s'assure que les actions sont enregistrées
       if (InputManagerScript.Instance != null && InputManagerScript.Instance.CurrentPlayerInput != null)
       {
           RegisterInputActions();
       }
   }
  
   protected virtual void OnDisable()
   {
       // Si l'InputManager existe toujours, on désenregistre nos actions
       if (InputManagerScript.Instance != null && InputManagerScript.Instance.CurrentPlayerInput != null)
       {
           UnregisterInputActions();
       }
   }
  
   // Les méthodes abstraites ne changent pas
   protected abstract void RegisterInputActions();
   protected abstract void UnregisterInputActions();
  
   // Helper pour avoir facilement accès au PlayerInput
   protected PlayerInput GetPlayerInput()
   {
       if (InputManagerScript.Instance != null)
       {
           return InputManagerScript.Instance.CurrentPlayerInput;
       }
       return null;
   }
}
