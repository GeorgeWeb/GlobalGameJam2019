using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    int attackDamage = 1;
    [SerializeField]
    float timeBetweenAttacks = 0.3f;

    PlayerHealth playerHealth;

    bool enemyInRange; // use 2D collider trigger enter/exit

    float attackTimer;

    [SerializeField]
    Animator animator;

    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the references
        playerHealth = GetComponent<PlayerHealth>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // enemies = Object.FindObjectsOfType<Enemy>();

        // Add the time since Update was last called to the timer.
        attackTimer += Time.deltaTime;

        // manage attack input
        if (Input.GetKey(KeyCode.X))
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
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyMirror"))
        {
            // the player is in range.
            enemyInRange = true;
            var enemyObject = other.gameObject.GetComponentInParent<Enemy>().gameObject;
            enemies.Add(enemyObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyMirror"))
        {
            // the player is no longer in range.
            enemyInRange = false;
            var enemyObject = other.gameObject.GetComponentInParent<Enemy>().gameObject;
            enemies.Remove(enemyObject);
        }
    }

    public void Attack()
    {
        // Reset the timer.
        attackTimer = 0f;

        foreach (var enemy in enemies)
        {
            var enemyHealth = enemy.GetComponent<EnemyHealth>();
            // If the player has health to lose
            if (enemyHealth.currentHealth > 0)
            {
                // damage the player.
                enemyHealth.TakeDamage(attackDamage);
            }
        }

        Debug.Log("Attacking...");
    }
}
