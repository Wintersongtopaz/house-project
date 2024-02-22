using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 3;
    public float timer = 10f;

   
    // AddScore increments the value of score by 1
    public void AddScore()
    {
        if (timer > 0f)
        {
        score++;
        print("Score: " + score);

        if (score > highScore)
            {
                highScore = score;
                print("Way to go! You got a new high score.");
            }
        }

       else
        {
            print("Out Of Time!");
        }
    }
     void Update()
    {
        timer -= Time.deltaTime;
    }
}
