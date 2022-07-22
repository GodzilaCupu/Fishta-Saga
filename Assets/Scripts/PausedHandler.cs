using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedHandler : MonoBehaviour
{
    [SerializeField] HealthHandler playerHealth;
    [SerializeField] GameObject _pausedPanel;
    [SerializeField] GameObject _SettingsPanel;
    bool isPaused;


    #region Paused
    public void Paused(){
        isPaused = true;
        EventManager.current.OpenPaused();
        _pausedPanel.SetActive(true);
    }

    public void UnPaused() {
        isPaused = false;
        EventManager.current.ClosePaused();
        _pausedPanel.SetActive(false);   
        SavedData();
    }
    #endregion

    public void OpenSettings(){
        _SettingsPanel.SetActive(true);
        _pausedPanel.SetActive(false);
    }

    public void RestartLevel(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        // Buat randombackgound tidak ke reset
    }

    public void BackToMainMenu() => SceneManager.LoadScene("MainMenu");

    private void SavedData(){
        Database.SetProgress("LastHealth",playerHealth.PlayerHealth);
        Database.SetPlayerAchivement("Starfish", Database.GetPlayerAchivement("Starfish"));
        Database.SetPlayerAchivement("Shell", Database.GetPlayerAchivement("Shell"));
        Database.SetPlayerAchivement("Pearl", Database.GetPlayerAchivement("Pearl"));
        // this will be save ikan kecil progres
    }
}
