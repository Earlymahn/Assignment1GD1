using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    public float countdownDuration = 3f;

    private float countdownTimer;
    private bool timer_is_started = false;
    void Start()
    {
        countdownTimer = countdownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_is_started == true)  //countdown timer for main menue and start of time
        {
            countdownTimer -= Time.deltaTime;

            // Update the countdown text
            countdownText.text = Mathf.CeilToInt(countdownTimer).ToString(); //mathametical function, it counts in whole numbers

            // Start the game when countdown reaches zero
            if (countdownTimer <= 0f) ;
        }
    }
}