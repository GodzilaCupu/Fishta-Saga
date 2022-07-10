using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static bool isGameOver;

    public void EnabledGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    void OnEnable()
    {
        // HealthHandler.OnPlayerDeath += EnabledGameOverPanel;
    }

    void OnDisable()
    {
        // HealthHandler.OnPlayerDeath -= EnabledGameOverPanel;
    }

    public void RestartLevel()
    {
        // isGameOver = false;
        // Scene currentScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(currentScene.name);

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Stage1");
    }
    public void GoTOMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    // void Awake()
    // {
    //     isGameOver = false;
    //     if (!isGameOver)
    //         gameOverPanel.SetActive(false);
    // }


    // void Update()
    // {
    //     if (isGameOver)
    //         gameOverPanel.SetActive(true);
    // }
}
