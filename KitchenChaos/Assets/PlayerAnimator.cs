using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";
    
    [SerializeField] private Player player;
    
    [SerializeField] private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Debug.Log(player.IsWalking());
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
