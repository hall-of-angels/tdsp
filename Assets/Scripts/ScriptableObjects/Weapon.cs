using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this allows a weapon asset to be created from the asset creation menu
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public int damage = 1;
    public float
        rateOfFirePerSecond = 1,
        projectileRadius = 1,
        speedUnitsPerSecond = 10;
    public int numberOfProjectilesPerShot = 1;
    //angleSecondaryProjectiles: if false, the position of secondary projectiles is offset. if true, secondary projectiles are angled.
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
