using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
   // [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject[] visualGameobjectArray;


    void Start()
    {
        Player.instance.OnSelectedCounterChangeEvent += Ýnstance_OnSelectedCounterChangeEvent;
    }

    private void Ýnstance_OnSelectedCounterChangeEvent(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
        if(e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject visualGameObject in visualGameobjectArray)
        {
            visualGameObject.SetActive(true);
        }
        
    }
    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameobjectArray)
        {
            visualGameObject.SetActive(false);
        }
        
    }
}
