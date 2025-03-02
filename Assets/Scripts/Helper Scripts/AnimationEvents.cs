using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();  
        animator = GetComponent<Animator>();
    }

    void ResetShooting()
    {
        playerController.canShoot = true;
    }

    void CameraStartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
