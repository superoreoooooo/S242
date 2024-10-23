using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;

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

        gameData.text = string.Format($"Score : {score}" + "\nTime : {0:00}:{1:00}", Mathf.FloorToInt((Time.time - gameStartedTime) / 60), Mathf.FloorToInt((Time.time - gameStartedTime) % 60));
    }

    public TextMeshProUGUI playerHealth;

    public void onPlayerGainDamage(int healthNow)
    {
        playerHealth.text = $"HP : {healthNow}";
    }
}