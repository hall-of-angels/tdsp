using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Stores reference to the enemy's mover component
    private Mover mover;
    //Stores reference to the enemy's shooter component
    private Shooter shooter;
    //Stores reference to the enemy's shooter component
    private Health health;

    private Vector2 directionToPlayer; //Stores the direction to the player

    public float lockOnIncrementPerSecond = 1f; //The amount that the enemy can turn towards the player per second 

    private SpriteRenderer sprite; //Stores reference to the enemy's sprite visual
    private Color originalColor; //Stores the original color of the enemy's sprite visual

    void Awake()
    {
        mover = GetComponent<Mover>(); //Gets the enemy's mover component
        shooter = GetComponent<Shooter>(); //Gets the enemy's shooter component
        health = GetComponent<Health>(); //Gets the enemy's health component
        shooter.firing = true; //Makes the enemy constantly fire

        sprite = GetComponentInChildren<SpriteRenderer>(); //Get the sprite
        originalColor = sprite.color; //Stores original color
    }

    private void Start()
    {
        transform.up = -(transform.position - GameObject.FindWithTag("Player").transform.position).normalized; //Points enemy towards player when spawned
    }

    void Update()
    {
        directionToPlayer = -(transform.position - GameObject.FindWithTag("Player").transform.position).normalized; //Gets the direction towards the player, normalized
        //Turns the enemy towards the player by the increment specified by lockOnIncrementPerSecond
        transform.up = Vector2.Lerp(transform.up, directionToPlayer, lockOnIncrementPerSecond * Time.deltaTime); 
        //Sets the input values of the enemy's mover to the direction toward the player
        mover.inputX = transform.up.x;
        mover.inputY = transform.up.y;
        if (health.isDead) Destroy(gameObject); //If the enemy dies, destroy it
        if (health.currentlyInvincible) sprite.color = Color.red; //If the enemy is in an invincibility period, turn it red
        else sprite.color = originalColor; //Otherwise, set it back to its original color.
    }
}
