using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoosingTheBall : MonoBehaviour
{
    
   private void OnTriggerEnter2D(Collider2D collision)
{
        Destroy(collision.gameObject);

        if (Ball.ballCount <= 1) // E�er kalan top say�s� 1'e e�it veya daha az ise
        {
            Debug.Log("carpisma oldu");
            SceneManager.LoadScene("GameOverScene");
        }
    }

    
}
