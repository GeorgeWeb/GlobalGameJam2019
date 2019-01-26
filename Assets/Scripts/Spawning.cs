using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;
    [SerializeField] Enemy enemyPrefab;
    bool spawn = true;
    // Use this for initialization
    IEnumerator Start()
    {
        transform.SetPositionAndRotation(new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    private void SpawnAttacker()
    {
        Enemy newAttacker = Instantiate(enemyPrefab, transform.position, transform.rotation) as Enemy;
        newAttacker.transform.parent = transform;

    }
    // Update is called once per frame
    void Update()
    {

    }

   
}
