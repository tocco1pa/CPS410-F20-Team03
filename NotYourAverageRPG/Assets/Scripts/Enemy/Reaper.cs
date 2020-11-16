using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : EnemyAI
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    public float killDistance;
    public float damage;
    private bool isAttacking;
    public AudioClip hurt;
    public AudioSource aPlayer;

    private void Awake()
    {
        wayPointTarget = wayPoint01;//At the beginning, bat move to the right waypoint
    }
    protected override void Update()
    {
        base.Update();

        Debug.Log(distance);
        if (Vector2.Distance(transform.position, player.position) > attackDistance)
        {
           
            

            if (Vector2.Distance(transform.position, wayPoint01.position) < 0.01f)
            {
                wayPointTarget = wayPoint02;
                sp.flipX = false;
            }

            if (Vector2.Distance(transform.position, wayPoint02.position) < 0.01f)
            {
                sp.flipX = true ;
                wayPointTarget = wayPoint01;
            }
            Debug.Log(wayPointTarget);
            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        }
        if (distance <= killDistance && !isAttacking)
        {
            
            StartCoroutine(Attack());
        }


    }
    
    IEnumerator Attack()
    {
        isAttacking = true;
        playerChar.currentHealth -= damage;
        yield return new WaitForSeconds(2);
        aPlayer.PlayOneShot(hurt);
        isAttacking = false;

    }

    
}
