using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maximumHealth = 5;
    public int currentHealth;
    public Image healthContent;

    public Image damageImage;
    public float flashSpeed = 5.0f;
    public Color flashColour = new Color(1.0f, 0.0f, 0.0f, 0.1f);

    bool isDamaged = false;
    bool isDead = false;

    void Awake()
    {
        // Set the initial health of
        currentHealth = maximumHealth;
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
        // Otherwise
        else
        {
            // transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        isDamaged = false;
    }

    public void TakeDamage(int ammount)
    {
        // Set the damaged flag so the screen will flash.
        isDamaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= ammount;
        Debug.Log("Player Health: " + currentHealth.ToString());

        // Set the health bar's value to the current health.
        float healthFillAmmountDecrease = 1.0f / maximumHealth;
        healthContent.fillAmount -= healthFillAmmountDecrease;

        // Play the hurt sound effect.
        // e.g. playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            Death();
            Debug.Log("Player Died!");
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        SceneManager.LoadScene(1);
        // Destroy(gameObject);
    }
}
