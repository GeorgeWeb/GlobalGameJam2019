using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] List<Sprite> allTreeSprites;
    // Start is called before the first frame update
    void Start()
    {
        int treeIndex =((int) Random.Range(0.0f, 100.0f)) % allTreeSprites.Count;
        gameObject.GetComponentInChildren<Trunk>().gameObject.GetComponent<SpriteRenderer>().sprite = allTreeSprites[treeIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
