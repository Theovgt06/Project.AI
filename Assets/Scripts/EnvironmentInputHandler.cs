using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnvironmentInputHandler : InputHandler
{
    [SerializeField] private EnvironmentController playerController;
    protected override void RegisterInputActions()
    {
        PlayerInput playerInput = GetPlayerInput();
        if (playerInput != null)
        {
            playerInput.actions["Debug 1"].performed += OnDebug1performed;
            playerInput.actions["Debug 1"].canceled += OnDebug1canceled;
            playerInput.actions["Debug 2"].performed += OnDebug2performed;
            playerInput.actions["Debug 2"].canceled += OnDebug2canceled;
        }
        else
        {
            Debug.LogError("PlayerInput is null in EnvironmentInputHandler");
        }
        // throw new System.NotImplementedException();
    }
    protected override void UnregisterInputActions()
    {
        PlayerInput playerInput = GetPlayerInput();
        if (playerInput != null)
        {
            playerInput.actions["Debug 1"].performed -= OnDebug1performed;
            playerInput.actions["Debug 1"].canceled -= OnDebug1canceled;
            playerInput.actions["Debug 2"].performed -= OnDebug2performed;
            playerInput.actions["Debug 2"].canceled -= OnDebug2canceled;
        }
        else
        {
            Debug.LogError("PlayerInput is null in EnvironmentInputHandler");
        }
        // throw new System.NotImplementedException();
    }

    private void OnDebug1performed(InputAction.CallbackContext context)
    {
        if (playerController != null)
        {
            playerController.Debug1press();
        }
        else
        {
            Debug.LogError("Controller non assigné dans EnvironmentInputHandler");
        }
    }
    private void OnDebug1canceled(InputAction.CallbackContext context)
    {
        if (playerController != null)
        {
            playerController.Debug1release();
        }
        else
        {
            Debug.LogError("Controller non assigné dans EnvironmentInputHandler");
        }
    }
    private void OnDebug2performed(InputAction.CallbackContext context)
    {
        if (playerController != null)
        {
            playerController.Debug2press();
        }
        else
        {
            Debug.LogError("Controller non assigné dans EnvironmentInputHandler");
        }
    }
    private void OnDebug2canceled(InputAction.CallbackContext context)
    {
        if (playerController != null)
        {
            playerController.Debug2release();
        }
        else
        {
            Debug.LogError("Controller non assigné dans EnvironmentInputHandler");
        }
    }
}