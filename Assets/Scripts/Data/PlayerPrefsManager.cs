using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager
{
    public static LevelDataSO currentLevelData;


    public const string PREFS_SOUND = "sound";
    public const string PREFS_VIBRATION = "vibration";
    public const string PREFS_CURRENT_LEVEL = "current_index_level";
    public const string PREFS_CURRENT_SHUFFLE_LEVEL = "current_shuffle_index_level";
    public const string PREFS_COIN = "coin";
    public const string PREFS_TUT = "is_pass_tut";
    public const string PREFS_START_TIME = "start_time";
    public const string PREFS_BACKGROUND_TIME = "background_time";
    public const string PREFS_SHUFFLE_LEVEL = "is_shuffle_level";
    public const string PREFS_LAST_LEVEL_DATA_URL = "last_level_data_url";
    public const string PREFS_LAST_LEVEL_DATA_VERSION = "last_level_data_version";
    public const string PREFS_UNLOCK_GUN = "unlock_gun";
    public const string PREFS_CURRENT_GUN = "current_gun";
    public const string PREFS_UNLOCK_SCANNER = "unlock_scanner";
    public const string PREFS_CURRENT_SCANNER = "current_scanner";
    public const string PREFS_MIGRATE = "migrate";
    public const string PREFS_RATED = "rated";
    public const string PREFS_NO_ADS = "no_ads";
    public const string PREFS_LEVEL_BONUS = "is_level_bonus";
    public const string PREFS_CURRENT_LEVEL_BONUS = "index_level_bonus";
    public const string PREFS_ENVI_INDEX = "environment_index";
    public const string PREFS_BONUS_ENVI_INDEX = "bonus_environment_index";


    public static bool Sound
    {
        get => PlayerPrefs.GetInt(PREFS_SOUND, 1) == 1;
        set => PlayerPrefs.SetInt(PREFS_SOUND, value ? 1 : 0);
    }

    public static bool Vibration
    {
        get => PlayerPrefs.GetInt(PREFS_VIBRATION, 1) == 1;
        set => PlayerPrefs.SetInt(PREFS_VIBRATION, value ? 1 : 0);
    }

    public static int CurrentIndex
    {
        get => PlayerPrefs.GetInt(PREFS_CURRENT_LEVEL, 0);
        set => PlayerPrefs.SetInt(PREFS_CURRENT_LEVEL, value);
    }
    public static int CurrentShuffleIndex
    {
        get => PlayerPrefs.GetInt(PREFS_CURRENT_SHUFFLE_LEVEL, 0);
        set => PlayerPrefs.SetInt(PREFS_CURRENT_SHUFFLE_LEVEL, value);
    }

    public static int Coin
    {
        get => PlayerPrefs.GetInt(PREFS_COIN);
        set => PlayerPrefs.SetInt(PREFS_COIN, value);
    }
    public static int IsShowTut
    {
        get => PlayerPrefs.GetInt(PREFS_TUT);
        set => PlayerPrefs.SetInt(PREFS_TUT, value);
    }
    public static int IsShuffleLevel
    {
        get => PlayerPrefs.GetInt(PREFS_SHUFFLE_LEVEL);
        set => PlayerPrefs.SetInt(PREFS_SHUFFLE_LEVEL, value);
    }
    public static string StartTime
    {
        get => PlayerPrefs.GetString(PREFS_START_TIME);
        set => PlayerPrefs.SetString(PREFS_START_TIME, value);
    }

    public static string OnBackgroundTime
    {
        get => PlayerPrefs.GetString(PREFS_BACKGROUND_TIME);
        set => PlayerPrefs.SetString(PREFS_BACKGROUND_TIME, value);
    }
    public static string LastLevelDataURL
    {
        get => PlayerPrefs.GetString(PREFS_LAST_LEVEL_DATA_URL);
        set => PlayerPrefs.SetString(PREFS_LAST_LEVEL_DATA_URL, value);
    }
    public static int LastLevelDataVersion
    {
        get => PlayerPrefs.GetInt(PREFS_LAST_LEVEL_DATA_VERSION);
        set => PlayerPrefs.SetInt(PREFS_LAST_LEVEL_DATA_VERSION, value);
    }

    public static int Migrate
    {
        get => PlayerPrefs.GetInt(PREFS_MIGRATE, 0);
        set => PlayerPrefs.SetInt(PREFS_MIGRATE, value);
    }
    public static int NoAds
    {
        get => PlayerPrefs.GetInt(PREFS_NO_ADS, 0);
        set
        {
            // SDKPlayerPrefs.SetBoolean(StringConstants.REMOVE_ADS, value == 1);
            PlayerPrefs.SetInt(PREFS_NO_ADS, value);
        }
    }

    public static int IsLevelBonus
    {
        get => PlayerPrefs.GetInt(PREFS_LEVEL_BONUS, 0);
        set => PlayerPrefs.SetInt(PREFS_LEVEL_BONUS, value);
    }

    public static int EnvironmentIndex
    {
        get => PlayerPrefs.GetInt(PREFS_ENVI_INDEX, 0);
        set => PlayerPrefs.SetInt(PREFS_ENVI_INDEX, value);
    }

    public static int BonusEnvironmentIndex
    {
        get => PlayerPrefs.GetInt(PREFS_BONUS_ENVI_INDEX, 0);
        set => PlayerPrefs.SetInt(PREFS_BONUS_ENVI_INDEX, value);
    }

    public static int IndexLevelBonus
    {
        get => PlayerPrefs.GetInt(PREFS_CURRENT_LEVEL_BONUS, 0);
        set => PlayerPrefs.SetInt(PREFS_CURRENT_LEVEL_BONUS, value);
    }

    private static List<int> _unlockGun = null;
    public static List<int> UnlockGun
    {
        get
        {
            if (_unlockGun == null)
            {
                try
                {
                    _unlockGun = new List<int>();
                    int[] temp = PlayerPrefsElite.GetIntArray(PREFS_UNLOCK_GUN);
                    _unlockGun.AddRange(temp);

                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                    return _unlockGun;
                }
            }
            return _unlockGun;
        }
        set
        {
            _unlockGun = value;
            PlayerPrefsElite.SetIntArray(PREFS_UNLOCK_GUN, value.ToArray());
        }
    }

    public static void AddUnlockGun(int idGun)
    {
        if (!UnlockGun.Contains(idGun))
        {
            List<int> unlockGun = UnlockGun;
            unlockGun.Add(idGun);
            UnlockGun = unlockGun;
        }
    }

    public static int CurrentGun
    {
        get => PlayerPrefs.GetInt(PREFS_CURRENT_GUN, 0);
        set => PlayerPrefs.SetInt(PREFS_CURRENT_GUN, value);
    }

    private static List<int> _unlockScanner;

    public static List<int> UnlockScanner
    {
        get
        {
            if (_unlockScanner == null)
            {
                try
                {
                    _unlockScanner = new List<int>();
                    int[] temp = PlayerPrefsElite.GetIntArray(PREFS_UNLOCK_SCANNER);
                    _unlockScanner.AddRange(temp);

                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                    return _unlockScanner;
                }
            }
            return _unlockScanner;
        }
        set
        {
            _unlockScanner = value;
            PlayerPrefsElite.SetIntArray(PREFS_UNLOCK_SCANNER, value.ToArray());
        }
    }

    public static void AddUnlockScanner(int idScan)
    {
        if (!UnlockScanner.Contains(idScan))
        {
            List<int> unlockScan = UnlockScanner;
            unlockScan.Add(idScan);
            UnlockScanner = unlockScan;
        }
    }

    public static int CurrentScanner
    {
        get => PlayerPrefs.GetInt(PREFS_CURRENT_SCANNER, 0);
        set => PlayerPrefs.SetInt(PREFS_CURRENT_SCANNER, value);
    }

    public static bool Rated
    {
        get => PlayerPrefsElite.GetBoolean(PREFS_RATED, false);
        set => PlayerPrefsElite.SetBoolean(PREFS_RATED, value);
    }
}