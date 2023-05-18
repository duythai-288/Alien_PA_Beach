using UnityEngine;
using System;

public enum ToolPlayer { DEFAULT, GUN, SCANNER };
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalAlien;
    public int totalAlienDown;
    public int earnedCoin;
    public double adTime = 0.0;
    public bool isPassTut;
    public bool isBonusLevel;
    public DateTime startTime = DateTime.Now;
    public DateTime startBackgroundTime = DateTime.Now;
    public int numberMysteryBox = 0;
    public int boxHasOpened = 0;

    public GameManager GetIntance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        return Instance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        isPassTut = Convert.ToBoolean(PlayerPrefsManager.IsShowTut);
    }

    public void UnloadLevel()
    {
        totalAlien = 0;
        totalAlienDown = 0;
        numberMysteryBox = 0;
        boxHasOpened = 0;
        gameObject.DestroyAllChildren();
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            try
            {
                adTime += (DateTime.Now - startBackgroundTime).TotalSeconds;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            startBackgroundTime = DateTime.Now;
        }
    }
}
