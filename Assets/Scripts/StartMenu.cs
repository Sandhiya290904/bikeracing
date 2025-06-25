using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject gameplayUI;
    public GameObject startScreenUI;
    public GameObject levelPanel;
    public GameObject finishPanel;

    [Header("Bike")]
    public driveControl bikeScript; 

    [Header("Level Layouts")]
    public GameObject[] levels;
    private int currentLevelIndex = 0;

  

    void Start()
    {
        gameplayUI.SetActive(false);
    }

    public void LoadLevel(int index)
    {
        if (index < 0 || index >= levels.Length) return;

        foreach (GameObject level in levels)
            level.SetActive(false);

        levels[index].SetActive(true);

        currentLevelIndex = index;
        levelPanel.SetActive(false);

        PlayGame();
    }

    public void PlayGame()
    {
        foreach (GameObject level in levels)
            level.SetActive(false);

        levels[currentLevelIndex].SetActive(true);

        gameplayUI.SetActive(true);
        startScreenUI.SetActive(false);
        levelPanel.SetActive(false);

        Time.timeScale = 1f;
        if (bikeScript != null)
            bikeScript.EnableControls();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void OpenLevels()
    {
        levelPanel.SetActive(true);
        startScreenUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        startScreenUI.SetActive(true);
        levelPanel.SetActive(false);
        gameplayUI.SetActive(false);
    }


    }
