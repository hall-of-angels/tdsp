using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveNumber; //Index of current wave

    public List<GameObject> spawnableEnemies; //A list of enemies which are able to be spawned

    public float minWaveEnemyCountMultiplier = 0.25f, maxWaveEnemyCountMultiplier = 0.5f; //A number is chosen between this range and multiplied by the wave number

    public float timeUntilEnemiesAreEnabled = 0.5f; //Enemies spawn disabled until this amount of time has passed

    public float spawnRadius = 3f;

    private int enemiesInWave; //The total number of enemies in the wave

    private Camera mainCam; //Stores reference to main camera to reduce lag

    [SerializeField] bool spawnWave; //Manually spawn a wave

    void Awake()
    {
        mainCam = Camera.main; //Stores reference to main camera
    }

    void Update()
    {
        if (spawnWave) //If the flag to manually spawn a wave is raised
        {
            SpawnWave(); //Spawn a wave
            spawnWave = false; //Set the flag to false
        }
    }

    public void SpawnWave ()
    {
        //Determines the number of enemies which should be spawned by multiplying the wave number by a random number in a range
        enemiesInWave = Mathf.RoundToInt((Random.Range(minWaveEnemyCountMultiplier, maxWaveEnemyCountMultiplier) * waveNumber) + 1);
        for (int i = 0; i < enemiesInWave; i++) //For the number of times determined in the above step,
        {
            GameObject enemy = Instantiate(spawnableEnemies[Random.Range(0, spawnableEnemies.Count)]); //Instantiate a random enemy from the list

            StartCoroutine(StartingConditions(enemy)); //Apply some starting conditions to the spawned enemy
        }
        waveNumber++; //Add one to the wave number
    }
    
    public IEnumerator StartingConditions (GameObject enemy) //Starting conditions applied to the spawned enemy
    {
        Shooter enemyShooter = enemy.GetComponent<Shooter>(); //Stores a reference to the enemy's shooter component
        EnemyController enemyController = enemy.GetComponent<EnemyController>(); //Stores a reference to the enemy's controller

    CheckPosition: //This block of code determines where the enemy spawns
        Vector2 spawnPosition = new Vector2(
            //Sets the spawn position within the limits of the camera
            Random.Range(-mainCam.orthographicSize, mainCam.orthographicSize) * mainCam.aspect, 
            Random.Range(-mainCam.orthographicSize, mainCam.orthographicSize)
        );
        //If the spawn position is within a certain range of the player, go back and find another spawn position
        if (Vector2.Distance(spawnPosition, GameObject.FindWithTag("Player").transform.position) < spawnRadius) goto CheckPosition;

        enemy.transform.position = spawnPosition; //Sets the enemy's position to the spawn position

        enemyShooter.enabled = false; enemyController.enabled = false; //Disable enemy AI
        yield return new WaitForSeconds(timeUntilEnemiesAreEnabled); //Wait for the specified time
        enemyShooter.enabled = true; enemyController.enabled = true; //Enable enemy AI
    }
}