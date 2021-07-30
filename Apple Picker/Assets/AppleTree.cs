using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для создания яблок
    public GameObject bombPrefab;
    public GameObject applePrefab;
    // Скорость движения яблони
    public float speed = 1f;
    // Расстояние, на котором должно изменяться направление движения яблони
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    // Частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;
    //int sc = -1;
    //float b = -0.05f;
    void Start()
    {        
        Invoke("DropBomb", 4 + secondsBetweenAppleDrops/2);
        // Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
        /*if (HighScore.score%100==0 && HighScore.score!=0 && HighScore.score!=sc)
        { 
            sc = HighScore.score;
            if(secondsBetweenAppleDrops>0.5f)
                secondsBetweenAppleDrops = secondsBetweenAppleDrops +b;
            else
                secondsBetweenAppleDrops = secondsBetweenAppleDrops - b;
        }*/
    }

    void DropBomb()
    {
        CancelInvoke();
        float s = secondsBetweenAppleDrops / 2;
        Invoke("Bomb", s);
    }
    void Bomb()
    {
        Debug.Log("bomb");
        if (HighScore.score > -1)
        {
            GameObject bomb = Instantiate<GameObject>(bombPrefab);
            bomb.transform.position = transform.position;
            Invoke("DropBomb", 4f + secondsBetweenAppleDrops / 2);
        }
        Invoke("DropApple", secondsBetweenAppleDrops); //a
    }
    void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Изменение направления
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
            speed *= -1;
    }
}