
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float destroyTimer = 4f;
    

    void Update()
    {
        if (destroyTimer <= 0)
            Destroy(gameObject);
        destroyTimer -= Time.deltaTime;
    }
}