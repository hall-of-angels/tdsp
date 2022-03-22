using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float invincibilityPeriod = 0.5f;
    [SerializeField] private int currentHealth;
    public bool isDead = false;
    private bool currentlyInvincible = false;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update () 
    {
        if (currentHealth <= 0) isDead = true;
    }

    private IEnumerator _TakeDamage (int _damage) 
    {
        if (currentlyInvincible) yield break;
        currentHealth -= _damage;
        currentlyInvincible = true;
        yield return new WaitForSeconds(invincibilityPeriod);
        currentlyInvincible = false;
    }

    public void TakeDamage (int damage) {StartCoroutine(_TakeDamage(damage));}
}
