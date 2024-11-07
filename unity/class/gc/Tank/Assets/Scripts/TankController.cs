using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] public int playerNum = 1;
    [SerializeField] private float tkMvSpeed = 10f;
    [SerializeField] private float tkRtSpeed = 150f;
    [SerializeField] private Color tankColor;

    private string mvAxis;
    private string rtAxis;

    void Start()
    {
        mvAxis = "Vertical" + playerNum;
        rtAxis = "Horizontal" + playerNum;

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mr in renderers) {
            mr.material.color = tankColor;
        }
    }

    void Update()
    {
        float mv = Input.GetAxis(mvAxis) * tkMvSpeed * Time.deltaTime;
        float rt = Input.GetAxis(rtAxis) * tkRtSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, rt, 0);
    }
}
