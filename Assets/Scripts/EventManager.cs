using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    #region Buttons

    // Tutorial
    public event Action onOpenTutorial;
    public void OpenTutorial() => onOpenTutorial?.Invoke();

    public event Action onCloseTutorial;
    public void CloseTutorial() => onCloseTutorial?.Invoke();

    //Achievement
    public event Action onOpenAchievement;
    public void OpenAchievement() => onOpenAchievement?.Invoke();

    public event Action onCloseAchievement;
    public void CloseAchievement() => onCloseAchievement?.Invoke();

    //Map Selector
    public event Action onOpenMapSelector;
    public void OpenMapSelector() => onOpenMapSelector?.Invoke();

    public event Action onCloseMapSelector;
    public void CloseMapSelector() => onCloseMapSelector?.Invoke();

    //Paused
    public event Action onOpenPaused;
    public void OpenPaused() => onOpenPaused?.Invoke();

    public event Action onClosePaused;
    public void ClosePaused() => onClosePaused?.Invoke();

    //Settings
    public event Action onOpenSettings;
    public void OpenSettings() => onOpenSettings?.Invoke();

    public event Action onCloseSettings;
    public void CloseSettings() => onCloseSettings?.Invoke();

    public event Action onBackToPausePanel;
    public void BackToPausePanel() => onBackToPausePanel?.Invoke();

    #endregion

    #region Paused Configruation

    public event Action<GameState> onPauseChange;

    private void PauseChangeHandler(GameState state) => onPauseChange?.Invoke(state);

    #endregion

    #region Settings Configruation

    public event Action<bool, GameObject, AudioSource> onMuteMusic;
    public void MuteMusicHandler(bool isMuted, GameObject btnToMuted, AudioSource a_source) => onMuteMusic?.Invoke(isMuted, btnToMuted, a_source);

    public event Action<AudioSource> onChooseClip;
    public void ChooseClip(AudioSource a_source) => onChooseClip?.Invoke(a_source);


    #endregion

    #region Gameplay

    //Player Health

    public event Action<int> onStageScore;
    public void AddPlayerScore(int score) => onStageScore?.Invoke(score);

    public event Action<int> onSubtractPlayerHealth;
    public void SubtractPlayerHealth(int health) => onSubtractPlayerHealth?.Invoke(health);
    
    public event Action<int> onAddingPlayerHealth;
    public void AddingPlayerHealth(int health) => onAddingPlayerHealth?.Invoke(health);

    #endregion

    private void Awake()
    {
        if (current != null && current != this) Destroy(this);
        else current = this;
    }
}

