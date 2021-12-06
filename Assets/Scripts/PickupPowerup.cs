using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupPowerup : MonoBehaviour
{
    public Text scoreText;
    public float score;

    void Update()
    {
        score = LevelManager.score;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //print("picked-up fruit!");
            Destroy(gameObject);

            LevelManager.score = LevelManager.score + 350;
            UpdateScore();
            //print(score);

            GhostAi.runAway = true;
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: \n" + LevelManager.score;   
    }
}
