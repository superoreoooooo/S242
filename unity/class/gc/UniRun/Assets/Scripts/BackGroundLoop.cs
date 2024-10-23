using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;

    void Start()
    {
        BoxCollider2D bgCollider = GetComponent<BoxCollider2D>();
        width = bgCollider.size.x;
    }

    void Update()
    {
        transform.position = (Vector2) transform.position - new Vector2(0.1f, 0f);
        if (transform.position.x <= -width) {
            Reposition();
        }
    }

    private void Reposition() {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;
    }
}
