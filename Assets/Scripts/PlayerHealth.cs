using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Text healthIndicator;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        UpdatehealthIndicator();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdatehealthIndicator();
        if(health <= 0)
        {
            Defeated();
        }
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void UpdatehealthIndicator()
    {
        healthIndicator.text = "" + health.ToString();
    }

    public void Revieve(){
        health = maxHealth;
        UpdatehealthIndicator();
    }
}
