using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    public GameObject currentLevel;
    public GameObject nextLevel;
    public Transform player;
    public Transform nextSpawnPoint;
    public FinishPanelManager finishPanelManager;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Bike"))
        {
            triggered = true;
            finishPanelManager.ShowPanel(this);
    
        }
    }


    public void ContinueLevelSwitch()
    {
        // Disable current level, enable next
        currentLevel.SetActive(false);
        nextLevel.SetActive(true);

        // Stop ALL rigidbodies in the player hierarchy (bike body, wheels, etc.)
        Rigidbody2D[] allRigidbodies = player.GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D rb in allRigidbodies)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.simulated = false; // fully freeze for repositioning
        }

        // Move the player to next level spawn point
        player.position = nextSpawnPoint.position;
        player.rotation = Quaternion.identity;

        // Re-enable physics after move
        foreach (Rigidbody2D rb in allRigidbodies)
        {
            rb.simulated = true;
        }
    }


}
