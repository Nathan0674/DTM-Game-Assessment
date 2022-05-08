using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script (not the comments) are from a tutorial: https://www.youtube.com/watch?v=4Wh22ynlLyk
public class EnemyController : MonoBehaviour
{
    // Declares all relevant gameobjects, variables and components.
    // player refers to the position of the player.
    // enemyrb2D is the rigid body component of the enemy gameobject.
    // movement is the movement of the enemy object/prefab.
    // moveSpeed is the speed at which the enemy object/prejabs move towards the player.
    public Transform player;
    private Rigidbody2D enemyRb2D;
    private Vector2 movement;
    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody component of the enemy and asigns it to a value so that we can edit its transform component and allow it to move.
        enemyRb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Compares the position of the player and the enemy objects and uses this value to determine the direction that the enemy needs to move in.
        // Positions the enemy object to be facing the player at all times using the x and y values of the direction variable.
        // Converts the angle value that this outputs from radians to degrees.
        // Sets the rotation of the enemies rigidbody to the angle variable, which changes the rotation of the enemy.
        // Sets the movement variable to the direction value.
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyRb2D.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    // Moves and rotates the enemy by the movement value every frame using the values from the update void.
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    // Uses the moveposition method to change the position of the enemies rigidbody.
    // This is done using a vector 2 and applying the direction and movespeed variables with the time.deltatime to add a delay.
    void moveCharacter(Vector2 direction)
    {
        enemyRb2D.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
