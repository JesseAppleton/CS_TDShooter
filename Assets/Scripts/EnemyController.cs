using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;

    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        // gets whatever model is set 
        myRB = GetComponent<Rigidbody>();

        // automatically finds player
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // looks at the player based on position
        transform.LookAt(thePlayer.transform.position);
    }

    void FixedUpdate()
    {
        // allows walking forward
        myRB.velocity = (transform.forward * moveSpeed);
    }
}
