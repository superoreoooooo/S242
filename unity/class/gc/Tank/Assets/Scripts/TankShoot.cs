using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody prefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int playerNum = 1;
    private string fireName;

    private void Start() {
        fireName = "Fire" + playerNum;
    }

    void Update()
    {
        if (Input.GetButtonDown(fireName)) {
            Fire();
        }
    }

    private void Fire() {
        Rigidbody shellInstance = Instantiate(prefab, fireTransform.position, fireTransform.rotation) as Rigidbody;
        shellInstance.velocity = 20f * fireTransform.forward;
    }
}
