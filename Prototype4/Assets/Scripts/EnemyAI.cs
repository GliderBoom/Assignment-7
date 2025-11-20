/*
* Ademir Aviles
* EnemyAI
* Assignment 7
* enemies ai
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() { 
        //add force toward the directio nfrom the player to the enemy

        //vector for direction from enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //add force towards player
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10) { 
            Destroy(gameObject);
        }
    }
}
