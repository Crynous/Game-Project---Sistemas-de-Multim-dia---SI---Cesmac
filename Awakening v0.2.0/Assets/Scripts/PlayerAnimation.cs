using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (movement != Vector2.zero)
        {
            animator.SetBool("isWalking", true);

            if (movement.x > 0)
                animator.Play("moveRight");
            else if (movement.x < 0)
                animator.Play("moveLeft");
            else if (movement.y > 0)
                animator.Play("moveUp");
            else if (movement.y < 0)
                animator.Play("moveDown");
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.Play("Idle");
        }
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
