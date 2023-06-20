using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.5f;
    public ContactFilter2D movementFilter;
    public Vector2 lastMotionVector;
    public bool isMoving;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Moves player
    private void FixedUpdate()
    {
        if(DialogManager.isActive == true)
        return;

        if (canMove) {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                    success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
            }
        }

        UpdateAnimationDirection();
    }

    // Moves player calculator
    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    
    // Animation idle to run in  4 direction
    private void UpdateAnimationDirection()
    {
        float horizontal = movementInput.x;
        float vertical = movementInput.y;

        Vector2 motionVector = new Vector2(horizontal, vertical);

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        isMoving = horizontal != 0 || vertical != 0;
        animator.SetBool("isMoving", isMoving);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = motionVector.normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }

    }







    //voids
    void OnFire() {
        if(DialogManager.isActive == true)
        return;
        animator.SetTrigger("swordAttack");
    }

    public void LockMovement(){
        canMove = false;
    }

    public void UnLockMovement(){
        canMove = true;
    }

}


