using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] KitchenObjectsSO cutKitchenObjectSO;
    [SerializeField] CuttingRecipeSO[] cuttingRecipeSOArray;

    private int cuttingProgress;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInpu(player.GetKitchenObject().GetKitchenObjectsSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }    
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {

            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject() && HasRecipeWithInpu(GetKitchenObject().GetKitchenObjectsSO()))
        {
           
            KitchenObjectsSO outputKitchenObject = GetOutputForInput(GetKitchenObject().GetKitchenObjectsSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(outputKitchenObject, this);
            

        }
    }

    private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputkitchenObjectSO)
    {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputkitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

    private bool HasRecipeWithInpu(KitchenObjectsSO inputkitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputkitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }
}
