using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeComplete;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;   

    public static DeliveryManager instance {  get; private set; }

    [SerializeField] RecipeListSo recipeListSO;

    [SerializeField] private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;

    private int waitingRecipeMax =4;

    
    private void Awake()
    {
        instance = this;

        waitingRecipeSOList = new List<RecipeSO>();
    }

   
    void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer < 0)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;
            if(waitingRecipeSOList.Count < waitingRecipeMax )
            {
                RecipeSO waitingRecipeSO = recipeListSO._recipeSOList[UnityEngine.Random.Range(0, recipeListSO._recipeSOList.Count)];

                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        for(int i = 0; i< waitingRecipeSOList.Count; ++i)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectsSOList().Count)
            {
                bool plateContentMatchesRecipe = true;
                
                foreach(KitchenObjectsSO recipeKitchenObjectsSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    bool ingredientFound = false;

                    foreach (KitchenObjectsSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectsSOList())
                    {
                        if (plateKitchenObjectSO == recipeKitchenObjectsSO)
                        {
                            ingredientFound=true;
                            break;
                        }
                    }
                    if(!ingredientFound)
                    {
                        plateContentMatchesRecipe=false;
                    }
                }
                if(plateContentMatchesRecipe)
                {
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeComplete?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                    
                }

            }

            
        }
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);

        Debug.Log("Player did not delivered the correct recipe");
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }
}
