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

    private void Start() {
        EventManager.current.onOpenPaused += Paused;
        EventManager.current.onClosePaused += UnPaused;
    }

    private void OnDisable() {
        EventManager.current.onOpenPaused -= Paused;
        EventManager.current.onClosePaused -= UnPaused;
    }

    #region Paused
    public void Paused(){
        isPaused = true;
        _pausedPanel.SetActive(true);
    }

    public void UnPaused() {
        isPaused = false;
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

    private void SavedData(){
        Database.SetProgress("LastHealth",playerHealth.PlayerHealth);
        Database.SetPlayerAchivement("Starfish", Database.GetPlayerAchivement("Starfish"));
        Database.SetPlayerAchivement("Shell", Database.GetPlayerAchivement("Shell"));
        Database.SetPlayerAchivement("Pearl", Database.GetPlayerAchivement("Pearl"));
        // this will be save ikan kecil progres
    }
}
