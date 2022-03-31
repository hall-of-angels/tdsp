using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //These variables are all passed in by the Shooter component
    public int damage;
    public float size;
    public float speed;
    public Color color;
    public bool explodes;
    public float explosionTime;
    public float explosionLingeringPeriod;
    public float explosionRadius;
    public Color explosionColor;
    public string tagsToDamage;

    //These variables store references to components
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    //Flag for whether the projectile has begun explosion
    private bool isExploding;

    void Start()
    {
        //Assign references to components
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    
        transform.localScale = Vector2.one * size; //sets the size of the projectile by scaling the transform

        //sets speed of rigidbody, projectiles will be spawned at the same position and rotation as the player so this direction will rotate with the player
        rb.velocity = transform.up * speed; 

        sprite.color = color; //sets the color of the projectile's sprite

        if (explodes) StartCoroutine(Explode());
    }

    void Update () //Just deletes any stray projectiles once they get too far from the arena
    {
        Vector2 position = transform.position;
        if (position.x < -20 || position.x > 20) Destroy(gameObject);
        if (position.y < -20 || position.y > 20) Destroy(gameObject);
    }

    IEnumerator Explode () //Logic for when the projectile explodes
    {
        yield return new WaitForSeconds(explosionTime); //Waits for the specified explosion time
        isExploding = true; //Sets the flag for whether the projectile is exploding
        rb.velocity = Vector2.zero; //Stops the projectile's movement
        transform.localScale = Vector2.one * explosionRadius; //Resizes the projectile
        sprite.color = explosionColor; //Sets the color of the projectile's sprite
        yield return new WaitForSeconds(explosionLingeringPeriod); //Waits for the specified lingering period
        Destroy(gameObject); //Deletes the projectile
    }

    void OnTriggerStay2D (Collider2D col) 
    {
        if (tagsToDamage.Contains(col.gameObject.tag)) 
        {
            if ((explodes && isExploding) || !explodes)
                col.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
