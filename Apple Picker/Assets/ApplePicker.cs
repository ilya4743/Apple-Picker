using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public GameObject GameOverMenu;
    public GameObject Interface;
    public GameObject appleTree;
    void Awake()
    {
        Interface.SetActive(true);
        appleTree.SetActive(true);
        GameOverMenu.SetActive(false);
    }
    void Start()
     {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
         {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY*i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
         }
     }
    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // b
        foreach (GameObject tGO in tAppleArray) { 
            Destroy(tGO);
        }
        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb"); // b
        foreach (GameObject tGO in tBombArray)
        {
            Destroy(tGO);
        }
        // Удалить одну корзину
        // Получить индекс последней корзины в basketList
        int basketIndex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketIndex];
        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketIndex == 0)
        {
            Interface.SetActive(false);
            appleTree.GetComponent<AppleTree>().CancelInvoke();
            appleTree.SetActive(false);
            GameOverMenu.SetActive(true);

        }
    }
    public void CatchBomb()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // b
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        GameObject[] tBombArray = GameObject.FindGameObjectsWithTag("Bomb"); // b
        foreach (GameObject tGO in tBombArray)
        {
            Destroy(tGO);
        }
        // Удалить одну корзину
        // Получить индекс последней корзины в basketList
        int basketIndex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket
        GameObject tBasketGO = basketList[basketIndex];
        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
        if (basketIndex == 0)
        {
            Interface.SetActive(false);
            appleTree.GetComponent<AppleTree>().CancelInvoke();

            appleTree.SetActive(false);
            GameOverMenu.SetActive(true);

        }
    }
}