using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManagement : MonoBehaviour {

    public GameObject panel;
    public void GameOver()
    {
        if (PlayerPrefs.GetInt("high_score") < PlayerController.getScore())
        {
            PlayerPrefs.SetInt("high_score", PlayerController.getScore());
        }
        panel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
    public void playAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void main_menu()
    {
        SceneManager.LoadScene(0);
    }
}
