using UnityEngine;
using UnityEngine.SceneManagement;

public class UIActions : MonoBehaviour
{
    public GameObject startPanel; // merged panel containing all menu stuff
    public GameObject gameUI;     // gameplay UI: coin count, restart button, etc.

    public void RestartGame()
    {
        Time.timeScale = 1f; // make sure timescale resets
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToHome()
    {
        startPanel.SetActive(true);  // re-show full start/shop/level panel
        gameUI.SetActive(false);     // hide gameplay UI
        Time.timeScale = 0f;         // pause the game
    }

    public void ResumeFromHome()
    {
        startPanel.SetActive(false); // hide all menus
        gameUI.SetActive(true);      // show gameplay stuff
        Time.timeScale = 1f;         // resume game
    }
}
