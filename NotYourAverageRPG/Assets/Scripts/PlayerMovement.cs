//////////////////////////////////
//     Author: Helana Brock    //
/////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator anim;
    private bool isAttacking;
    public bool isDead;

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0) && !isAttacking)
            {
                StartCoroutine(attack()); // Start coroutine allows for a delay. We need that
                                         // so that the animation will play in full on click.
            }
            else
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                anim.SetBool("Attacking", false);           // Player animations (that depend
                anim.SetFloat("Horizontal", movement.x);   // on player direction) have parameters
                anim.SetFloat("Vertical", movement.y);    // that need to be set.
                anim.SetFloat("Speed", movement.magnitude);
            }
        }
    }

    void FixedUpdate()
    {
        if(!isDead) 
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator attack()
    {
        isAttacking = true;
        anim.SetBool("Attacking", true);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", 0);
        yield return new WaitForSeconds(1);
        isAttacking = false;
    }
}
