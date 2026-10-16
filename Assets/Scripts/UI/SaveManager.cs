using UnityEngine;

public static class SaveManager
{
    private const string HighestDayKey = "HighestUnlockedDay";

    public static int GetHighestUnlockedDay()
    {
        return PlayerPrefs.GetInt(HighestDayKey, 1);
    }

    public static void UnlockDay(int day)
    {
        int currentHighestDay = GetHighestUnlockedDay();

        if (day > currentHighestDay)
        {
            PlayerPrefs.SetInt(HighestDayKey, day);
            PlayerPrefs.Save();

            Debug.Log("Unlocked Day " + day);
        }
    }

    public static bool IsDayUnlocked(int day)
    {
        return day <= GetHighestUnlockedDay();
    }

    public static bool HasSave()
    {
        return PlayerPrefs.HasKey(HighestDayKey);
    }

    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey(HighestDayKey);
        PlayerPrefs.Save();

        Debug.Log("Save data deleted.");
    }
}