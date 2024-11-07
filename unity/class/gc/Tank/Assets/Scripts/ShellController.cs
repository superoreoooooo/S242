using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionEffect;

    private void OnCollisionEnter() {
        ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(gameObject);
        Destroy(explosion.gameObject, 2.0f);
    }
}
