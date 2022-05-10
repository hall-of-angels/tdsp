using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FlowManager : MonoBehaviour
{
    private GameObject player; //Stores the player GameObject
    public bool gameRunning = false; //Keeps track of whether there is a game in progress
    private bool previousFrameState = true; //Stores the game's state in the previous frame
    [SerializeField] private GameObject gameplayUI, mainMenu, restartButton;

    void Start ()
    {
        player = GameObject.FindWithTag("Player"); //Gets the player GameObject
        player.GetComponent<PlayerController>().inputManager.Main.Pause.performed +=_=> PausePlay(gameRunning); //Makes the game pause when the pause button is pressed
    }

    void Update () {
        if (previousFrameState != gameRunning) { //If the game's state has changed
            if (!gameRunning) { //If the game has stopped
                PausePlay(true); //Pause the game
            }
            else { //If the game has begun or resumed
                PausePlay(false); //Resume the game
            }
        }
        previousFrameState = gameRunning; //store the game state in the previous state
        if (player.GetComponent<Health>().isDead) {
            restartButton.SetActive(true); //show the reset button once the player dies
        }
    }

    public void ReloadScene () {SceneManager.LoadScene(0);}

    //Handles pausing and playing
    public void PausePlay (bool pauseGame) 
    {
        if (pauseGame == false) //On resume
        {
            Time.timeScale = 1; //Set the timescale to default
            player.GetComponent<Shooter>().enabled = true; //Enable the player's shooter component
            gameplayUI.SetActive(true); mainMenu.SetActive(false); //Enable main menu and disable gameplay UI
            gameRunning = true; //toggle game state
        }
        else if (pauseGame == true) //On pause
        {
            Time.timeScale = 0; //Pauses game by setting timescale to 0
            player.GetComponent<Shooter>().enabled = false; //Disables the player's shooter component
            gameplayUI.SetActive(false); mainMenu.SetActive(true); //Enable main menu and disable gameplay UI
            gameRunning = false;
        }
    }
}
