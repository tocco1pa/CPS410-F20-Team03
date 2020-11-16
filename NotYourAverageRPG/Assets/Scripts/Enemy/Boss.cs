using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyAI
{
    private bool IsAttacking;
    public GameObject arrow;
    public float killDistance;
    public float damage;
    public Canvas winScreen;

    protected override void Update()
    {
        base.Update();

        if (!IsAttacking)
        {
            StartCoroutine(SetupAttack());
        }
        if (isDead) 
        {
            winScreen.enabled = true;
        }
        else 
        {
            winScreen.enabled = false;
        }

    }
    IEnumerator SetupAttack()
    {
        IsAttacking = true;
        int attack = Random.Range(0,2 );
        yield return new WaitForSeconds(4); 
        if (distance < killDistance)
        {
            StartCoroutine(MeleeAttack());
        }
        else if(attack == 0)
        {
            StartCoroutine(chargeAttack());
        }

        else
        {
            StartCoroutine(RangeAttack());
        }
      
    }
    IEnumerator chargeAttack()
    {
        transform.gameObject.tag = "BoshRush";
        Vector2 target = new Vector2(player.position.x + 1, player.position.y +2);
        moveSpeed *= 2;
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1.5f);
        moveSpeed /= 2;
        transform.gameObject.tag = "Enemy";
        IsAttacking = false;
    }

    IEnumerator RangeAttack()
    {
        moveSpeed = 0;
        int i = 0;
        while( i < 500){
            Instantiate(arrow, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.001f);
            i++;
        }
        
        
        IsAttacking = false;
        moveSpeed = 3;
    }

    IEnumerator MeleeAttack()
    {
        playerChar.currentHealth -= damage;
        yield return new WaitForSeconds(2);

        IsAttacking = false;
    }
}
