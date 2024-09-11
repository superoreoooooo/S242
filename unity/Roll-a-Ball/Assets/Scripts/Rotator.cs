using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // transform의 Rotate 값을 시간에 비례하여 변경
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}

