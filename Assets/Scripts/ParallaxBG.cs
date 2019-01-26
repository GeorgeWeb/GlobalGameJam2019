using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 0.1f;

    public MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float x = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(x, 0);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
