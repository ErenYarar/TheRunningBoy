using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    //public static int scoreValue = 0;
    public Text score;
    public static float scoreAmount;
    public float pointPerSecond;

    public Text highScore;

    void Start()
    {
        scoreAmount = 0f;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        score.text = (int)scoreAmount + "";
        scoreAmount += pointPerSecond * Time.deltaTime;

        int number = Convert.ToInt32(scoreAmount);

        if(number > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", number);
			highScore.text = number.ToString();
		}
    }

    public  void Reset() 
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    
}
