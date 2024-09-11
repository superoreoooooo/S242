using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5;
    [SerializeField]
    private float rotCamYAxisSpeed = 5;

    private float limitMinX = -80;
    private float limitMaxX = 80;
    private float eularAngleX;
    private float eularAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eularAngleY += mouseX * rotCamXAxisSpeed;
        eularAngleX -= mouseY * rotCamYAxisSpeed;

        eularAngleX = ClampAngle(eularAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eularAngleX, eularAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}