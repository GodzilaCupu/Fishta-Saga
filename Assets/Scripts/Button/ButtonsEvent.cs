using UnityEngine;
using UnityEngine.Events;

public static class ButtonsEvent
{
    #region Main Menu Panel
    // Tutorial
    public static UnityAction onOpenTutorialPanel;
    public static void OpenTutorial() => onOpenTutorialPanel?.Invoke();

    public static UnityAction onCloseTutorialPanel;
    public static void CloseTutorial() => onCloseTutorialPanel?.Invoke();

    // Achivement

    public static UnityAction onOpenAchivementPanel;
    public static void OpenAchivement() => onOpenAchivementPanel?.Invoke();

    public static UnityAction onCloseAchivementPanel;
    public static void CloseAchivement() => onCloseAchivementPanel?.Invoke();

    // Map Selector

    public static UnityAction onOpenMapSelectorPanel;

    public static void OpenMapSelector() => onOpenMapSelectorPanel?.Invoke();


    public static UnityAction onCloseMapSelectorPanel;

    public static void CloseMapSelector() => onCloseMapSelectorPanel?.Invoke();
    #endregion

    #region Gameplay

    public static UnityAction onOpenPausedPanel;
    public static void PausedGame() => onOpenPausedPanel?.Invoke();

    public static UnityAction onClosePausedPanel;
    public static void ResumeGame() => onClosePausedPanel?.Invoke();


    #endregion

    #region Settings

    //  Settings

    public static UnityAction onOpenSettingsPanel;
    public static void OpenSettings() => onOpenSettingsPanel?.Invoke();

    public static UnityAction onBacktoPausePanel;
    public static void BackToPause() => onBacktoPausePanel?.Invoke();

    public static UnityAction onCloseSettingsPanel;
    public static void CloseSettings() => onCloseSettingsPanel?.Invoke();

    #endregion
}
