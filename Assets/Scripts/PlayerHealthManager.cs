using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public Slider healthSlider;
    public Image damageImage;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f); //red with low alpha

    // public AudioClip deathClip;
    public bool isDead;
    public bool damaged;

    public float flashLength = 5f;

    private Renderer rend;

    private Color storedColor;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {   
        if(currentHealth <= 0 && !isDead)
        {
            Death();
            // TODO: Make UI show and clickable restart button
        }

        if(damaged)
        {
            // flashes HUD image
            damageImage.color = flashColor;
            
            if(currentHealth <= startingHealth/2) // half health
                rend.material.SetColor("_Color", new Color(1.0f, 0.64f, 0.0f)); //orange

            if(currentHealth <= 1) // low health
                rend.material.SetColor("_Color", Color.red);

            if(currentHealth > startingHealth/2) // starting color
                rend.material.SetColor("_Color", storedColor);
        }
        else
        {
            // returns color
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashLength * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int damage)
    {
        damaged = true;

        // reduces health
        currentHealth -= damage;

        // starts flashing animation
        rend.material.SetColor("_Color", Color.white);

        // sets health bar's value to current health;
        healthSlider.value = currentHealth;
        // Debug.Log("Health slider change: " + healthSlider.value);
        
    }

    void Death()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
