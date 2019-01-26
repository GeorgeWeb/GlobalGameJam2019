using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 1;
    [SerializeField]
    private float timeBetweenAttacks = 1.5f;

    public GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange; // use 2D collider trigger enter/exit

    public float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time since Update was last called to the timer.
        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack();
            // playerInRange = false;
        }

        // If the player has zero or less health
        if (playerHealth.currentHealth <= 0)
        {
            // alert player is dead.
            Debug.Log("Player is dead!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Started collision with player!");
        // the player is in range.
        playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If the exiting collider is the player
        if (other.gameObject == player)
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
