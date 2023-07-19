using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] StoveCounter stoveCounter;
    [SerializeField] GameObject stoveOnGameObject, particlesGameObjects;


    void Start()
    {
        stoveCounter.OnStateChange += StoveCounter_OnStateChange;
    }

    private void StoveCounter_OnStateChange(object sender, StoveCounter.OnStateChangeEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Burn || e.state == StoveCounter.State.Idle;

        stoveOnGameObject.SetActive(!showVisual);
        particlesGameObjects.SetActive(!showVisual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
