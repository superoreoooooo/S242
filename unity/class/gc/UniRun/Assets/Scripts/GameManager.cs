using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;

    private string userInputName;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Scene has multiple game manager!");
            Destroy(gameObject);
        }

        gameStartedTime = Time.time;
    }

    private void Update()
    {
        if (!isGameStarted)
        {
            if (Input.anyKeyDown)
            {
                startGame();
            }
        }

        if (!isGameover)
        {
            gameTime.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt((Time.time - gameStartedTime) / 60), Mathf.FloorToInt((Time.time - gameStartedTime) % 60));
        }

        userInputName = Login.userNameData;
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public bool isGameStarted = false;
    public GameObject[] gameElements;
    public GameObject prevStartImg;

    public void startGame()
    {
        isGameStarted = true;
        prevStartImg.SetActive(false);
        foreach (GameObject obj in gameElements)
        {
            obj.SetActive(true);
        }
    }

    public float gameStartedTime;
    public TextMeshProUGUI gameTime;
    public GameObject[] gameDataUIs;
    public TextMeshProUGUI gameData;

    public void onPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);

        foreach (GameObject obj in gameDataUIs)
        {
            obj.SetActive(false);
        }

        insert(score, userInputName);

        gameData.text = string.Format($"Score : {score}" + "\nTime : {0:00}:{1:00}", Mathf.FloorToInt((Time.time - gameStartedTime) / 60), Mathf.FloorToInt((Time.time - gameStartedTime) % 60));
    }

    public void insert(int score, string username) {
        string addr = "http://127.0.0.1/insert.php";
        WWWForm form = new WWWForm();
        form.AddField("Score", score);
        form.AddField("UserName", username);

        WWW wwwURL = new WWW(addr, form);

        StartCoroutine(rankingUI());
    }

    private IEnumerator rankingUI() {
        string url = "http://127.0.0.1/compare.php";

        WWW www = new WWW(url);

        yield return www;

        if (www.isDone) {
            if (www.error == null) {
                Debug.Log("Receive Data : " + www.text);
            } else {
                Debug.Log("error : " + www.error);
            }
        }
    }

    public TextMeshProUGUI playerHealth;

    public void onPlayerGainDamage(int healthNow)
    {
        playerHealth.text = $"HP : {healthNow}";
    }
}