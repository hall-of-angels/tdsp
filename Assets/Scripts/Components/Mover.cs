using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 10; //speed at which the entity moves, in units per second approx.

    //inputs for direction, controlled by manager class, or manually in inspector using sliders
    [Range(-1, 1)] public float inputX, inputY; 
    
    private Rigidbody2D rb; //stores a reference to the entity's attached Rigidbody2D
    private Vector2 direction; //stores the current input direction, declared here for better memory usage

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>(); //assigns the entity's rigidbody to the rb variable
    }

    void Update()
    {
        //gets the X and Y input directions, normalizes them, and stores them in the direction vector
        direction = new Vector2(inputX,inputY).normalized; 
        //multiplies the direction vector by the speed specified, and applies it to the rigidbody's velocity
        rb.velocity = direction * speed;
    }
}
