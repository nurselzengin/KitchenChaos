using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "SO/RecipeSO")]
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectsSO> kitchenObjectSOList;

    public string RecipeName;
}
