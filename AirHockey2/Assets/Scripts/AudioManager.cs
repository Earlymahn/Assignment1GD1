using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip PuckCollision; // Audio clip for puck collision sound
    public AudioClip Goal; // Audio clip for goal sound
    public AudioClip LostGame;// Audio clip for lost game sound
    public AudioClip WonGame;// Audio clip for won game sound

    private AudioSource audioSource;// Declare a private variable to hold the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Get the AudioSource component attached to the same GameObject and assign it to the audioSource variable
    }

    public void PlayPuckCollision()// Method to play the puck collision sound
    {
        audioSource.PlayOneShot(PuckCollision); // Play the PuckCollision audio clip using the AudioSource
    }

    public void PlayGoal()// Method to play the goal sound
    {
        audioSource.PlayOneShot(Goal);// Play the Goal audio clip using the AudioSource
    }

    public void PlayLostGame()// Method to play the lost game sound
    {
        audioSource.PlayOneShot(LostGame);// Play the LostGame audio clip using the AudioSource
    }

    public void PlayWonGame()// Method to play the won game sound
    {
        audioSource.PlayOneShot(WonGame);// Play the WonGame audio clip using the AudioSource
    }
}

