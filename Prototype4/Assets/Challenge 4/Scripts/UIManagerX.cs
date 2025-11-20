using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerX : MonoBehaviour
{

    public PlayerControllerX controller;
    public SpawnManagerX spawnManager;

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
            controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();

        }

        waveScore.text = "Wave: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver)
        {
            waveScore.text = "Wave: " + spawnManager.waveCount;
        }

        if (controller.gameOver && !won)
        {
            waveScore.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if (spawnManager.waveCount >= 10)
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
