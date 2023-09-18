using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance { get; private set; }
    public Transform player;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public float score;
    public float highScore;
    public float startPoint;
    void Awake()
    {
        instance = this;

    }

    void Start()
    {
        
        startPoint = player.transform.position.z;
        highScore = PlayerPrefs.GetFloat("highscore");
        highScoreText.text = highScore.ToString("0");
        Debug.Log("Highscore: " + highScore);

    }

    void Update()
    {
        
        score = player.transform.position.z - startPoint;
        scoreText.text = score.ToString("0");

        
            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = highScore.ToString("0");
                PlayerPrefs.SetFloat("highscore", score);
                PlayerPrefs.Save();
            }
        
    }

    
        //PlayerPrefs.SetString(

        
        
    

}
