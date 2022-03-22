using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    [Range(-1, 1)] public int inputX, inputY;
    
    private Rigidbody2D rb;
    
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(inputX,inputY).normalized * speed;
    }
}
