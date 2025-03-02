using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Animator animator;

    public void MainMenuPlay()
    {
        animator.Play("CameraSlide");
    }
}
