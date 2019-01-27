using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    void LateUpdate()
    {
        var newX = target.GetComponent<Transform>().position.x;
        var newY = GetComponent<Transform>().position.y;
        var newZ = GetComponent<Transform>().position.z;
        // update the camera position
        GetComponent<Transform>().position = new Vector3(newX, newY, newZ);
    }
}
