
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementInputHandler : InputHandler
{
    [SerializeField] private PlayerController playerController;

    private Vector2 moveInput;
    private bool jump;

    protected override void RegisterInputActions()
    {
        PlayerInput playerInput = GetPlayerInput();
        if (playerInput != null)
        {
            playerInput.actions["Move"].performed += OnMovePerformed;
            playerInput.actions["Move"].canceled += OnMoveCanceled;
            
            playerInput.actions["Jump"].performed += OnJumpPerformed;
            playerInput.actions["Jump"].canceled += OnJumpCanceled;

            playerInput.actions["Attack"].performed += OnAttackPerformed;
            playerInput.actions["Attack"].canceled += OnAttackCanceled;

        }
        else
        {
            Debug.LogError("PlayerInput is null in MovementInputHandler");
        }
    }

    private void OnAttackCanceled(InputAction.CallbackContext context)
    {

        throw new NotImplementedException();
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    protected override void UnregisterInputActions()
    {
        PlayerInput playerInput = GetPlayerInput();
        if (playerInput != null)
        {
            playerInput.actions["Move"].performed -= OnMovePerformed;
            playerInput.actions["Move"].canceled -= OnMoveCanceled;
            
            playerInput.actions["Jump"].performed -= OnJumpPerformed;
            playerInput.actions["Jump"].canceled -= OnJumpCanceled;

            playerInput.actions["Attack"].performed -= OnAttackPerformed;
            playerInput.actions["Attack"].canceled -= OnAttackCanceled;
        }
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (playerController != null)
        {
            playerController.SetMoveDirection(moveInput);
        }
        else
        {
            Debug.LogError("PlayerController non assigné dans MovementInputHandler");
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
        if (playerController != null)
        {
            playerController.SetMoveDirection(moveInput);
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context) {
        if (playerController != null)
        {
            playerController.JumpStart();
        }
        else
        {
            Debug.LogError("PlayerController non assigné dans MovementInputHandler");
        }
    }

    private void OnJumpCanceled(InputAction.CallbackContext context)
    {
        if (playerController != null)
        {
            playerController.JumpEnd();
        }
        else
        {
            Debug.LogError("PlayerController non assigné dans MovementInputHandler");
        }
    }
}


