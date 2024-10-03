using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    private bool isGrounded = false;
    private bool isDead = false;
    private AudioSource playerAudio;

    public Animator animator;
    private Rigidbody2D rb;
    private int jumpCnt = 0;

    [SerializeField]
    private float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        } else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            if (rb.velocity.y > 0) {
                rb.velocity = rb.velocity * 0.5f;
            }
        }
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f) {
            isGrounded = true;
            jumpCnt = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false;
        jumpCnt = 0;
    }


    private void Die() {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        rb.velocity = Vector2.zero;
        isDead = true;
    }

    public void Jump()
    {
        int max = 2;

        if (jumpCnt < max)
        {
            jumpCnt++;
        }
        else return;
        if (jumpCnt <= max)
        {
            rb.velocity = rb.velocity * 0.5f;
            //rb.velocity = new Vector2(0, jumpForce);
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Grounded", isGrounded);
            playerAudio.Play();
        }
    }
}
