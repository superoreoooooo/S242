using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public OVRInput.RawButton shootingBtn;
    
    [SerializeField]
    private LineRenderer linePrefab;

    [SerializeField]
    private Transform shootingP;

    [SerializeField]
    private float len;

    [SerializeField]
    private float lineTimer;

    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.GetDown(shootingBtn)) {
            shoot();
        }
    }

    private void shoot() {
        LineRenderer lr = Instantiate(linePrefab);

        lr.positionCount = 2;
        lr.SetPosition(0, shootingP.position);

        Vector3 endP = shootingP.position + shootingP.forward * len;
        lr.SetPosition(1, endP);

        Destroy(lr.gameObject, lineTimer);
    }
}
