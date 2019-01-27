using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 1;
    [SerializeField]
    private float timeBetweenAttacks = 1.5f;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool playerInRange; // use 2D collider trigger enter/exit

    public float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = Object.FindObjectOfType<Player>().gameObject;
        // Setting up the references
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time since Update was last called to the timer.
        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerMirror"))
        {
            Debug.Log("Started collision with player!");
            // the player is in range.
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If the exiting collider is the player
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerMirror"))
        {
            Debug.Log("Ended collision with player!");
            // the player is no longer in range.
            playerInRange = false;
        }
    }

    void Attack()
    {
        // Reset the timer.
        attackTimer = 0f;

        // If the player has health to lose
        if (playerHealth.currentHealth > 0)
        {
            // damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
