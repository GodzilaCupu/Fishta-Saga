using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementHandler : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.current.onOpenAchievement += OpenPanel;
        EventManager.current.onCloseAchievement += ClosePanel;
    }
    private void OnDisable()
    {
        EventManager.current.onOpenAchievement -= OpenPanel;
        EventManager.current.onCloseAchievement -= ClosePanel;
    }

    private void ClosePanel()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OpenPanel()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
