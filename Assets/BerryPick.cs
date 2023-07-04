using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryPick : MonoBehaviour
{
    public GameObject berryFull;
    public GameObject berryEmpty;

    public float detectionRadius = 2f; // Radius for detecting the player
    public KeyCode interactionKey = KeyCode.E; // Key for interaction

    public GameObject berriesPrefab; // Prefab for spawning berries
    public int numberOfObjects = 5; // Number of objects to spawn
    public float spread = 2f; // Spread for random positions

    private GameObject playerObject; // Reference to the player object

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // Find the player object by tag
    }

    private void Update()
    {
        if (playerObject != null && Input.GetKeyDown(interactionKey))
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);
            if (distance <= detectionRadius && !berryEmpty.activeSelf)
            {
                Destroy(berryFull);

                berryEmpty.SetActive(true);
                SpawnObjects();

                Debug.Log("Player is near the collider, and the E key is pressed!");
            }
        }
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 position = transform.position;
            position.x += spread * Random.value - spread / 2f;
            position.z += spread * Random.value - spread / 2f;
            GameObject go = Instantiate(berriesPrefab, position, Quaternion.identity);
            go.SetActive(true);
        }
    }
}