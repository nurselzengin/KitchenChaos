using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameobject;


    void Start()
    {
        Player.instance.OnSelectedCounterChangeEvent += Ưnstance_OnSelectedCounterChangeEvent;
    }

    private void Ưnstance_OnSelectedCounterChangeEvent(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
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
        visualGameobject.SetActive(true);
    }
    private void Hide()
    {
        visualGameobject.SetActive(false);
    }
}
