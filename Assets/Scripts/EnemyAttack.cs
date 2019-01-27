using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    int attackDamage = 1;

    GameObject player;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;

    bool playerInRange; // use 2D collider trigger enter/exit

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = Object.FindObjectOfType<Player>().gameObject;
        // Setting up the references
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = player.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
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
        if (playerInRange)
        {
            // If the player has health to lose
            if (playerHealth.currentHealth > 0)
            {
                // damage the player.
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }
}
