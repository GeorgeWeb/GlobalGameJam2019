using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField]
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
        var velocityX = player.GetComponent<Rigidbody2D>().velocity.x;
        // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        if (velocityX > 0)
        {
            var scrollX = Time.deltaTime * player.GetComponent<PlayerMovement>().runSpeed * speedDampening;
            offset += new Vector2(scrollX, 0);
            meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        if (velocityX < 0)
        {
            var scrollX = Time.deltaTime * player.GetComponent<PlayerMovement>().runSpeed * speedDampening;
            offset -= new Vector2(scrollX, 0);
            meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }
}
