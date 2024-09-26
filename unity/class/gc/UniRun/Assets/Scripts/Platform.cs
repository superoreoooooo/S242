using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
        if (transform.position.x <= -15f) {
            Destroy(gameObject);
        }
    }
}
