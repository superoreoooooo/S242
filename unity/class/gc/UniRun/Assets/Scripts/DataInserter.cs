using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataInserter : MonoBehaviour
{
    public TMP_InputField inputUserName;
    public TMP_InputField inputPassword;
    public GameObject createUserInformation;
    public GameObject createAccountPanel;

    private string createUserURL = "http://127.0.0.1/indexing.php";

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void onCreateBtnClickEvent() {
        string uname = inputUserName.text;
        string pw = inputPassword.text;

        Debug.Log("Username: " + uname);
        Debug.Log("Password: " + pw);

        CreateUser(uname, pw);
    }

    public void CreateUser(string uname, string pw) {
        WWWForm form = new WWWForm();

        form.AddField("usernamePost", uname);
        form.AddField("passwordPost", pw);

        WWW www = new WWW(createUserURL, form);

        createAccountPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
