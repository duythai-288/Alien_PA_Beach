using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedPreferencesManager : MonoBehaviour
{

    public static void Delete(string KeyName)
    {
        PlayerPrefs.DeleteKey(KeyName);
    }

    public static void SetString(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
    }

    public static string GetString(string KeyName, string defaultValue)
    {
        return PlayerPrefs.GetString(KeyName, defaultValue);
    }

    public static void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public static int GetInt(string KeyName, int defaultValue)
    {
        return PlayerPrefs.GetInt(KeyName, defaultValue);
    }

    public static void SetFloat(string KeyName, float Value)
    {
        PlayerPrefs.SetFloat(KeyName, Value);
    }

    public static float GetFloat(string KeyName, float defaultValue)
    {
        return PlayerPrefs.GetFloat(KeyName, defaultValue);
    }
}
