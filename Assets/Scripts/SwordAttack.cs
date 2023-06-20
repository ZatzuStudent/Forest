using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemy enemy = other.GetComponent<enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}