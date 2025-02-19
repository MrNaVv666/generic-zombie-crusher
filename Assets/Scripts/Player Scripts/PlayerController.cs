using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Rigidbody rb;
    void Awake()
    {
        speed = new Vector3(0f, 0f, -z_speed);
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        ControlMovement();
        ChangeRotation();
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
}
