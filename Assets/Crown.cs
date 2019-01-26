using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void stopShake()
    {
        gameObject.GetComponent<Animator>().SetBool("Shake", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
