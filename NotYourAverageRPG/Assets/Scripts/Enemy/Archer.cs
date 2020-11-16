using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : EnemyAI
{
    public float damage;
    private bool isAttacking;
    private bool isSetup;
    public GameObject arrow;
    public float range;
    public bool isReady;


    protected override void Update()
    {
        base.Update();
        if (distance <= range && !isAttacking && !isSetup)
        {
            StartCoroutine(Setup());
        }
        if(isReady && !isAttacking)
        {
            StartCoroutine(Rangeattack());
        }

        //Debug.Log(currenthealth);
    }
    IEnumerator Setup()
    {
        isSetup = true;
        yield return new WaitForSeconds(2);
        isSetup = false;
        isReady = true;
        Debug.Log("SetupReady");
     
    }
    IEnumerator Rangeattack()
    {
        isAttacking = true;
        Instantiate(arrow, transform.position , Quaternion.identity);
        yield return new WaitForSeconds(1);
        isAttacking = false;
        isReady = false;
    }

}
