using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Florance : MonoBehaviour
{
    public float interactionRange = 2f;
    public DialogTrigger trigger;
    public DialogTrigger triggerTwo;
    public DialogTrigger triggerThree;
    public GameObject LetterE;
    private Inventory inventoryBerry;
    private bool hasInteracted = false;
    private bool isFull = false;
    public int berriesRequired = 5;

    private void Start()
    {
        inventoryBerry = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (hasInteracted && !isFull)
        {
            if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
            {
                BerryGive();
            }
            return;
        }

            if (isFull)
        {
            if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
            {
                HeThanks();
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
            {
                TalkTo();
            }
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

    void TalkTo()
    {
            // Check if the player is within range and has pressed the "E" key
        
        {
            // Trigger the interaction
            trigger.StartDialog();
            LetterE.SetActive(false);
            hasInteracted = true;

        }

        if (IsPlayerInRange())
        {
            LetterE.SetActive(true);
        }
        else
        {
            LetterE.SetActive(false);
        }
    }

    void BerryGive()
    {   
        inventoryBerry = FindObjectOfType<Inventory>();
            if (inventoryBerry.berryCount >= berriesRequired)
            {
                inventoryBerry.berryCount -= berriesRequired;
                inventoryBerry.UpdateBerryCountText();
                triggerTwo.StartDialog();
                Debug.Log("NPC: Thank you for the berries!");
                isFull = true;
            }
            else{
                TalkTo();
            }
    }

        void HeThanks()
    {   
        {
            triggerThree.StartDialog();
            LetterE.SetActive(false);
            hasInteracted = true;

        }

        if (IsPlayerInRange())
        {
            LetterE.SetActive(true);
        }
        else
        {
            LetterE.SetActive(false);
        }
    }

}