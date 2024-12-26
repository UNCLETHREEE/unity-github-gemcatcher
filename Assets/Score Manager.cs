using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; //Text Mesh Pro 

public class ScoreManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText; 
    private void GameOver()
    {
        gameOverText.text = "Game Over!\nScore: " + score;
        gameOverPanel.SetActive(true);
    }

    public static int score = 0;
    private float remainingTime; 

    public TextMeshProUGUI scoreText; 

    public static void AddScore(int amount)
    {
        score += amount; 
    }

    void Start() // đếm giờ khi trò chơi bắt đầu
    {
        remainingTime = 30f; //thời gian còn lại tại thời điểm bắt đầu bằng 30s (thời lượng của trò chơi)
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian
    }

    void Update() 

    
    {
        scoreText.text = "Score: " + score + " | Time: " + Mathf.CeilToInt(remainingTime); //Mathf.CeilToInt(remainingTime) làm tròn số nguyên dương
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--; 
        }
        if(remainingTime <= 0) {
  GameOver();
}
//...
    }

    
    
}