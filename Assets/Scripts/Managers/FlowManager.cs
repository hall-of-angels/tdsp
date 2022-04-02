using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    private GameObject player; //Stores the player GameObject

    private void Awake()
    {
    }

    void Start ()
    {
        player = GameObject.FindWithTag("Player"); //Gets the player GameObject
        player.GetComponent<PlayerController>().inputManager.Main.Pause.performed +=_=> PausePlay(); //Makes the game pause when the pause button is pressed
    }

    void Update ()
    {
        
    }

    void PausePlay () //Handles pausing and playing
    {
        if (Time.timeScale != 1) //On resume
        {
            Time.timeScale = 1; //Set the timescale to default
            player.GetComponent<Shooter>().enabled = true; //Enable the player's shooter component
        }
        else //On pause
        {
            Time.timeScale = 0; //Pauses game by setting timescale to 0
            player.GetComponent<Shooter>().enabled = false; //Disables the player's shooter component
        }
    }
}
