using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour {

    public Text high_score_text;
	void Start () {
        int high_score = PlayerPrefs.GetInt("high_score");
        high_score_text.text = "Highest :" + high_score.ToString();
	}
	
	public void Play_Game()
    {
        SceneManager.LoadScene(1);
    }
    public void exit_game()
    {
        Application.Quit();
    }
}
