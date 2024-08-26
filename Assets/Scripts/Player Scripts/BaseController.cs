using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;
    public float x_speed = 8f, z_speed = 15f;
    public float accelerated = 15f, deccelerated = 10f;
    public float low_sound_pitch, normal_sound_pitch, high_sound_pitch;

    protected float rotationSpeed = 10f;
    protected float max_angle = 10f;

    public AudioClip engine_on_sound, engine_off_sound;
    public AudioSource soundManager;

    private bool is_slow;



    void Awake()
    {
        speed = new Vector3(0f, 0f, z_speed);
        soundManager = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }

    protected void MoveLeft()
    {
        speed = new Vector3(-x_speed / 2f, 0f, speed.z);
    }

    protected void MoveRight()
    {
        speed = new Vector3(x_speed / 2f, 0f, speed.z);
    }

    protected void MoveStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void MoveNormal()
    {
        if (is_slow)
        {
            is_slow = false;

            soundManager.Stop();
            soundManager.clip = engine_on_sound;
            soundManager.volume = 0.3f;
            soundManager.Play();
        }

        speed = new Vector3(speed.x, 0, speed.z);
    }

    protected void MoveSlow()
    {
        if (!is_slow)
        {
            is_slow = true;

            soundManager.Stop();
            soundManager.clip = engine_off_sound;
            soundManager.volume = 0.3f;
            soundManager.Play();
        }

        speed = new Vector3(speed.x, 0, deccelerated);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0, accelerated);
    }
}
