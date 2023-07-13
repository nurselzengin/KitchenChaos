using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearCounter : BaseCounter, IKitchenObjectParent
{

    [SerializeField]  KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] Transform counterTopPoint;
    [SerializeField] KitchenObject kitchenObject;
   
    public override void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);

            //kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

            //kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();

            //kitchenObject.SetClearCounter(this);

        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
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
