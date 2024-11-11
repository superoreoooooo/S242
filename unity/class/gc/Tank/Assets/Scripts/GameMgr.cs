using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public int scoreP1 = 0;
    public int scoreP2 = 0;

    public GameObject p1;
    public GameObject p2;

    private Vector3 p1Pos;
    private Quaternion p1Rot;
    private Vector3 p2Pos;
    private Quaternion p2Rot;

    void Start()
    {
        p1Pos = p1.transform.position;
        p2Pos = p2.transform.position;
        p1Rot = p1.transform.rotation;
        p2Rot = p2.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void roundEnd(int winner)
    {
        switch (winner)
        {
            case 1:
                scoreP1 += 1;
                break;
            case 2:
                scoreP2 += 1;
                break;
        }

        p1T.text = scoreP1.ToString();
        p2T.text = scoreP2.ToString();

        btn.gameObject.SetActive(true);
    }

    public TextMeshProUGUI p1T;
    public TextMeshProUGUI p2T;
    public Button btn;

    public void onBtnClick() {
        btn.gameObject.SetActive(false);
        p1.transform.position = p1Pos;
        p1.transform.rotation = p1Rot;
        p2.transform.position = p2Pos;
        p2.transform.rotation = p2Rot;

        p1.GetComponent<TargetController>().health = 3;
        p2.GetComponent<TargetController>().health = 3;
    }
}
