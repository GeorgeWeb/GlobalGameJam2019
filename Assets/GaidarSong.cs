using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GaidarSong : MonoBehaviour
{
    AudioSource mySongSource;
    GameObject player;
    [SerializeField] float maxDistance = 10.0f;
    [SerializeField] float maxSongVolume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        mySongSource = gameObject.GetComponent<AudioSource>();
        player = Object.FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);
        if (distance > maxDistance)
        {
            mySongSource.volume = 0.0f;
        }
        else
        {
            float volumeRatio = (maxDistance - distance) / maxDistance;
            mySongSource.volume = maxSongVolume * volumeRatio;
        }

    }
}
