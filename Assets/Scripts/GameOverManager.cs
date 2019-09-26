using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealthManager playerHealth;
    public float restartDelay = 5f;

    float restartTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth <= 0)
        {
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if(restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                SceneManager.LoadScene(0);
            }
        }
    }
}
