using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "SO/SoundSO")]
public class AudioClipRefSO : ScriptableObject
{
    public AudioClip[] chop;
    public AudioClip[] deliveryFailed;
    public AudioClip[] deliverySuccess;
    public AudioClip[] footStep;
    public AudioClip[] objectDrop;
    public AudioClip[] objectPickUp; 
    public AudioClip[] trash;
    public AudioClip[] warning;
    public AudioClip stoveSizzle;


}
