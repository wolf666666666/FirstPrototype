using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject continuePanel;

    public Button continueButton;
    public Button[] dayButtons;

    public void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        continuePanel.SetActive(false);

        UpdateContinueButton();
        UpdateDayButtons();
    }

    private void UpdateContinueButton()
    {
        continueButton.interactable = SaveManager.HasSave();
    }

    private void UpdateDayButtons()
    {
        for (int i = 0; i < dayButtons.Length; i++)
        {
            int day = i + 1;

            dayButtons[i].interactable = SaveManager.IsDayUnlocked(day);
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SaveManager.DeleteSave();
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        continuePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Continue()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        continuePanel.SetActive(true);

        UpdateDayButtons();
    }

    public void LoadDay(int day)
    {
        Time.timeScale = 1f;

        if (!SaveManager.IsDayUnlocked(day))
        {
            Debug.LogWarning("Day " + day + " is not unlocked.");
            return;
        }

        SceneManager.LoadScene(day);
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        continuePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
