using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //these variables are self explanatory
    [SerializeField] private int maximumHealth = 10;
    [SerializeField] private float invincibilityPeriod = 0.5f; //in seconds
    [SerializeField] private int currentHealth;
    public bool isDead = false; //flag for whether the entity has died
    public bool currentlyInvincible = false; //flag for whether the entity is currently in an invincibility period

    void Awake()
    {
        currentHealth = maximumHealth; //sets current health to maximum health when the entity is spawned
    }

    void Update () 
    {
        if (currentHealth <= 0) isDead = true; //if the entity's health drops below zero, the death flag is set
    }

    private IEnumerator _TakeDamage (int _damage) //coroutine which handles taking damage and the invincibility period
    {
        if (!currentlyInvincible) {//stops the coroutine if the player is in an invincibility period
            currentHealth -= _damage; //takes the specified amount of damage off of the current health
            currentlyInvincible = true; //begins invincibility period
            yield return new WaitForSeconds(invincibilityPeriod); //begins timer for invincibility period
            currentlyInvincible = false; //ends invincibility period after the timer ends
        } 
    }

    //this is just to provide an easier way of calling the TakeDamage logic without having to call a coroutine the normal way
    public void TakeDamage (int damage) {StartCoroutine(_TakeDamage(damage));} 
}
