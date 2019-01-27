using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEffect : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    public float FadeOut()
    {
        var newR = spriteRenderer.material.color.r;
        var newG = spriteRenderer.material.color.g;
        var newB = spriteRenderer.material.color.b;
        var newA = spriteRenderer.material.color.a - Time.deltaTime;

        spriteRenderer.material.color = new Color(newR, newG, newB, newA);

        return spriteRenderer.material.color.a;
    }
}
