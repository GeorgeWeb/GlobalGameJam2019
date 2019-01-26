using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
         //   gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
          //  gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("Collided with ground");
        }
    }
}
