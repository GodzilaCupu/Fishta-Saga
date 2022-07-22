using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectorHandler : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.current.onOpenMapSelector += OpenPanel;
        EventManager.current.onCloseMapSelector += ClosePanel;
    }
    private void OnDisable()
    {
        EventManager.current.onOpenMapSelector -= OpenPanel;
        EventManager.current.onCloseMapSelector -= ClosePanel;
    }

    private void ClosePanel()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        if (gameObject.transform.GetChild(0).gameObject == null)
            return;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
