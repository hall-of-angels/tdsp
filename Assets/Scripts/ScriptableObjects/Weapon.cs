using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectile", menuName = "Projectile")]
public class Weapon : ScriptableObject
{
    public float 
        damage = 1,
        rateOfFirePerSecond = 1,
        projectileRadius = 1,
        speedUnitsPerSecond = 10;
    public int numberOfProjectilesPerShot = 1;
    public bool angleSecondaryProjectiles =  false;
    public float offsetInUnitsOrDegrees = 0;

    public bool projectileExplodes = false;

    public float 
        explosionTime = 5,
        explosionLingeringPeriod = 0.5f,
        explosionRadius = 5;

    public Color
        projectileColor = Color.black,
        explosionColor = Color.red;
}
