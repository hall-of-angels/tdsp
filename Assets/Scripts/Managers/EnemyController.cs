using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Stores reference to the enemy's mover component
    private Mover mover;
    //Stores reference to the enemy's shooter component
    private Shooter shooter;

    private Vector2 directionToPlayer;
    private Vector2 direction;

    public float lockOnIncrement = 0.1f;

    void Start()
    {
        mover = GetComponent<Mover>(); //Gets the player's mover component
        shooter = GetComponent<Shooter>(); //Gets the player's shooter component
        shooter.firing = true;
    }

    void Update()
    {
        directionToPlayer = -(transform.position - GameObject.FindWithTag("Player").transform.position).normalized;
        transform.up = Vector2.Lerp(transform.up, directionToPlayer, lockOnIncrement);
        mover.inputX = transform.up.x;
        mover.inputY = transform.up.y;
    }
}
