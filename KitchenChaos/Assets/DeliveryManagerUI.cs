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
        DeliveryManager.instance.OnRecipeComplete += Ýnstance_OnRecipeComplete;
        DeliveryManager.instance.OnRecipeSpawned += Ýnstance_OnRecipeSpawned;
        UpdateVisual();
    }

    private void Ýnstance_OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void Ýnstance_OnRecipeComplete(object sender, System.EventArgs e)
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
