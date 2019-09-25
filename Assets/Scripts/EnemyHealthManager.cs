using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{   
    public int health;
    private int currentHealth;

    public EnemyController enemy;
    public PlayerHealthManager playerHealth;

    public float spawnTime = 3f; // how long between spawns
    public Transform[] spawnPoints; // An array of spawn locations

    // Start is called before the first frame update
    void Start()
    {
        //spawns on start
        InvokeRepeating ("Spawn", spawnTime, spawnTime);

        // sets health
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {   
        // // do not spawn any more if the player is dead
        // playerHealth.currentHealth = PlayerHealthManager.currentHealth;
        // if(playerHealth.currentHealth <= 0)
        // {
        //     // end game?
        //     return;
        // }

        if(currentHealth <= 0)
        {
            ScoreManager.score += 100;
            Destroy(gameObject);
            Debug.Log("Earned points! " + ScoreManager.score);
        }

        // // Spawner at random location
        // int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        // Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    public void HurtEnemy(int damage)
    {   
        currentHealth -= damage;
    }


}
