using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ScoreManager : MonoBehaviour //This class manages writing the score to the score file
{
    public int currentScore;
    public string path; //Path to the text file containing high scores
    private bool hasWritten; //Keep track of whether the current game's score has been written to the file
    private int waveNumber; //Stores wave number from wave manager
    private GameObject player; //stores player

    public GameObject scoreText, waveText; //Stores the gameObjects for the score and wave counter text objects

    void Start()
    {
        player = GameObject.FindWithTag("Player"); //stores the player
        path = Application.dataPath + "/scores.txt"; //Sets path to a file scores.txt in game folder
        currentScore = 0; //Stores score of current game
        hasWritten = false; //Sets this value to false by default
    }

    void Update () 
    {
        waveNumber = GetComponent<WaveManager>().waveNumber; //Gets wave number
        if (player.GetComponent<Health>().isDead & !hasWritten) //If the game has ended and the score has not been written
        {
            WriteScoreToFile(); //Write the current score and wave to the file 
            hasWritten = true; //Makes sure that the score doesn't keep getting written
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = currentScore.ToString(); //Sets the score text to the current score
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + waveNumber.ToString(); //Sets wave text to current wave
    }

    public void WriteScoreToFile () //Writes the current wave and score to the file
    {
        if (!File.Exists(path)) { //Check whether the file exists
            File.WriteAllText(path, ""); //If it doesn't, create it
        }
        File.AppendAllText(path, currentScore +" "+ waveNumber +"\n"); //Write the score and wave to file
    }
}
