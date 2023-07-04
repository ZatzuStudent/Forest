using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    private Renderer renderer;

    public float farDistance = 2f;  // Define the threshold for "far" distance

    private GameObject playerObject; // Reference to the player object

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        playerObject = GameObject.FindGameObjectWithTag("Player"); // Find the player object by tag
    }
    private void Update()
    {
        // Calculate the distance between this object and the player
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);

        // Check if the distance is greater than the farDistance
        if (distance > farDistance)
        {
            renderer.enabled = false;
        }
        else
        {
            renderer.enabled = true;
        }
    }
}