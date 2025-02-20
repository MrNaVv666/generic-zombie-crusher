using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveBullet(float speed)
    {
        rb.AddForce(transform.forward.normalized * speed);
        Invoke("DeactivateBullet", 5f);
    }

    void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
        }
    }
}
