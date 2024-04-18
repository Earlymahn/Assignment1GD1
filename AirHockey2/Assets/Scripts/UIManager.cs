using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UiManager : MonoBehaviour
{

    [Header("Canvas")]// Define public variables to hold references to canvas game objects
    public GameObject CanvasGame;// Reference to the main game canvas
    public GameObject CanvasRestart;// Reference to the restart canvas

    [Header("CanvasRestart")]// Define public variables to hold references to UI elements within the restart canvas
    public GameObject WinTxt;// Reference to the "Win" text object within the restart canvas
    public GameObject LooseTxt;// Reference to the "Loose" text object within the restart canvas

    [Header("Other")]// Define public variables to hold references to other scripts/components
    public AudioManager audioManager;// Reference to the AudioManager script for managing audio

    public ScoreScript scoreScript; // Reference to the ScoreScript for managing game scores

    public PuckScript puckScript;// Reference to the PuckScript for managing the puck
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script for player movement
    public AiScript aiScript;// Reference to the AiScript for controlling the AI opponent

    public float countdownDuration = 3f; // Duration of the countdown in seconds
    public Text countdownText; // Reference to the UI Text element to display the countdown

    private float countdownTimer; // Timer for the countdown

    void Start()
    {
        // Start the countdown when the game starts
        StartCountdown();
    }

    void Update()
    {
        // Update the countdown timer
        countdownTimer -= Time.deltaTime;

        // Update the UI text to display the remaining time
        countdownText.text = Mathf.CeilToInt(countdownTimer).ToString();

        // Check if the countdown has reached zero
        if (countdownTimer <= 0)
        {
            // Stop the countdown
            StopCountdown();

            // Perform any actions you want to happen when the countdown finishes
            // For example, start the game or perform some initialization
            StartGame();
        }
    }

    // Method to start the countdown
    void StartCountdown()
    {
        countdownTimer = countdownDuration;
    }

    // Method to stop the countdown
    void StopCountdown()
    {
        countdownTimer = 0;
    }

    // Method to start the game
    void StartGame()
    {
        Time.timeScale = 1;
        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosition();
        aiScript.ResetPosition();
    }
    public void ShowRestartCanvas(bool didAiWin)// Method to show the restart canvas based on whether the AI won or not
    {
        Time.timeScale = 0;// Pause the game

        CanvasGame.SetActive(false);// Disable the main game canvas and enable the restart canvas
        CanvasRestart.SetActive(true);

        if (didAiWin) // Play appropriate audio based on whether AI won or not, and show corresponding text
        {
            audioManager.PlayLostGame(); // Play lost game audio
            WinTxt.SetActive(false);// Hide win text
            LooseTxt.SetActive(true);// Show lose text
        }
        else
        {
            audioManager.PlayWonGame();// Play won game audio
            WinTxt.SetActive(true);// Show win text
            LooseTxt.SetActive(false);// Hide lose text
        }
    }

    public void RestartGame()// Method to restart the game
    {
        Time.timeScale = 1;// Resume the game

        CanvasGame.SetActive(true); // Enable the main game canvas and disable the restart canvas
        CanvasRestart.SetActive(false);
        // Reset game scores, puck position, player position, and AI position
        scoreScript.ResetScores();// Reset scores
        puckScript.CenterPuck();// Center the puck
        playerMovement.ResetPosition(); // Reset player position
        aiScript.ResetPosition(); // Reset AI position
    }
}

