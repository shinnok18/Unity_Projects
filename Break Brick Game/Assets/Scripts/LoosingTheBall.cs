using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoosingTheBall : MonoBehaviour
{
    
   private void OnTriggerEnter2D(Collider2D collision)
{
        Destroy(collision.gameObject);

        if (Ball.ballCount <= 1) // Eðer kalan top sayýsý 1'e eþit veya daha az ise
        {
            Debug.Log("carpisma oldu");
            SceneManager.LoadScene("GameOverScene");
        }
    }

    
}
