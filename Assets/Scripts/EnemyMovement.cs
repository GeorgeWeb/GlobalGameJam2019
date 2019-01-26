using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = Object.FindObjectOfType<Player>().gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = (Vector2)playerObj.GetComponent<Transform>().position;
        if (playerPosition.x >= transform.position.x)
        {
        //    Debug.Log("YES");
            transform.localScale = Vector3.left + Vector3.up;
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        else
        {
          //  Debug.Log("NO");
            transform.localScale = Vector3.right + Vector3.up;
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        //   Debug.Log("Player pos seen from " + gameObject.name + " is : " + playerPosition.ToString());
    }

    void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
