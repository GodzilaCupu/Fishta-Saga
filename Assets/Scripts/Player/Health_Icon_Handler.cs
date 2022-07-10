using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Health_Icon_Handler : MonoBehaviour
{
    public int id;
    public Image Icon;
    public Color AliveColor;
    public Color TransparantColor;

    public void Start() {
        Icon = GetComponent<Image>();
    }
    public void AddHealth() => Icon.color = AliveColor;

    public void RemoveHealth() => Icon.color = TransparantColor;
}
