using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] Player player;
    private float footStepTimer;
    private float footStepTimerMax = .1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        footStepTimer -= Time.deltaTime;
        if(footStepTimer <0f)
        {
            footStepTimer = footStepTimerMax;
            if (player.IsWalking())
            {
                float volume = 1f;
                SoundManager.instance.PlayerFootStepsSound(player.transform.position, volume);
                Debug.Log("Walking");
            }
        }
    }
}
