using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public BossHealth boss;
    [SerializeField] private GameObject lostScreen;
    [SerializeField] private GameObject winScreen;
    public bool gameOver;
    public bool victory;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent onScoreUpdate;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    private void Start()
    {
        gameOver = false;
        victory = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            lostScreen.SetActive(true);
            Time.timeScale = 0;
            scoreText.text = "Score: " + score;
            scoreText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 95);
        }
        else
        {
            lostScreen.SetActive(false);
            Time.timeScale = 1;
        }

        if (victory)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            scoreText.text = "Score: " + score;
            scoreText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 95);
        }
        else
        {
            winScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReportBossDeath()
    {
        victory = true;
        scoreText.text = "Score: " + score;
    }

    public void ResetGame()
    {
        gameOver = false;
        victory = false;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void AddScore(int amount)
    {
        score += amount;
        onScoreUpdate.Invoke();
    }

    public int GetScore()
    {
        return score;
    }
}