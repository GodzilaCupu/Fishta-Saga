using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchivementHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] achivementText;

    private void OnEnable()
    {
        SetText();
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

    private void SetText()
    {
        achivementText[0].text = Database.GetPlayerAchivement("Starfish").ToString() + "X";
        achivementText[1].text = Database.GetPlayerAchivement("Shell").ToString() + "X";
        achivementText[2].text = Database.GetPlayerAchivement("Pearl").ToString() + "X";
    }
}
