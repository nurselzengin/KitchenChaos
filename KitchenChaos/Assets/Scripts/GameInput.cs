using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInput();
        playerInputActions.Player.Enable();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
       

        
    }

    public Vector2 GetMovementVectorNormalize()
    {

        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
