using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    void Awake()
    {
        Text gt = this.GetComponent<Text>();
        if (HighScore.highScore == true)
            gt.text = "New High Score: " + HighScore.HighScore1;
        else
            gt.text = "Score: " + HighScore.score;
    }
}
