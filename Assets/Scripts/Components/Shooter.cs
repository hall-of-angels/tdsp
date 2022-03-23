using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Weapon weapon; //Reference to the weapon asset being used by the entity
    public bool firing; //Input on whether the weapon is being fired
    public float rateOfFireTimer; //Timer which makes sure the projectile fires according to its rate of fire
    private GameObject projectilePrefab; //Stores projectile prefab so that it can be instantiated

    void Awake () 
    {
        //Loads projectile prefab file into a variable
        projectilePrefab = (GameObject)Resources.Load("Prefabs/Projectile", typeof(GameObject));
    }

    void Update()
    {
        if (firing && rateOfFireTimer <= 0) //If the fire rate allows it, and the input for firing is enabled
        {
            for (int i = 0; i < weapon.numberOfProjectilesPerShot; i++) //For each projectile that needs to be spawned
            {
                Transform projectileObject = Instantiate(projectilePrefab).transform; //Instantiate a projectile and store a reference to it
                Projectile projectile = projectileObject.GetComponent<Projectile>(); //Store the projectile component of the projectile

                //Calculate offset value using equation detailed in planning document
                float offset = ((weapon.offsetInUnitsOrDegrees * (weapon.numberOfProjectilesPerShot - 1)) / 2) - weapon.offsetInUnitsOrDegrees * i;

                //Depending on whether the offset is positional or angular, apply the desired offset
                if (weapon.angleSecondaryProjectiles) projectileObject.eulerAngles = new Vector3(0,0,offset);
                else projectileObject.position = new Vector3(offset,0,0);

                //Pass all the specified variables through to the projectile
                projectile.size = weapon.projectileRadius;
                projectile.speed = weapon.speedUnitsPerSecond;
                projectile.color = weapon.projectileColor;
                projectile.explodes = weapon.projectileExplodes;
                projectile.explosionTime = weapon.explosionTime;
                projectile.explosionLingeringPeriod = weapon.explosionLingeringPeriod;
                projectile.explosionColor = weapon.explosionColor;
                projectile.explosionRadius = weapon.explosionRadius;
            }
            //Sets timer for fire rate
            rateOfFireTimer = 1 / weapon.rateOfFirePerSecond;
        }
        //Subtract frametime from fire rate timer
        rateOfFireTimer -= Time.deltaTime;
    }
}
