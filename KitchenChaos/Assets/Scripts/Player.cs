using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player instance { get; private set; }

    public event EventHandler<OnSelectedCounterChangeEventArgs> OnSelectedCounterChangeEvent;

    public class OnSelectedCounterChangeEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }
    [SerializeField] Transform kitchenObjectHoldPoint;

    [SerializeField] KitchenObject kitchenObject;

    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    bool isWalking;
    private Vector3 lastInteraction;

    [SerializeField] GameInput gameInput;
    [SerializeField] LayerMask countersLayerMask;
    private BaseCounter selectedCounter;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There is more than one Player instance");
        }
        instance = this;
    }

    private void Start()
    {
        gameInput.OnInteractActions += GameInput_OnInteractActions;
    }
    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }
    private void GameInput_OnInteractActions(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove =  !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
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
            if(raycastHit.transform.TryGetComponent(out BaseCounter baseCounter)) 
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);

                }
            }
            else
            {
                    SetSelectedCounter(null);
            }
            
        }
        else
        {
                SetSelectedCounter(null);


        }
        
    }
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChangeEvent?.Invoke(this, new OnSelectedCounterChangeEventArgs
        {
            selectedCounter = selectedCounter
        });
    }
    public bool IsWalking()
    {
        return isWalking;
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
