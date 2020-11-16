using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] protected float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] protected float attackDistance;
    protected Transform player;
    protected SpriteRenderer sp;
    protected float distance;
    protected Player playerChar;
    public float currenthealth;
    public Text healthText;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        isDead = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sp = GetComponent<SpriteRenderer>();
        playerChar = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SetHealthText();
    }

    protected virtual void Move()
    {
      
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

       
    }
    private void TurnDirection()
    {
        if(transform.position.x > player.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        distance = Vector2.Distance(player.position, transform.position);
        //Debug.Log(currenthealth);
        if (distance < attackDistance)
        {
            Move();
            TurnDirection();
        }

        if(currenthealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.tag == "playerArrow")
        {
            currenthealth -= 20;
            SetHealthText();
        }
    }

    public void SetHealthText()
    {
        healthText.text = "Health: " + currenthealth.ToString();
    }
}
