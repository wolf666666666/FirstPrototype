using UnityEngine;
using UnityEngine.UI;

// Script for managing strikes. Sets maximum number of strikes, chanes strike UI colour from white to red. LEVEL FAILED FUNCTION EMPTY FOR NOW, EVENTUALLY NEED TO MAKE THE LEVEL END ETC.

public class StrikeManager : MonoBehaviour
{
    public static StrikeManager Instance;
    public LoseScreen loseScreen; 

    [Header("Strikes")]
    public int maxStrikes = 3;
    public int currentStrikes = 0;

    [Header("Strike UI")]
    public Image[] strikeIndicators;

    [Header("Colours")]
    public Color normalColour = Color.white;
    public Color strikeColour = Color.red;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateStrikeUI();
    }

    public void AddStrike()
    {
        if (currentStrikes >= maxStrikes)
        {
            return;
        }

        currentStrikes++;

        Debug.Log("Strike received! " + currentStrikes + "/" + maxStrikes);

        UpdateStrikeUI();

        if (currentStrikes >= maxStrikes)
        {
            LevelFailed();
        }
    }

    private void UpdateStrikeUI()
    {
        for (int i = 0; i < strikeIndicators.Length; i++)
        {
            if (i < currentStrikes)
            {
                strikeIndicators[i].color = strikeColour;
            }
            else
            {
                strikeIndicators[i].color = normalColour;
            }
        }
    }

    private void LevelFailed()
    {
        Debug.Log("THREE STRIKES! LEVEL FAILED!");

        loseScreen.ShowLoseScreen();
    }

    public void ResetStrikes()
    {
        currentStrikes = 0;
        UpdateStrikeUI();
    }
}