using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FoodBounce : MonoBehaviour
{
    public bool velWasStopped = false;
    public Vector3 stoppedVel;
    public Rigidbody rb;

    public TextMeshProUGUI hitCntText;
    public int hitCnt = 0;
    public bool hasLost = false;
    public int bestScore = 0;
    public int lastBest = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    public TextMeshProUGUI timerText;

    private float startTime;

    void Update()
    {
        string str = " ";

        if (!hasLost)
        {
            str = hitCnt.ToString();
            timerText.text = "Time : " + string.Format("{0:D2}", (int)(Time.time - startTime));
        }
        else
        {
            str = "Hits : " + hitCnt.ToString() + "\nYour best : " + bestScore;
            if (bestScore > lastBest)
            {
                str += "\nNew Record!";
            }
        }

        hitCntText.text = str;

        if (transform.position.y < 0)
        {
            if (!hasLost)
            {
                hasLost = true;
                lastBest = bestScore;
                if (hitCnt > bestScore) bestScore = hitCnt;
            }
        }
    }

    bool collisionable = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collisionable) return;
        else collisionable = false;
        StartCoroutine(ct());
        if (collision.gameObject.tag == "tray")
        {
            Debug.Log("hit!@");
        }

        if (!velWasStopped)
        {
            stoppedVel = rb.velocity;
            velWasStopped = true;
        }

        if (rb.velocity.y > 1) hitCnt++;

        rb.velocity = new Vector3(Random.Range(-0.5f, 0.5f), stoppedVel.y, Random.Range(-0.5f, 0.5f));
    }
    
    private IEnumerator ct() {
        yield return new WaitForSeconds(0.5f);
        collisionable = true;
    }

    private void OnGUI()
    {
        if (hasLost)
        {
            int buttonW = 100;
            int buttonH = 50;
            float halfScreenW = Screen.width / 2;
            float halfButtonW = buttonW / 2;

            if (GUI.Button(new Rect(halfScreenW - halfButtonW, Screen.height * 0.8f, buttonW, buttonH), "Play Again"))
            {
                hitCnt = 0;
                hasLost = false;
                transform.position = new Vector3(0.5f, 2.0f, -0.05f);
                rb.velocity = new Vector3(0, 0, 0);
                startTime = Time.time;
            }
        }
    }
}
