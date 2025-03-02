using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();  
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void ResetShooting()
    {
        playerController.canShoot = true;
    }
}
