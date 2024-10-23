using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }
}
