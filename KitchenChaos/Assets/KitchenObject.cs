using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectsSO kitchenObjectsSO;

    [SerializeField] ClearCounter clearCounter;


    public KitchenObjectsSO GetKitchenObjectsSO() 
    {
        return kitchenObjectsSO; 
    
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();

        }
        this.clearCounter = clearCounter;

        if(clearCounter.HasKitchenObject())
        {
            Debug.Log("This ClearCounter Has KitchenObject");
        }
        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

   
    public ClearCounter GetClearCounter()
    {
        return this.clearCounter;
    }
}
