using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ParticleSystem targetExplosion;
    public int health = 3;
    private TankController tc;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shell")
        {
            ParticleSystem fire = Instantiate(targetExplosion, transform.position, transform.rotation);
            fire.Play();

            health -= 1;
            if (health <= 0)
            {
                int num = tc.playerNum;

                FindAnyObjectByType<GameMgr>().roundEnd(num == 1 ? 2 : 1);
                //Destroy(gameObject);
                health = 3;
                gameObject.transform.position = new Vector3(100000, 100000, 100000);
                Destroy(fire.gameObject, 2.0f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tc = GetComponent<TankController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
