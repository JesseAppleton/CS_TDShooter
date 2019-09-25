using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public float flashLength;
    private float flashCounter;

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
        // Loses control of character on death
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            // TODO: Make UI show and clickable restart button
        }

        // Starts to return normal color after damage
        if(flashCounter > 0)
        {   
            // starts countdown
            flashCounter -= Time.deltaTime;

            // returns color based on health remaining
            if(flashCounter <= 0)
            {
                if(currentHealth <= startingHealth/2) // half health
                    rend.material.SetColor("_Color", new Color(1.0f, 0.64f, 0.0f)); //orange

                if(currentHealth <= 1) // low health
                    rend.material.SetColor("_Color", Color.red);

                if(currentHealth > startingHealth/2) // starting color
                    rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtPlayer(int damage)
    {
        // reduces health
        currentHealth -= damage;

        // starts flashing animation
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
