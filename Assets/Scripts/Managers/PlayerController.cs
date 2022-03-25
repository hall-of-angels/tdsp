using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Input class has been set up and this is a container for an instance of it
    public PlayerInput inputManager;
    //Stores reference to the player's mover component
    private Mover mover;
    //Stores reference to the player's shooter component
    private Shooter shooter;

    void Awake()
    {
        inputManager = new PlayerInput(); //Creates an instance of the player controller and stores it
        mover = GetComponent<Mover>(); //Gets the player's mover component
        shooter = GetComponent<Shooter>(); //Gets the player's shooter component

        //When the movement input is performed, take the input as a Vector2 and pass it into the Move() function
        inputManager.Main.Move.performed += input => Move(input.ReadValue<Vector2>());
        //When the shooting/look direction input is performed, take the input as a Vector2 and pass it into the ShootLook() function
        inputManager.Main.ShootLook.performed += input => ShootLook(input.ReadValue<Vector2>());
        inputManager.Main.ShootLook.canceled +=_=> shooter.firing = false; //Stops the player from shooting when the input is not being performed
    }

    void Move (Vector2 input) //Applies the movement input to the input of the Mover component of the player
    {
        mover.inputX = input.x;
        mover.inputY = input.y;
    }

    void ShootLook (Vector2 input) //Handles looking and shooting logic
    {
        transform.up = input; //Rotates the player so that they are facing the direction of the shooting input
        shooter.firing = true; //Makes the player shoot
    }

    void OnEnable ()
    {
        inputManager.Enable(); //Enable the input manager when the player is enabled
    }

    void OnDisable ()
    {
        inputManager.Disable(); //Disable the input manager when the player is disabled
    }
}
