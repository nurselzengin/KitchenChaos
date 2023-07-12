using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "KitchenObjects")] //Odin inspector

public class KitchenObjectsSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}
