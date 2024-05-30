using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    bool gamePaused;

    void Start()
    {
        gamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (gamePaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        gamePaused = true;
    }

    public void ResumeGame()
    {
        gamePaused = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
