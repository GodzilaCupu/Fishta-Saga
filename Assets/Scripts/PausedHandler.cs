using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedHandler : MonoBehaviour
{
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
        HealthHandler playerHealth = new HealthHandler();
        Database.SetProgress("LastHealth",playerHealth.PlayerHealth);
        // this will be save ikan kecil progres
        // this will be save achivement
    }
}
