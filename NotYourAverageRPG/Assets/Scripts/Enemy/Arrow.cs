using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float moveSpeed = 9f;
    Rigidbody2D rb;
    SpriteRenderer sp;
    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, player.position.y);
            sp.flipX = true;
        }

        else
        {
            rb.velocity = new Vector2(moveSpeed, player.position.y);
            sp.flipX = false;

        }
        StartCoroutine(DestroyArrow());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}