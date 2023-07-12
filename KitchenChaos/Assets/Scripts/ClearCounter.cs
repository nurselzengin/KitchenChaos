using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearCounter : MonoBehaviour
{

    [SerializeField]  KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] Transform counterTopPoint;
    [SerializeField] KitchenObject kitchenObject;
    [SerializeField] ClearCounter secondClearCounter;
    [SerializeField] bool testing;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T) )
        {
            if (kitchenObjectsSO != null) 
            {
                kitchenObject.SetClearCounter(secondClearCounter);
                //Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);

            //kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);

            //kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();

            //kitchenObject.SetClearCounter(this);

        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
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
