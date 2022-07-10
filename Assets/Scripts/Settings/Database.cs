using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Database
{

    #region Settings Audio
    public static void SetAudio(string key, int value) => PlayerPrefs.SetInt(key, value);

    public static int GetAudio(string key) => PlayerPrefs.GetInt(key);

    #endregion

    #region Progres

    public static void SetProgress(string key, int value) => PlayerPrefs.SetInt(key, value);

    public static int GetProgress(string key) => PlayerPrefs.GetInt(key);

    #endregion

    #region Player

    public static void SetPlayerAchivement(string key, int value) => PlayerPrefs.SetInt(key,value);
    public static int GetPlayerAchivement(string key) => PlayerPrefs.GetInt(key);

    #endregion
}
