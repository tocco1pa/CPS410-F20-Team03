using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : EnemyAI
{
    public float killDistance;
    public float damage;
    private bool isAttacking;
    public AudioClip hurt;
    public AudioSource aPlayer;

    IEnumerator Attack()
    {
        isAttacking = true;
            playerChar.currentHealth -= damage;
        aPlayer.PlayOneShot(hurt);
        yield return new WaitForSeconds(2);
        isAttacking = false;
        
    }

    protected override void Update()
    {
        base.Update();
        if (distance <= killDistance && !isAttacking)
        {
            StartCoroutine(Attack());
        }

        
    }

    protected override void Move()
    {
        base.Move();

        if(currenthealth <= currenthealth / 2)
        {
            RunAway();
        }
    }
    void RunAway()
    {
         
            transform.position = Vector2.MoveTowards(transform.position, player.position, -(2 *moveSpeed) * Time.deltaTime);
            
    }

}
