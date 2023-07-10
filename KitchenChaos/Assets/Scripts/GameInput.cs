using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInputActions;
    public event EventHandler OnInteractActions;

    private void Awake()
    {
        playerInputActions = new PlayerInput();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractActions?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalize()
    {

        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        
        inputVector = inputVector.normalized;

        return inputVector;
    }

    
}
