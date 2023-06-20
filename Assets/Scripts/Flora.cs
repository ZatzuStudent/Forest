using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flora : MonoBehaviour
{
    public float interactionRange = 2f;
    public DialogTrigger trigger;
    public GameObject targetObject;

    void Update()
    {
        // Check if the player is within range and has pressed the "E" key
        if (Input.GetKeyDown(KeyCode.E) && (targetObject.activeSelf))
        {
            // Trigger the interaction
            trigger.StartDialog();
            targetObject.SetActive(false);
        }

        if (IsPlayerInRange())
        {
            targetObject.SetActive(true);
        }
        else
        {
            targetObject.SetActive(false);
        }
    }

    bool IsPlayerInRange()
    {
        // Get the player's position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            float distance = Vector3.Distance(transform.position, playerPosition);
            return distance <= interactionRange;
        }

        return false;
    }
}