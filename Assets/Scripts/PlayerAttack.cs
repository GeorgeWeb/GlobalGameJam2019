using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    int attackDamage = 1;
    [SerializeField]
    float timeBetweenAttacks = 0.3f;

    public GameObject enemy;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;

    bool enemyInRange; // use 2D collider trigger enter/exit

    float attackTimer;

    [SerializeField]
    Animator animator;

    bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        playerHealth = GetComponent<PlayerHealth>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time since Update was last called to the timer.
        attackTimer += Time.deltaTime;

        // manage attack input
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("IsAttacking", true);
            attack = true;
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

        if (attack)
        {
            if (attackTimer >= timeBetweenAttacks && enemyInRange && playerHealth.currentHealth > 0)
            {
                Attack();
            }
            attack = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Started collision with enemy!");
        // the player is in range.
        enemyInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Ended collision with enemy!");
        // the player is no longer in range.
        enemyInRange = false;
    }

    void Attack()
    {
        // Reset the timer.
        attackTimer = 0f;

        // If the player has health to lose
        if (enemyHealth.currentHealth > 0)
        {
            // damage the player.
            enemyHealth.TakeDamage(attackDamage);
        }

        Debug.Log("Attacking...");
    }
}
