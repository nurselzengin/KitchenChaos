using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager instance { get; private set; }

    
    private enum State
    { 
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver

    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countDownToStartTimer = 3f;
    private float playingToStartTimer = 10f;

    private void Awake()
    {
        instance = this;
        state = State.WaitingToStart;

    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountDownToStart;
                }
                break;
            case State.CountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if (countDownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                playingToStartTimer -= Time.deltaTime;
                if(playingToStartTimer < 0f)
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
}
