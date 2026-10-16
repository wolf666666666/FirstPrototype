using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winPanel;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    public void ShowWinScreen()
    {
        // Work out which day we just completed.
        int currentDay = SceneManager.GetActiveScene().buildIndex;

        // Unlock the next day immediately.
        int nextDay = currentDay + 1;

        if (nextDay < SceneManager.sceneCountInBuildSettings)
        {
            SaveManager.UnlockDay(nextDay);
        }

        winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        int currentDay = SceneManager.GetActiveScene().buildIndex;
        int nextDay = currentDay + 1;

        if (nextDay < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextDay);
        }
        else
        {
            Debug.Log("There are no more days.");
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}