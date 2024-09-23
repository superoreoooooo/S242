using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class clockScript : MonoBehaviour
{
    public bool btn_active;
    public TextMeshProUGUI text_time;
    public TextMeshProUGUI btn_text;

    public float startTime;
    public float timeRemaining;


    void Start()
    {
        btn_active = false;
        Debug.Log("START" + btn_active);
    }

    public void btn_Click()
    {
        if (!btn_active)
        {
            timeRemaining = startTime;
            setTimerOn();
            btn_text.text = "STOP";
        }
        else
        {
            setTimerOff();
            btn_text.text = "START";
        }
    }

    public void setTimerOff()
    {
        btn_active = false;
    }

    public void setTimerOn()
    {
        btn_active = true;
    }

    void Update()
    {
        if (btn_active)
        {
            doCountDown();
        }
    }

    private void doCountDown()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            btn_active = false;
            timesUp();
        }
        text_time.text = timeRemaining.ToString();

        Debug.Log("TIME REMAINING : " + timeRemaining);
    }

    void timesUp()
    {
        Debug.Log("TIME'S UP!");
    }
}
