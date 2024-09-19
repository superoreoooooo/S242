using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{

    public GameObject mgr;

    [SerializeField]
    private float speed;

    private Vector2 direction;

    void Start()
    {
        direction = new Vector2(1, 1);
    }

    void Update()
    {
        if (mgr.GetComponent<clockScript>().btn_active)
        {
            transform.Rotate(0, 0, mgr.GetComponent<clockScript>().startTime - mgr.GetComponent<clockScript>().timeRemaining);
            transform.SetPositionAndRotation(transform.position, transform.rotation);
        }

        //Vector3 pp = new Vector3(direction.x, direction.y, 0);
        //transform.SetPositionAndRotation(transform.position + pp.normalized * speed, transform.rotation);
        //rb2d.AddForce(new Vector2(1, 1));
    }
}
