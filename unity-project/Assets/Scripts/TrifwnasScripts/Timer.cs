using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60.0f;  // Set the time limit in seconds
    private float timer;  // Variable to keep track of elapsed time
    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        timer = 0f;  // Initialize the timer
    }

    void Update()
    {
        // Check if the timer has reached the time limit
        if (timer < timeLimit)
        {
            // Update the timer with the elapsed time
            timer += Time.deltaTime;
            timerText.text = timer.ToString();
            
            // You can perform actions based on the timer value here
            // For example, display remaining time or trigger events at specific intervals
        }
        else
        {
            // Timer has reached the time limit, perform actions as needed
            Debug.Log("Time's up!");

            // Optionally, you can reset the timer or perform other actions
            // timer = 0f;
        }
    }
}
