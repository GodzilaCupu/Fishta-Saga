using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHandler : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.current.onOpenTutorial += OpenPanel;
        EventManager.current.onCloseTutorial += ClosePanel;
    }
    private void OnDisable()
    {
        EventManager.current.onOpenTutorial -= OpenPanel;
        EventManager.current.onCloseTutorial -= ClosePanel;
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
