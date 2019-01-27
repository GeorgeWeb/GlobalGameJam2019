using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTree : MonoBehaviour
{
    // Handle tree randomization
    [SerializeField] List<Sprite> allTreeSprites;
    [SerializeField] List<Sprite> allCrownSprites;
    GameObject crownWithSpawner;
    [SerializeField] float ropeSpawnRange = 5.0f;
    [SerializeField] GameObject playerObj;

    // Rope spawning
    [SerializeField] GameObject ropePrefab;
    GameObject rope;
    bool ropeSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        generateTrunk();
        generateCrowns();
    }

    void generateTrunk()
    {
        int treeIndex = ((int)Random.Range(0.0f, 100.0f)) % allTreeSprites.Count;
        gameObject.GetComponentInChildren<Trunk>().gameObject.GetComponent<SpriteRenderer>().sprite = allTreeSprites[treeIndex];
    }

    void generateCrowns()
    {
        var CrownList = gameObject.GetComponentsInChildren<Crown>();
       // Debug.Log(CrownList.Length);

        int spawnerIndex = (int)Random.Range(0.0f, (float)CrownList.Length);
       // Debug.Log(spawnerIndex);

        int i = 0;
        foreach (var Crown in CrownList)
        {
            // Find sprite to use and renderer to us it
            int crownIndex = ((int)Random.Range(0.0f, 100.0f)) % allCrownSprites.Count;
            var crownSpriteRenderer = Crown.GetComponentInChildren<SpriteRenderer>();

            // Allocate sprite and color
            crownSpriteRenderer.sprite = allCrownSprites[crownIndex];
            crownSpriteRenderer.color = new Color(0.0f, Random.Range(0.5f, 1.0f), 0.0f);

            // Check if crown is spawner
            if (i == spawnerIndex)
            {
                crownWithSpawner = Crown.gameObject;
                gameObject.GetComponent<Spawning>().setSpawningObject(crownWithSpawner);
              //  spawnRope();
            }
            i++;
        }

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.GetComponent<Player>() != null)
        {
            if (!ropeSpawned)spawnRope();
        }
    }

    private void spawnRope()
    {
        Debug.Log("Rope spawned");
        //ropeSpawned = true;
        rope = Instantiate(ropePrefab, crownWithSpawner.transform.position, transform.rotation);
        gameObject.GetComponent<Spawning>().StartSpawning();

    }


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(playerObj.transform.position.x - gameObject.transform.position.x) < ropeSpawnRange && !ropeSpawned)
        {
            ropeSpawned = true;
            spawnRope();
        }
    }
}
