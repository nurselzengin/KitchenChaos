using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    bool isWalking;
    private Vector3 lastInteraction;

    [SerializeField] GameInput gameInput;
    [SerializeField] LayerMask countersLayerMask;

    private void Start()
    {
        gameInput.OnInteractActions += GameInput_OnInteractActions;
    }

    private void GameInput_OnInteractActions(object sender, System.EventArgs e)
    {
        Debug.Log("xxx");
    }

    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {

                }
            }

        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
            isWalking = moveDir != Vector3.zero;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);

        }

    }
    
    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
       

        if ( moveDir != Vector3.zero)
        {
            lastInteraction = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteraction, out RaycastHit raycastHit, interactDistance, countersLayerMask)) 
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) 
            {
                Debug.Log("Interact");
            }
            Debug.Log(raycastHit.transform);
        }
        else
        {
            Debug.Log("-");
        }
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}
