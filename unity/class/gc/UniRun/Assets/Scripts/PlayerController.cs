using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    private bool isGrounded = false;
    private bool isDead = false;
    private AudioSource playerAudio;
    public Animator animator;
    private Rigidbody2D rb2d;
    private int jumpCnt = 0;
    public float jumpForce = 700f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && jumpCnt < 2)
        {
            jumpCnt += 1;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        } else if (Input.GetMouseButtonUp(0) && rb2d.velocity.y > 0)
        {
            rb2d.velocity = rb2d.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead) {
            Die();
        }
        else if (collision.tag == "Obstacle" && health > 0 && !isDead)
        {
            gainDamage(1);
        }
    }

    public int health = 3;

    private void gainDamage(int amount)
    {
        health -= amount;
        GameManager.instance.onPlayerGainDamage(health);
        if (health <= 0) Die();
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
    }

    private void Die() {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        rb2d.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.onPlayerDead();
    }
}
