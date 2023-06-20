using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private Transform playerTransform; // Changed to private since it will be assigned automatically
    private Collider2D myCollider;
    private Renderer myRenderer;

    private void Start()
    {
        // Get the Collider2D and Renderer components attached to the object
        myCollider = GetComponent<Collider2D>();
        myRenderer = GetComponent<Renderer>();

        // Find the player object based on the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Make sure to assign the 'Player' tag to the player object.");
        }
    }

    private void Update()
    {
        // Check if the playerTransform is valid before accessing its collider
        if (playerTransform != null)
        {
            // Check if the Y position of the object's collider is higher than the player's collider
            if (myCollider.bounds.max.y < playerTransform.GetComponent<Collider2D>().bounds.max.y)
            {
                // Set the sorting order to 5
                myRenderer.sortingOrder = 5;
            }
            else
            {
                // Reset the sorting order to default (0)
                myRenderer.sortingOrder = 0;
            }
        }
    }
}