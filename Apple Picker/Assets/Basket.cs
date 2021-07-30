using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();               // Установить начальное число очков равным 0
        scoreGT.text = "0";
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        int score;
        score = int.Parse(scoreGT.text); // Преобразовать текст в scoreGT в целое число
        if (collidedWith.tag == "Apple") 
        { 
            Destroy(collidedWith);
            HighScore.score += 100;// Добавить очки за пойманное яблоко
            scoreGT.text = HighScore.score.ToString();
        }
        if (collidedWith.tag == "Bomb") { 
            Destroy(collidedWith);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.CatchBomb();
        }
        // Запомнить достижение
        if (HighScore.score > HighScore.HighScore1)
        {
            HighScore.HighScore1 = HighScore.score;
            HighScore.highScore = true;
        }
    }
}