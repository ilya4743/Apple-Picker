using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public void ExitBtnClick()
    {
        Application.Quit();
    }
    public void RestartBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetHighScoreBtnClick()
    {
        HighScore.HighScore1 = 0;
        PlayerPrefs.SetInt("HighScore", HighScore.HighScore1);
    }
}
