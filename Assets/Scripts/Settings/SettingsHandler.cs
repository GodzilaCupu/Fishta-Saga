using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip[] _audioClip;

    [Header("Paused Panel")]
    [SerializeField] private GameObject paused;
    [SerializeField] private GameObject settings;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != e_SceneName.MainMenu.ToString())
            EventManager.current.onBackToPausePanel += BackToPaused;

        EventManager.current.onOpenSettings += OpenPanel;
        EventManager.current.onCloseSettings += ClosedPanel;
        EventManager.current.onMuteMusic += MuteAudio;
        EventManager.current.onChooseClip += ClipAudio;
    }

    public void OnDisable()
    {
        if (SceneManager.GetActiveScene().name != e_SceneName.MainMenu.ToString())
            EventManager.current.onBackToPausePanel -= BackToPaused;

        EventManager.current.onOpenSettings -= OpenPanel;
        EventManager.current.onCloseSettings -= ClosedPanel;
        EventManager.current.onMuteMusic -= MuteAudio;
        EventManager.current.onChooseClip -= ClipAudio;
    }

    public void BackToPaused()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        paused.SetActive(true);
        settings.SetActive(false);
        
        Debug.Log("Back To Paused");
    }

    public void ClosedPanel()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        settings.SetActive(false);
        Debug.Log("Closed");
    }

    public void OpenPanel()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("Opened");
    }

    public void ClipAudio(AudioSource audio)
    {
        switch(SceneManager.GetActiveScene().name){
            case "MainMenu":
                audio.clip = _audioClip[0];
                audio.Play();
                Debug.Log($"Clip {audio.clip.name} + isMute {audio.mute}");
                break;

            case "Gameplay":
                audio.clip = _audioClip[1];
                audio.Play();
                Debug.Log($"Clip {audio.clip.name} + isMute {audio.mute}");
                break;
        }
    }

    public void MuteAudio(bool value, GameObject btn, AudioSource audio)
    {
        if (value == false)
        {
            Database.SetAudio("BGM", 0); 
            btn.GetComponent<Toggle>().isOn = false;
            value = btn.GetComponent<Toggle>().isOn;
            audio.mute = value;

            Debug.Log($"value {value} btn {btn.name} audio {audio.clip.name}");

        }
        else if (value == true)
        {
            Database.SetAudio("BGM", 1); 
            btn.GetComponent<Toggle>().isOn = true;
            value = btn.GetComponent<Toggle>().isOn;
            audio.mute = value;

            Debug.Log($"value {value} btn {btn.name} audio {audio.clip.name}");
        }
    }


}
