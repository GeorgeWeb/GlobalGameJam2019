using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    float speedDampening = 0.005f;

    [SerializeField]
    public string sortingLayerName = "Background";
    [SerializeField]
    public int sortingOrder = 0;

    public MeshRenderer meshRenderer;

    public GameObject player;

    Vector2 offset = Vector2.zero;

    void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        meshRenderer.sortingLayerName = sortingLayerName;
        meshRenderer.sortingOrder = sortingOrder;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            var scrollX = Time.deltaTime * 40.0f * speedDampening;
            offset += new Vector2(scrollX, 0);
            meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
            Debug.Log("Positive");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var scrollX = Time.deltaTime * 40.0f * speedDampening;
            offset -= new Vector2(scrollX, 0);
            meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
            Debug.Log("Negative");
        }
    }
}
