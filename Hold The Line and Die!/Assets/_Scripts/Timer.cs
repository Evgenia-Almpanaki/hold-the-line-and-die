using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    private const float MAX_TIME = 120f;
    private Text timerText;
    private float secondsLeft;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Start()
    {
        secondsLeft = MAX_TIME;
        UpdateTimerText();
    }

    private void Update()
    {
        secondsLeft -= Time.deltaTime;
        if (secondsLeft < 0)
            GameManager.GameOver(true);
        UpdateTimerText();
    }

    /// <summary>
    /// Updates the timer UI.
    /// </summary>
    private void UpdateTimerText()
    {
        timerText.text = "Time Left: " + secondsLeft.ToString("0");
    }
}
