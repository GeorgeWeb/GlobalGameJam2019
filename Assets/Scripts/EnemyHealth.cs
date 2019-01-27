using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maximumHealth = 2;
    public int currentHealth;
    public Image healthContent;

    bool isDamaged = false;
    bool isDead = false;

    [SerializeField]
    FadeOutEffect fadeOutEffect;

    void Awake()
    {
        // Set the initial health of
        currentHealth = maximumHealth;
    }

    void Start()
    {
        if (fadeOutEffect == null)
        {
            fadeOutEffect = GetComponent<FadeOutEffect>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has just been damaged
        if (isDamaged)
        {
            // set the colour of the damageImage to the flash colour.
            // damageImage.color = flashColour;
            Debug.Log("Damaged!");
        }

        // Reset the damaged flag.
        isDamaged = false;

        if (isDead)
        {
            if (fadeOutEffect.FadeOut() <= 0.01f)
            {
                Death();
            }
        }
    }

    public void TakeDamage(int ammount)
    {
        // Set the damaged flag so the screen will flash.
        isDamaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= ammount;
        Debug.Log("Enemy Health: " + currentHealth.ToString());

        // Set the health bar's value to the current health.
        float healthFillAmmountDecrease = 1.0f / maximumHealth;
        healthContent.fillAmount -= healthFillAmmountDecrease;

        // Play the hurt sound effect.
        // e.g. playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Enemy Died!");
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
