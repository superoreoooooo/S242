using UnityEngine;
using UnityEngine.UI;


public class Console2 : MonoBehaviour
{
    public Text debugText;
    string output = "";
    string stack = "";

    public GameObject cube;
    Vector3 prevPos;
    Vector3 presPos;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
        Debug.Log("Log enabled!");
        prevPos = cube.transform.position;
    }

    private void Update()
    {
        presPos = cube.transform.position;
        if ((presPos - prevPos).magnitude >= 0.5f)
        {
            Debug.Log(cube.transform.position);
        }
        prevPos = cube.transform.position;
    }

    private void OnDisable() { Application.logMessageReceived -= HandleLog; }
    void HandleLog(string logString, string stackTrace, LogType type) { output = logString + "\n" + output; }
    private void OnGUI() { debugText.text = output; }
    public void ClearLog() { output = ""; }
}