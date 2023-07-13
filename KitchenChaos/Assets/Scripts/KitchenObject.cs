using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO kitchenObjectsSO;
    //private IKitchenObjectParent kitchenObjectParent;

    IKitchenObjectParent kitchenObjectParent;


    public KitchenObjectsSO GetKitchenObjectsSO() 
    {
        return kitchenObjectsSO; 
    
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();

        }
        this.kitchenObjectParent = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.Log("This ClearCounter Has KitchenObject");
        }
        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

   
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return this.kitchenObjectParent;
    }
}
