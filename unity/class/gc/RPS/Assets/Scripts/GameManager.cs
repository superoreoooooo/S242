using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameCanvas;
    public GameObject GameEndCanvas;

    public Text txtResult;
    public Text txtYou;
    public Text txtCom;
    public Text gameEndText;

    public Image imgYou;
    public Image imgCom;

    int cntYou = 0;
    int cntCom = 0;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void onExitButtonClick() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnButtonClick(GameObject obj) {
        int you = int.Parse(obj.name.Substring(7, 1));
        CheckResult(you);
    }

    public void OnMouseExit(GameObject button) {
        Animator anim = button.GetComponent<Animator>();
        anim.Play("Normal");
    }

    private void CheckResult(int you) {
        int com = UnityEngine.Random.Range(1, 4);

        int k = you - com;

        switch (k) {
            case 0 :
                txtResult.text = "비겼습니다!";
                break;
            case 1 :
            case -2 :
                cntYou += 1;
                txtResult.text = "당신이 이겼습니다!";
                break;
            default :
                cntCom += 1;
                txtResult.text = "컴퓨터가 이겼습니다!";
                break;
        }

        SetResult(you, com);
    }

    private void SetResult(int you, int com) {

        if (cntYou >= 5 || cntCom >= 5) { //game end
            GameCanvas.SetActive(false);
            GameEndCanvas.SetActive(true);
            if (cntYou > cntCom) {
                gameEndText.text = "당신이 " + cntYou + " : " + cntCom + "으로 승리하였습니다!";
            } else {
                gameEndText.text = "컴퓨터가 " + cntCom + " : " + cntYou + "으로 승리하였습니다!";
            }

            return;
        }

        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();

        txtResult.GetComponent<Animator>().Play("TextScale", -1, 0);
    }

    private void Init() {
        txtResult.text = "아래 버튼을 선택하세요.";
    }
}
