using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GemMover : MonoBehaviour
{
    public float speed = 5f; // Speed at which the object moves downwards
    public int point = 1;
    void Update()
    {
        // Moves the object down at the specified speed
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }


  void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        AudioManager.Instance.PlayEatSFX(); 
        Destroy(gameObject);
        ScoreManager.AddScore(point);
    }
    else if (other.gameObject.CompareTag("Ground"))
    {
        Destroy(gameObject);
    }
}

}

// public class GemMover : MonoBehaviour
// {
  
//     public float speed = 5f; 

// void Update()
// {
// 	transform.Translate(Vector3.down * speed * Time.deltaTime);
// }

// void OnTriggerEnter2D(Collider2D other) //other chính là thông tin của bất kỳ collider nào va chạm với collider này
// {
// 		// thiết lập điều kiện kiểm tra thông tin của OTHER
//     if (other.gameObject.CompareTag("Player")) 
//       // nếu, phương thức so sánh gameobject tag của other với nhãn "Player" là đúng
//     { // thì
//         Destroy(gameObject);
//          ScoreManager.AddScore(1);
//  //xóa gameObject đang gắn collider này. (Không phải là other)
//       //nghĩa là xóa viên ngọc này, không phải xóa người chơi đang va chạm
//     }
// else if (other.gameObject.CompareTag("Enemy")) 
//       // nếu, phương thức so sánh gameobject tag của other với nhãn "Player" là đúng
//     { // thì
//         Destroy(gameObject);
//          ScoreManager.AddScore(-1);
//  //xóa gameObject đang gắn collider này. (Không phải là other)
//       //nghĩa là xóa viên ngọc này, không phải xóa người chơi đang va chạm
//     }


//     else if (other.gameObject.CompareTag("Ground")) // còn không thì, nếu là mặt đất,
//     { // thì
//         Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
//         //nghĩa là xóa viên ngọc này, không phải xóa mặt đất
//     }
// }
// }