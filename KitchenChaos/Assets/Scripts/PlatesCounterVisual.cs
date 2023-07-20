using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform platesVisual;

    private List<GameObject> platesVisualGameObjectList;

    private void Awake()
    {
        platesVisualGameObjectList = new List<GameObject>();
    }

     void Start()
     {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
       
     }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(platesVisual, topPoint);

        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * platesVisualGameObjectList.Count, 0);

        platesVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = platesVisualGameObjectList[platesVisualGameObjectList.Count - 1];
        platesVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }
}


