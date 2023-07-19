using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearCounter : BaseCounter
{

    [SerializeField]  KitchenObjectsSO kitchenObjectsSO;
   
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
           

            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {

            }
        }
        else
        {
            if(player.HasKitchenObject())
            {

            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
