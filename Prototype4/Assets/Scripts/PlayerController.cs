/*
* Ademir Aviles
* PlayerController
* Assignment 7
* player controller
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerUp;

    private float powerupStrength = 15.0f;

    public GameObject PowerupIndicator;

    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //move our powerup indicator to the ground below our player
        PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }

    private void FixedUpdate() {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        if (transform.position.y < -10)
        {
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PowerUp")) {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            PowerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine() { 
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        PowerupIndicator.gameObject.SetActive(false);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp) { 
            Debug.Log("Player collided with " +  collision.gameObject.name + "with powerup set to " + hasPowerUp );

            //get a local reference to the enemy rb
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            //set a vector3 a direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            //add force away from player
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
