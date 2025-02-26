using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timer = 3f;

    private void Start()
    {
        Invoke("DeactivateObject", timer);
    }

    void DeactivateObject()
    {
        gameObject.SetActive(false);   
    }
}
