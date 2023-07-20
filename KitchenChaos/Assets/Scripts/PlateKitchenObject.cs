using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectsSOList;

    private List<KitchenObjectsSO> kitchenObjectsSOList;

    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectsSO>();
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
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
            return true;
        }
    }
}
