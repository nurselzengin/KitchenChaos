using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] Transform recipeTemplate;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }
    void Start()
    {
        DeliveryManager.instance.OnRecipeComplete += Ưnstance_OnRecipeComplete;
        DeliveryManager.instance.OnRecipeSpawned += Ưnstance_OnRecipeSpawned;
        UpdateVisual();
    }

    private void Ưnstance_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void Ưnstance_OnRecipeComplete(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == recipeTemplate) continue;

            Destroy(child.gameObject);
         
        }
        foreach(RecipeSO resipeSO in DeliveryManager.instance.GetWaitingRecipeSOList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(resipeSO);
        }
    }
    
    
}
