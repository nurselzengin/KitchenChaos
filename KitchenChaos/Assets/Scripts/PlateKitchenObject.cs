using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    { 
        public KitchenObjectsSO KitchenObjectSO;
    }
    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectsSOList;

    private List<KitchenObjectsSO> kitchenObjectsSOList;
   

    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectsSO>();
    }
    
    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if(!validKitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            return false;
        }
        if (kitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            return false;
        }
        else
        {
            kitchenObjectsSOList.Add(kitchenObjectsSO);
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                KitchenObjectSO = kitchenObjectsSO
            });
            return true;
        }

        
    }

    public List<KitchenObjectsSO> GetKitchenObjectsSOList()
    {
        return kitchenObjectsSOList;
    }
}
