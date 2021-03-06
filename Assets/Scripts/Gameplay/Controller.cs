using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controller : MonoBehaviour
{
    Scene thisScene;
    private int currentScore;
    [SerializeField] int _targetScore;
    [SerializeField] private TextMeshProUGUI displayScore;


    [SerializeField] string nextLevelTo;
    [SerializeField] private GameObject winPanel;
    [SerializeField] HealthHandler playerhealth;
    private void Start()
    {
        currentScore = 0;
        thisScene = SceneManager.GetActiveScene();
        displayScore.text = currentScore.ToString();
        EventManager.current.onStageScore += GetScore;

    }

    private void OnDisable()
    {
        EventManager.current.onStageScore -= GetScore;
    }

    private void GetScore(int score) => currentScore += score;

    private void Update()
    {
        displayScore.text = currentScore.ToString();
        // if (currentScore == _targetScore)
        if (currentScore >= _targetScore)
        {
            // LevelUp();
            winPanel.SetActive(true);
            EventManager.current.OpenPaused();
        }
    }

    private void LevelUp()
    {
        if (thisScene.name == e_SceneName.Stage1.ToString())
        {
            SceneManager.LoadScene(e_SceneName.Stage2.ToString());
            return;
        }

        if (thisScene.name == e_SceneName.Stage2.ToString())
        {
            SceneManager.LoadScene(e_SceneName.Stage3.ToString());
            // SceneManager.UnloadScene("stage1");
            return;
        }

        if (thisScene.name == e_SceneName.Stage3.ToString())
        {
            SceneManager.LoadScene(e_SceneName.MainMenu.ToString());
            return;
        }
    }

    public void NextToLevel()
    {
        SceneManager.LoadScene(nextLevelTo);
        SaveHealth();
    }

    private void SaveHealth() => Database.SetProgress("LastHealth", playerhealth.PlayerHealth);
}
