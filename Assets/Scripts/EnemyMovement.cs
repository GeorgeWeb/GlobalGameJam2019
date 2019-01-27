using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float speed = 100.0f;
    [SerializeField] float attackRange = 3.0f;
    [SerializeField] float shiftRange = 1.0f;
    [SerializeField] float dieBelowAxisY = -30.0f;
    float positionRange = 0.0f;
    bool isFalling = true;
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = Object.FindObjectOfType<PlayerHealth>().gameObject;
        isFalling = true;
        positionRange = attackRange - shiftRange + Random.Range(0 - shiftRange, shiftRange);
        Debug.Log("position range = " + positionRange);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isFalling)
        {
            Vector2 playerPosition = (Vector2)playerObj.GetComponent<Transform>().position;
            Debug.Log(playerPosition.x - transform.position.x);
            if (playerPosition.x - transform.position.x >= positionRange )
            {

                    Debug.Log("YES");
                transform.localScale = Vector3.left + Vector3.up;
                transform.Translate(Vector3.right * Time.deltaTime * speed);

            }   
            else if (playerPosition.x - transform.position.x <= -positionRange)
            {
                  Debug.Log("NO");
                transform.localScale = Vector3.right + Vector3.up;
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }

        if (transform.position.y < dieBelowAxisY) Destroy(gameObject);

        //   Debug.Log("Player pos seen from " + gameObject.name + " is : " + playerPosition.ToString());
    }

    private void OnCollisionEnter2D(Collision2D otherCollision)
    {
        Debug.Log("Collided with " + otherCollision.gameObject);
        if (otherCollision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Collided with " + otherCollision.gameObject);

            isFalling = false;
        }
    }

    void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
