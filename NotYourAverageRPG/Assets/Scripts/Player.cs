/*
*   Authors: Brandan Roman, Phil Tocco
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IShopCustomer
{
    private SpriteRenderer sp;
    protected static float maxHealth = 100;
    public float currentHealth;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public float damage;
    public GameObject arrow;
    public PlayerMovement playerMovement;
    public Canvas deathScreen;
    public AudioSource[] aPlayer;
    public AudioClip death;
    private Inventory inventory;
    public  KeyCode inventoryKey;
    public UnityEvent inventoryAction;
    private bool isShooting;
    public Text healthText;
    public AudioClip hurt;
    public GameObject boss;

    [SerializeField] private UI_Inventory uiInventory;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SetHealthText();
        boss = GameObject.Find("boss");
        deathScreen.enabled = false;
        sp = GetComponent<SpriteRenderer>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        if(Input.GetKeyDown(inventoryKey))
            {
                inventoryAction.Invoke();
                Debug.Log("action taken");
            }

        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }

        if (Input.GetMouseButtonDown(1) && !isShooting) 
        {
            StartCoroutine(RangeAttack());
        }

        if(currentHealth <= 0 && playerMovement.isDead == false)
        {
            die();
        }
    }

    void MeleeAttack()
    {
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {  
                EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
                enemyAI.currenthealth -= damage;
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator RangeAttack()
    {
        isShooting = true;
        Instantiate(arrow, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);
        isShooting = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("hit");
        if (other.tag == "enemyArrow")
        {
            StartCoroutine(hurtSounds());
            currentHealth -= 10;
            SetHealthText();
            Destroy(other);
        }
        if (other.tag == "boshRush")
        {
            StartCoroutine(hurtSounds());
            currentHealth -= 65;
            SetHealthText();
        }
        if (other.tag == "bossMagic")
        {
            StartCoroutine(hurtSounds());
            currentHealth -= 15;
            SetHealthText();
        }
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if(itemWorld != null) //if interacting with an item, add it to inventory and destroy the object in the world
        {
            //touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    private void die()
    {
        playerMovement.isDead = true;
        deathScreen.enabled = true;
        aPlayer[0].Stop();
        aPlayer[0].PlayOneShot(death, .5f);

    }

    public void SetHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }
    IEnumerator hurtSounds()
    {
        aPlayer[1].Play();
        yield return new WaitForSeconds(hurt.length);
    }


    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
    }
}
