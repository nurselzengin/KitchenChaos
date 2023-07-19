using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{

    [SerializeField] CuttingCounter cuttingCounter;
    [SerializeField] Image bar;
    private void Start()
    {
        cuttingCounter.OnProgressBarChanged += CuttingCounter_OnProgressBarChanged;
        bar.fillAmount = 0;
        Hide();
    }

    private void CuttingCounter_OnProgressBarChanged(object sender, CuttingCounter.OnProgressBarChangedEventArgs e)
    {
        bar.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0 || e.progressNormalized == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
