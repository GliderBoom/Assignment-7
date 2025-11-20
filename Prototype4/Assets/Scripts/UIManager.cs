/*
* Ademir Aviles
* UIManager
* Assignment 7
* manages ui
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{

    public PlayerController controller;
    public SpawnManager spawnManager;

    public Text waveScore;
    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (waveScore == null)
        {
            waveScore = FindObjectOfType<Text>();
        }

        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        }

        waveScore.text = "Wave: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver) {
            waveScore.text = "Wave: " + spawnManager.waveNumber;
        }

        if (controller.gameOver && !won)
        {
            waveScore.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if (spawnManager.waveNumber >= 10)
        {
            controller.gameOver = true;
            won = true;

            waveScore.text = "You Win!" + "\n" + "Press R to Try Again!";

        }

        //Pres R to restart if game is over
        if (controller.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
