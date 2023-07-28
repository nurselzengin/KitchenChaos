using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClipRefSO audioClipRefSO;

    public static SoundManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        DeliveryManager.instance.OnRecipeSuccess += Ýnstance_OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed += Ýnstance_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.instance.OnPickedSomething += Ýnstance_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }
    public void PlayerFootStepsSound(Vector3 position, float volume)
    {
        PlaySound(audioClipRefSO.footStep, position, volume);
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipRefSO.trash, trashCounter.transform.position);
        Debug.Log("Trash it");
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipRefSO.objectDrop, baseCounter.transform.position);
        Debug.Log("Drop it");
    }

    private void Ýnstance_OnPickedSomething(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefSO.objectPickUp, Player.instance.transform.position);
        Debug.Log("Pick up");
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRefSO.chop, cuttingCounter.transform.position);
        Debug.Log("Chop Chop");
    }

    private void Ýnstance_OnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefSO.deliveryFailed, deliveryCounter.transform.position);
        Debug.Log("Fail");
    }

    private void Ýnstance_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipRefSO.deliverySuccess, deliveryCounter.transform.position);
        Debug.Log("Success");

    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0,audioClipArray.Length)], position, volume);
    }


}
