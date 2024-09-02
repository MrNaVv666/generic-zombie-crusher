using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControlMovementWithKeyboard();
    }

    void FixedUpdate()
    {
        MoveTank();
        ChangeRotation();
    }

    void MoveTank()
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
        {
            MoveStraight();
        }
    }

    void ChangeRotation()
    {
        if(speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, max_angle, 0f), Time.deltaTime * rotationSpeed);
        } else if(speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -max_angle, 0f), Time.deltaTime * rotationSpeed);
        } else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }
}
