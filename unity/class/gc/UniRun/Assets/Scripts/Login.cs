using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField inputUserName;
    public TMP_InputField inputPassword;
    public GameObject loginBtn;
    public GameObject createAccBtn;
    public GameObject createAccBtnPanel;

    public static string userNameData;
    public static string userPWData;

    string loginURL = "http://127.0.0.1/Login.php";

    private void Start() {
        Screen.SetResolution(1280, 720, true);
    }

    private void Update() {
        userNameData = inputUserName.text;
        userPWData = inputPassword.text;
    }

    public void onLoginBtnClickEvent() {
        string uname = inputUserName.text;
        string pw = inputPassword.text;

        StartCoroutine(LoginToDB(uname, pw));

        Debug.Log("Username : " + uname);
        Debug.Log("PW : " + pw);
    }

    public void onCreateBtnClickEvent() {
        createAccBtnPanel.SetActive(true);
    }

    private IEnumerator LoginToDB(string uname, string pw) {
        WWWForm form = new WWWForm();

        form.AddField("namePost", uname);
        form.AddField("passPost", pw);

        WWW www = new WWW(loginURL, form);

        yield return www;


        Debug.Log(www.text);

        if (www.text == "login successlogin success" || www.text == "Login success") {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
