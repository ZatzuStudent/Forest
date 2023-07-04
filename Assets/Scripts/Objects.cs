using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public string loveTagName = "Player";
    public int belowSortingOrder = 0;
    public int aboveSortingOrder = 5;

    private Collider2D objectCollider;
    private Transform loveObject;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // Get the collider attached to the object
        objectCollider = GetComponent<Collider2D>();

        // Find the object with the "Love" tag
        loveObject = GameObject.FindGameObjectWithTag(loveTagName).transform;

        // Get the SpriteRenderer component attached to the object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (loveObject == null)
        {
            Debug.LogWarning("No object with the tag 'Love' found.");
            return;
        }

        // Check if the love object is below the collider
        bool isBelow = loveObject.position.y < objectCollider.bounds.center.y;

        // Set the sorting order based on the result
        int sortingOrder = isBelow ? belowSortingOrder : aboveSortingOrder;
        spriteRenderer.sortingOrder = sortingOrder;
    }
}