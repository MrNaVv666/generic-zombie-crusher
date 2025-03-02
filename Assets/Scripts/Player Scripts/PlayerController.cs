using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public Transform bullet_StartPoint;
    public GameObject bullet;
    public ParticleSystem shootFX;

    private Animator shootSlider;
    private Rigidbody rb;

    [HideInInspector]
    private bool canShoot;
    void Awake()
    {
        speed = new Vector3(0f, 0f, -z_speed);
        rb = GetComponent<Rigidbody>();
        canShoot = true;
    }

    void Update()
    {
        ControlMovement();
        ChangeRotation();
        ShootingControl();
    }

    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }

    void ControlMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        else if (Input.GetKey(KeyCode.S))
        {
            ChangeMoveSlow();
        }

        else if (Input.GetKey(KeyCode.W))
        {
            ChangeMoveFast();
        }

        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.D)))
        {
            MoveForward();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            ChangeMoveNormal();
        }
    }

    void ChangeRotation()
    {
        if(speed.x > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), rotationSpeed * Time.deltaTime);
        }else if (speed.x < 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), rotationSpeed * Time.deltaTime);
        }else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), rotationSpeed * Time.deltaTime);
        }
    }

    public void ShootingControl()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                GameObject bullett = Instantiate(bullet, bullet_StartPoint.position, Quaternion.identity);
                bullett.GetComponent<BulletScript>().MoveBullet(-2000f);
                shootFX.Play();
                canShoot = false;
            }
        }

        if (Time.timeScale != 0f)
        {
            if(canShoot)
            {
                GameObject bullett = Instantiate(bullet, bullet_StartPoint.position, Quaternion.identity);
                bullett.GetComponent<BulletScript>().MoveBullet(-2000f);
                shootFX.Play();
                canShoot = false;
            }
        }
    }


}
