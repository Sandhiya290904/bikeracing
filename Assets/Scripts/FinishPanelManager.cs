using UnityEngine;

public class FinishPanelManager : MonoBehaviour
{
    public GameObject panel;
    private FinishLineTrigger currentTrigger;

    public void ShowPanel(FinishLineTrigger trigger)
    {
        currentTrigger = trigger;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;

        if (currentTrigger != null)
        {
            currentTrigger.ContinueLevelSwitch();
        }
    }
}
