using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlock : MonoBehaviour
{
    public Transform otherBlock;

    public float halfLength = 100f;

    private Transform player;

    private float endOffset = 10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveGround();
    }

    void MoveGround()
    {
        if (transform.position.z - halfLength > player.transform.position.z + endOffset)
        {
            transform.position = new Vector3(otherBlock.transform.position.x, otherBlock.transform.position.y, otherBlock.transform.position.z - 200f);
        }
    }
}
