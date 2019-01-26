using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maximumHealth = 5;
    public int currentHealth;
    public Image healthContent;

    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // public AudioClip deathClip;

    private bool isDamaged;
    private bool isDead;

    void Awake()
    {
        // Setting up the references.
        // ...

        // Set the initial health of
        currentHealth = maximumHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Empty.
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

        // Set the health bar's value to the current health.
        float healthFillAmmountDecrease = 1.0f / maximumHealth;
        healthContent.fillAmount -= healthFillAmmountDecrease;

        // Play the hurt sound effect.
        // e.g. playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Tell the animator that the player is dead.
        // ...

        // Set the audiosource to play the death clip and play it.
        // this will stop the hurt sound from playing as well.
        // ...
    }
}
