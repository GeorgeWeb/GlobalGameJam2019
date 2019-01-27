using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    void LateUpdate()
    {
        // update the camera position
        GetComponent<Transform>().position = new Vector3(target.GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
    }
}
