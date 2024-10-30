using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    float smooth = 5f;
    float tiltAngle = 30f;
    
    void Start()
    {
        
    }

    void Update()
    {
        float halfW = Screen.width / 2f;
        float halfH = Screen.height / 2f;

        transform.position = new Vector3(
                (Input.mousePosition.x - halfW) / halfW * 1.3f, 
                0, 
                (Input.mousePosition.y - halfH) / halfH
            );

        float tiltArZ = Input.GetAxis("Mouse X") * tiltAngle * 2f;
        float tiltArX = Input.GetAxis("Mouse Y") * tiltAngle * -2f;

        var target = Quaternion.Euler(new Vector3(tiltArX, 0, tiltArZ));
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
