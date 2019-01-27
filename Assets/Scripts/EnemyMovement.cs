using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 100.0f;
    [SerializeField]
    float attackRange = 3.0f;
    [SerializeField]
    float shiftRange = 1.0f;
    [SerializeField]
    float dieBelowAxisY = -30.0f;

    float positionRange = 0.0f;

    GameObject playerObj;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = Object.FindObjectOfType<PlayerHealth>().gameObject;
        animator = GetComponent<Animator>();
        positionRange = attackRange - shiftRange + Random.Range(0 - shiftRange, shiftRange);
        // Debug.Log("position range = " + positionRange);
        animator.SetBool("IsRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = (Vector2)playerObj.GetComponent<Transform>().position;
        // Debug.Log(playerPosition.x - transform.position.x);
        if (playerPosition.x - transform.position.x >= positionRange)
        {
            // Debug.Log("YES");
            transform.localScale = Vector3.left + Vector3.up;
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        else if (playerPosition.x - transform.position.x <= -positionRange)
        {
            // Debug.Log("NO");
            transform.localScale = Vector3.right + Vector3.up;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.y < dieBelowAxisY)
        { 
            Destroy(gameObject); 
        }
        //   Debug.Log("Player pos seen from " + gameObject.name + " is : " + playerPosition.ToString());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("Collided with " + otherCollision.gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("IsRunning", true);
            // Debug.Log("Collided with " + other.gameObject);
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
