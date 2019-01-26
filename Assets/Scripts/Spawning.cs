using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int maxAttackers = 2;
    public GameObject spawningObject;

    int attackersSpawned = 0;
    // Use this for initialization
    public void StartSpawning()
    {
       
        InvokeRepeating("SpawnAttacker", Random.Range(minSpawnDelay, maxSpawnDelay), Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    public void setSpawningObject (GameObject obj)
    {
        spawningObject = obj;
    }

    private void SpawnAttacker()
    {
        if (attackersSpawned < maxAttackers)
        {
            spawningObject.GetComponent<Animator>().SetBool("Shake",  true);
             
            Enemy newAttacker = Instantiate(enemyPrefab, spawningObject.transform.position, transform.rotation) as Enemy;
            newAttacker.transform.parent = spawningObject.transform;
            attackersSpawned++;
        }
    }
   

    // Update is called once per frame
    void Update()
    {

    }

   
}
