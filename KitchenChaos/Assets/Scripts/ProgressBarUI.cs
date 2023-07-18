using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] CuttingCounter cuttingCounter;
    [SerializeField] Image bar;

    private void Start()
    {
        cuttingCounter.OnProgressBarChange += CuttingCounter_OnProgressBarChange;
        bar.fillAmount = 0;
       

    }

    private void CuttingCounter_OnProgressBarChange(object sender, System.EventArgs e)
    {
        bar.fillAmount = e.progressNormalized;


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
