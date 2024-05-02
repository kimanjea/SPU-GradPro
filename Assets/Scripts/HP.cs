using UnityEngine;
using UnityEngine.UI;

public class AttemptsReminder : MonoBehaviour
{
    public int maxAttempts = 3; // Set the maximum number of attempts
    private int remainingAttempts; // Remaining number of attempts
    private Text textUI; // Reference to the Text UI component

    void Start()
    {
        // Get a reference to the Text UI component
        textUI = GetComponent<Text>();
        
        // Set the initial remaining number of attempts
        remainingAttempts = maxAttempts;
        
        // Update the UI display
        UpdateUI();
    }

    // Reduce the number of attempts
    public void ReduceAttempt()
    {
        remainingAttempts--;

        // Update the UI display
        UpdateUI();

        // Check if zero attempts reached
        if (remainingAttempts <= 0)
        {
            // Perform the desired action, such as disabling a button or displaying a failure message
            Debug.Log("You've run out of attempts!");
        }
    }

    // Update the UI display
    void UpdateUI()
    {
        // Update the text displayed in the Text UI
        textUI.text = "Remaining Attempts: " + remainingAttempts.ToString();
    }
}
