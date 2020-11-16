using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    float moveSpeed = 9f;
    Rigidbody2D rb;
    SpriteRenderer sp;
    Transform player;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        rb.velocity = new Vector2(playerMovement.movement.x * moveSpeed, playerMovement.movement.y * moveSpeed);

        if(playerMovement.movement.x == 0 && playerMovement.movement.y == 0)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }

        else
        {
            rb.velocity = new Vector2(playerMovement.movement.x * moveSpeed, playerMovement.movement.y * moveSpeed);
        }
        if (playerMovement.movement.x > 0)
        {
            Debug.Log("yeet");
            sp.flipX = false;
        }

        else if (playerMovement.movement.x < 0)
        {
            
            sp.flipX = true;

        }

        else if(playerMovement.movement.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if(playerMovement.movement.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
