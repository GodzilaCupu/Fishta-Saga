using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [Header("Game Object Button")]
    [Tooltip("0 = Start Btn 1 = Continue Btn \n2 = Exit btn 3 = Open Achivement Btn \n4 = Open Tutorial Btn 5 = Close Achievement Btn" +
             "\n6 = Close Tutorial Btn 7 = Close Map Selector Btn \n8 = Map Sungai btn 9 = Map Sungai btn")]
    [SerializeField] private Button[] mainMenu_btn;

    [Tooltip("0 = Open Pause Panel ; \n1 = Close Pause Panel  ; \n2 = Restart")]
    [SerializeField] private Button[] gameplay_btn;

    [Tooltip("0 = Open Settings; \n1 = Close Settings; \n2 = Toggle Sound ; \n3 = Back To Pause Panel")]
    [SerializeField] private GameObject[] settings_btn;

    [SerializeField] private AudioSource sourceAudio;

    private void Start()
    {
        CallingButtons();
        sourceAudio = gameObject.GetComponent<AudioSource>();
        SetAudio(Database.GetAudio("BGM") == 1 ? true : false, settings_btn[((int)SettingsButtons.MusicToggle)]);
        EventManager.current.ChooseClip(sourceAudio);
    }

    private void Update()
    {
        Debug.Log($"Audio {Database.GetAudio("BGM")}");
        Debug.Log($"Level {Database.GetProgress("Level")}");
    }

    private void CallingButtons()
    {
        //Settings
        for (int i = 0; i < settings_btn.Length; i++)
        {
            switch (i)
            {
                case 0:
                    settings_btn[((int)SettingsButtons.OpenSettings)].GetComponent<Button>().onClick.AddListener(OpenSettingsPanel);
                    break;

                case 1:
                    settings_btn[((int)SettingsButtons.CloseSettings)].GetComponent<Button>().onClick.AddListener(ClosedSettingsPanel);
                    break;

                case 2:
                    settings_btn[((int)SettingsButtons.MusicToggle)].GetComponent<Toggle>().onValueChanged.AddListener(MuteAudio);
                    break;

                case 3:
                    settings_btn[((int)SettingsButtons.BackToPause)].GetComponent<Button>().onClick.AddListener(BackToPausedPanel);
                    break;

                default:
                    Debug.Log("Please Check ur Game Play Buttons");
                    break;
            }
        }
        //Main Menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            for (int i = 0; i < mainMenu_btn.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        mainMenu_btn[((int)MainMenuButtons.Start)].onClick.AddListener(StartGame);
                        break;

                    case 1:
                        if (Database.GetProgress("Level") == 0)
                            mainMenu_btn[((int)MainMenuButtons.Continue)].interactable = false;
                        mainMenu_btn[((int)MainMenuButtons.Continue)].onClick.AddListener(ContinueGame);
                        break;

                    case 2:
                        mainMenu_btn[((int)MainMenuButtons.Exit)].onClick.AddListener(ExitGame);
                        break;

                    case 3:
                        mainMenu_btn[((int)MainMenuButtons.OpenAchievement)].onClick.AddListener(OpenAchivementPanel);
                        break;

                    case 4:
                        mainMenu_btn[((int)MainMenuButtons.OpenTutorial)].onClick.AddListener(OpenTutorialPanel);
                        break;

                    case 5:
                        mainMenu_btn[((int)MainMenuButtons.CloseAchievement)].onClick.AddListener(CloseAchivementPanel);
                        break;

                    case 6:
                        mainMenu_btn[((int)MainMenuButtons.CloseTutorial)].onClick.AddListener(CloseTutorialPanel);
                        break;

                    case 7:
                        mainMenu_btn[((int)MainMenuButtons.CloseMapSelector)].onClick.AddListener(CloseMapSelectorPanel);
                        break;

                    case 8:
                        mainMenu_btn[((int)MainMenuButtons.LautMap)].onClick.AddListener(delegate { MapSelectorButton(0); });
                        break;

                    case 9:
                        mainMenu_btn[((int)MainMenuButtons.SungaiMap)].onClick.AddListener(delegate { MapSelectorButton(1); });
                        break;

                    default:
                        Debug.Log("please Check ur main menu button");
                        break;
                }
            }
            settings_btn[((int)SettingsButtons.BackToPause)].SetActive(false);
        }
        //Gameplay
        else if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            for (int i = 0; i < gameplay_btn.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        gameplay_btn[((int)PauseButtons.OpenPause)].onClick.AddListener(OpenPausedPanel);
                        break;

                    case 1:
                        gameplay_btn[((int)PauseButtons.ClosePause)].onClick.AddListener(ClosePausedPanel);
                        break;

                    case 2:
                        gameplay_btn[((int)PauseButtons.Restart)].onClick.AddListener(RestartGame);
                        break;
                }
            }
            settings_btn[((int)SettingsButtons.BackToPause)].SetActive(true);
        }
    }
    #region Main Menu Button

    private void StartGame()
    {
        EventManager.current.OpenMapSelector();
        Database.SetProgress("Level", 0);
        Debug.Log("It's Work");
    }

    private void ContinueGame()
    {
        // SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene("Stage1");
        Debug.Log("It's Work");
    }

    private void OpenAchivementPanel()
    {
        EventManager.current.OpenAchievement();
        Debug.Log("It's Work");

    }

    private void CloseAchivementPanel()
    {
        EventManager.current.CloseAchievement();
        Debug.Log("It's Work");

    }

    private void OpenTutorialPanel()
    {
        EventManager.current.OpenTutorial();
        Debug.Log("It's Work");

    }

    private void CloseTutorialPanel()
    {
        EventManager.current.CloseTutorial();
        Debug.Log("It's Work");

    }

    private void CloseMapSelectorPanel()
    {
        EventManager.current.CloseMapSelector();
        Debug.Log("It's Work");
    }

    private void MapSelectorButton(int id)
    {
        Database.SetProgress("Map", id);
        Database.SetProgress("Level", Database.GetProgress("Level") + 1);
        SceneManager.LoadScene("Stage1");
        // SceneManager.UnloadScene("MainMenu");
        Debug.Log($"Map {id}");
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }

    #endregion

    #region Settings Panel

    private void OpenSettingsPanel()
    {
        EventManager.current.OpenSettings();
        if (SceneManager.GetActiveScene().name == "Gameplay")
            ClosePausedPanel();
        Debug.Log("is Opened");
    }

    private void ClosedSettingsPanel()
    {
        EventManager.current.CloseSettings();
        Debug.Log("is Closed");
    }

    private void BackToPausedPanel()
    {
        EventManager.current.BackToPausePanel();
        Debug.Log("is Back");
    }

    private void SetAudio(bool value, GameObject btn)
    {
        if (value == false)
        {
            Database.SetAudio("BGM", 0);
            btn.GetComponent<Toggle>().isOn = false;
            sourceAudio.mute = false;
        }
        else if (value == true)
        {
            Database.SetAudio("BGM", 1);
            btn.GetComponent<Toggle>().isOn = true;
            sourceAudio.mute = true;
        }

    }

    private void MuteAudio(bool isMute) => EventManager.current.MuteMusicHandler(isMute, settings_btn[(int)SettingsButtons.MusicToggle], sourceAudio);
    #endregion

    #region Gameplay

    public void OpenPausedPanel()
    {
        EventManager.current.OpenPaused();
        Debug.Log("It's Work");
    }


    private void ClosePausedPanel()
    {
        EventManager.current.ClosePaused();
        Debug.Log("It's Work");
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        EventManager.current.OpenMapSelector();
        Debug.Log("It's Work");
    }
    #endregion
}

#region enums
public enum MainMenuButtons
{
    //Main Menu - Main Buttons
    Start,
    Continue,
    Exit,

    //Main Menu - Calling Panel Buttons
    OpenAchievement,
    OpenTutorial,

    //Main Menu - Close Panel Buttons
    CloseAchievement,
    CloseTutorial,
    CloseMapSelector,

    //Main Menu - Map Selector
    SungaiMap,
    LautMap,
}

public enum SettingsButtons
{
    //Settings - Main Buttons
    OpenSettings,
    CloseSettings,

    //Settings - Option Buttons
    MusicToggle,
    BackToPause,
}

public enum PauseButtons
{
    //Pause - Main Buttons
    OpenPause,
    ClosePause,

    //Pause - Option Buttons
    Restart
}

#endregion
