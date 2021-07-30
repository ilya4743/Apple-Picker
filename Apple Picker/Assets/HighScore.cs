using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int HighScore1 = 0;
    static public int score = 0;
    static public bool highScore = false;
    void Awake()
    { 
      // Если значение HighScore уже существует в PlayerPrefs, прочитать его
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore1 = PlayerPrefs.GetInt("HighScore");
        }
        // Сохранить HighScore в хранилище
        PlayerPrefs.SetInt("HighScore", HighScore1);
        score = 0;
    }
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: "+ HighScore1;
        if (HighScore1 > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", HighScore1); 
    }
}