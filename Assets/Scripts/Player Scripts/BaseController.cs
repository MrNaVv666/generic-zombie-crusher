using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;
    public AudioClip engine_On_Sound, engine_Off_Sound;

    public float x_speed = 8f;
    public float z_speed = 15f;
    public float accelerated = -15f, slowed = 5f;
    public float low_Sound_Pitch, normal_Sound_Pitch, high_Sound_Pitch;

    public bool is_Slow;

    protected float rotationSpeed = 10f;
    protected float maxAngle = 10f;

    private AudioSource soundManager;

    protected void Awake()
    {
        is_Slow = false;
        soundManager = GetComponent<AudioSource>();
        print(speed);
    }

    void Update()
    {
        
    }
    protected void MoveLeft()
    {
        speed = new Vector3(x_speed / 2f, 0f, speed.z);
    }

    protected void MoveRight()
    {
        speed = new Vector3(-x_speed / 2f, 0f, speed.z);
    }

    protected void MoveForward()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void ChangeMoveNormal()
    {
        if (is_Slow)
        {
            is_Slow = false;

            //soundManager.Stop();
            //soundManager.clip = engine_On_Sound;
            //soundManager.volume = 0.3f;
            //soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, -z_speed);
        Debug.Log("elo");
    }

    protected void ChangeMoveSlow()
    {
        if (!is_Slow)
        {
            is_Slow = true;

            //soundManager.Stop();
            //soundManager.clip = engine_Off_Sound;
            //soundManager.volume = 0.5f;
            //soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, -slowed);
    }

    protected void ChangeMoveFast()
    {
        speed = new Vector3(speed.x, 0f, accelerated);
    }
}
