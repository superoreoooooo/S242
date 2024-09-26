using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    private int jumpCnt = 0;

    [SerializeField]
    private float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        animator.SetBool("Grounded", true);
        jumpCnt = 0;
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
            rb.velocity = new Vector2(0, jumpForce);
            //rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            animator.SetBool("Grounded", false);
        }
    }
}
