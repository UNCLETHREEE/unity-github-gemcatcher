using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // Text Mesh Pro

public class ScoreManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public TextMeshProUGUI gameOverText; 
    

   private void GameOver()
{
    gameOverText.text = "Game Over!\nScore: " + score;
    gameOverPanel.SetActive(true);

    AudioManager.Instance.PlayGameOverSFX(); 
}

    public static int score = 0; 
    private float remainingTime; 

    public TextMeshProUGUI scoreText; 

    public static void AddScore(int amount)
    {
       
        score += amount; 
    }

    void Start()
    {
        remainingTime = 90f;
         score = 0;
        StartCoroutine(CountdownTimer());
       
    }

    void Update()
    {
        scoreText.text = "Score: " + score + " | Time: " + Mathf.CeilToInt(remainingTime);   
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f); 
            remainingTime--; 
        }
        if (remainingTime <= 0 )
        {
            Time.timeScale = 0; 
            GameOver();
        }
    }
}
