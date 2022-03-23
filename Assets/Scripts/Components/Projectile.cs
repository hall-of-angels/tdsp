using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //These variables are all passed in by the Shooter component
    public float size;
    public float speed;
    public Color color;
    public bool explodes;
    public float explosionTime;
    public float explosionLingeringPeriod;
    public Color explosionColor;

    //These variables store references to components
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    //Flag for whether the projectile has begun explosion
    private bool isExploding;

    void Awake()
    {
        //Assign references to components
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    
        transform.localScale = Vector2.one * size; //sets the size of the projectile by scaling the transform

        //sets speed of rigidbody, projectiles will be spawned as a child of the player so this direction will rotate with the player
        rb.velocity = transform.up * speed; 

        sprite.color = color; //sets the color of the projectile's sprite

    }

    void Update()
    {
        
    }
}
