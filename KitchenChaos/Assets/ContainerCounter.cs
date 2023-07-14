using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter

{

    [SerializeField] KitchenObjectsSO kitchenObjectsSO;
    public event EventHandler OnPlayerGrabbedObject;


    public override void Interact(Player player)
    {   
           if (!player.HasKitchenObject())
           {

                Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab);

                kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);

           }
        

        
           
    }

}
