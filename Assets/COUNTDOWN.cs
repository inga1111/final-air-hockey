using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    private float countdownTime = 3f;
    private bool countdownStarted = false;

    void Update()
    {
        if (countdownStarted)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime > 0)
            {
                int seconds = Mathf.CeilToInt(countdownTime);
                countdownText.text = seconds.ToString();
            }
            else
            {
                countdownText.text = "GO!";
                // Add code here to start the game or do any other action
                countdownStarted = false;
            }
        }
    }

    public void StartCountdown()
    {
        countdownStarted = true;
        countdownTime = 3f; // Reset countdown time
    }
}
