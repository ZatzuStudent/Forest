using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Animator animator;
    public float health = 1;

    public Transform target;
    public float speed = 3f;    
    public float followRange = 5f;

    SpriteRenderer spriteRenderer;

    private void Start () {
        animator = GetComponent<Animator>();
    }

void Update(){
    FollowPlayer();
    Flip();
}

// follow player
private void FollowPlayer()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            

            if (distance <= followRange)
            
            {
                animator.SetBool ("isMoving", true);
                
                Vector3 direction = target.position - transform.position;

                direction.Normalize();
                Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
                transform.position = newPosition;
            }
            else{
                animator.SetBool ("isMoving", false);
            }
            
        }
        else{

        }
    }

private void Flip()
{
    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

    float moveX = target.position.x - transform.position.x; // Replace 'target' with the desired reference
    
    if (moveX < 0)
    {
        spriteRenderer.flipX = true;
    }
    else if (moveX > 0)
    {
        spriteRenderer.flipX = false;
    }
}



public float Health {
    set{
            health = value;
            if (health <= 0){
                Defeated();
            }
        }
        get{
            return health;
        }
    }





    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    private void RemoveEnemy() {
        Destroy(gameObject);
    }
}
