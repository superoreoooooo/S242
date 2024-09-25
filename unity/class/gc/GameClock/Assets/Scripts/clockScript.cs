using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class clockScript : MonoBehaviour
{
    public bool btn_active;
    public bool btn_active_stop;
    public TextMeshProUGUI text_time;
    public TextMeshProUGUI btn_text;

    public TextMeshProUGUI btn_stop_text;

    public float startTime;
    public float timeRemaining;

    public float percent;
    public Texture2D clockBG;
    public Texture2D clockFG;
    public float clockFGMaxWidth;

    public Texture2D rightSide;
    public Texture2D leftSide;
    public Texture2D back;
    public Texture2D blocker;
    public Texture2D shiny;
    public Texture2D finished;

    void Start()
    {
        btn_active = false;
        btn_active_stop = false;
        //Debug.Log("START" + btn_active);
        clockFGMaxWidth = clockFG.width;
    }

    void OnGUI()
    {
        float newBarWidth = (percent / 100) * clockFGMaxWidth;

        int gap = 20;

        bool isPastHalfWay = percent < 50;

        int pX = 100;
        int pY = 50;
        int pW = 64;
        int pH = 64;
        float pHW = (float)(pW * 0.5);
        float pHH = (float)(pH * 0.5);

        Rect clockRect = new Rect(pX, pY, pW, pH);
        float rot = (percent / 100) * 360;
        Vector2 centerPoint = new Vector2(pX + pHW, pY + pHH);
        Matrix4x4 startMatrix = GUI.matrix;

        GUI.BeginGroup(new Rect(Screen.width - clockBG.width - gap, gap, clockBG.width, clockBG.height));
        GUI.DrawTexture(new Rect(0, 0, clockBG.width, clockBG.height), clockBG);
        GUI.BeginGroup(new Rect(5, 6, newBarWidth, clockFG.height));
        GUI.DrawTexture(new Rect(1, 0, clockFG.width, clockFG.height), clockFG);

        GUI.EndGroup();
        GUI.EndGroup();

        if (percent < 0)
        {
            GUI.DrawTexture(clockRect, finished, ScaleMode.StretchToFill, true, 0);
        }

        GUI.DrawTexture(clockRect, back, ScaleMode.StretchToFill, true, 0);

        if (isPastHalfWay)
        {
            GUIUtility.RotateAroundPivot(-rot, centerPoint);
            GUI.DrawTexture(clockRect, rightSide, ScaleMode.StretchToFill, true, 0);
            GUI.matrix = startMatrix;
            GUI.DrawTexture(clockRect, blocker, ScaleMode.StretchToFill, true, 0);
        }
        else
        {
            GUIUtility.RotateAroundPivot(-rot, centerPoint);
            GUI.DrawTexture(clockRect, rightSide, ScaleMode.StretchToFill, true, 0);
            GUI.matrix = startMatrix;
            GUIUtility.RotateAroundPivot(0, centerPoint);
            GUI.DrawTexture(clockRect, leftSide, ScaleMode.StretchToFill, true, 0);
        }
        GUI.DrawTexture(clockRect, shiny, ScaleMode.StretchToFill, true, 0);
    }

    public void btn_Click() //Start Button
    {
        if (isPaused)
        {
            ResetTimer();
            isPaused = false;
            btn_text.text = "Start";
            btn_stop_text.text = "Pause";
        }
        if (!btn_active)
        {
            timeRemaining = startTime;
            setTimerOn();
            btn_text.text = "Stop";
        }
        else
        {
            ResetTimer();
            setTimerOff();
            btn_text.text = "Start";
        }
    }

    private bool isPaused = false;

    public void btn_Stop_Click()
    {
        if (!btn_active_stop)
        {
            setTimerRestart();
            btn_stop_text.text = "Pause";
            isPaused = true;
        }
        else
        {
            setTimerPause();
            btn_stop_text.text = "Restart";
        }
    }

    private void setTimerPause()
    {
        btn_active_stop = false;
    }

    public void setTimerRestart()
    {
        btn_active_stop = true;
        btn_active = true;
    }

    public void setTimerOff()
    {
        btn_active = false;
    }

    public void setTimerOn()
    {
        btn_active = true;
        btn_active_stop = false;
    }

    public void ResetTimer()
    {
        btn_active = false;
        btn_active_stop = false;
        timeRemaining = startTime;
        btn_text.text = "Start";
        btn_stop_text.text = "Pause";
        doCountDown();
    }

    void Update()
    {
        if (btn_active && !btn_active_stop)
        {
            doCountDown();
        }

        /**

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("btn"))
        {
            if (timeRemaining == startTime || timeRemaining <= 0f)
            {
                obj.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                obj.transform.Rotate(new Vector3(0, 0, 1), 0.03f * (startTime - timeRemaining));
            }
        }*/
    }

    private void doCountDown()
    {
        timeRemaining -= Time.deltaTime;
        percent = timeRemaining / startTime * 100;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            btn_active = false;
            timesUp();
        }
        //text_time.text = timeRemaining.ToString();
        int min = (int)timeRemaining / 60;
        int sec = (int)(timeRemaining - (60 * min));
        text_time.text = string.Format("{0:D2}:{1:D2}", min, sec);
        Debug.Log("TIME REMAINING : " + timeRemaining);
    }

    void timesUp()
    {
        Debug.Log("TIME'S UP!");
    }
}
