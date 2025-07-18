using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnCollision : MonoBehaviour
{
    public GameObject gameOverPanel; 

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            GameOver(); 
        }
    }

    public void GameOver()
{
    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
    }

    AudioManager.Instance.PlayPlayerDieSFX(); 
    Time.timeScale = 0;
}
    public void RestartButton()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;
    }
    
}