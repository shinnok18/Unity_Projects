using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KutuController : MonoBehaviour
{
    public ScorreManager scoreManager;
    public Sprite brick;
    public Sprite brick1;
    public Sprite brick2;
    public Sprite brick3;
    public Sprite brick4;
    public Sprite brickBlack;
    public static int brickCounter;
    string currentSceneName;
    private SpriteRenderer spriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScorreManager>();
        currentSceneName = SceneManager.GetActiveScene().name;
       
        if (currentSceneName == "SampleScene")
        {
            brickCounter = 16;
        }
        else if (currentSceneName == "Level2")
        {
            brickCounter = 32;
        }
        else if(currentSceneName == "Level3")
        {
            brickCounter = 30;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeBrickSprite()
    {
      
      
        Debug.Log("muzik caldi");
        AudioCode.instance.PlayMusic(0);
        if (spriteRenderer.sprite == brickBlack)
        {
            Debug.Log("cant destroy it...");
            

        }
        else if (spriteRenderer.sprite == brick4)
        {
            scoreManager.AddScore(1);
            spriteRenderer.sprite = brick3;
            //scoreManager.AddScore(1);
        }
       else if (spriteRenderer.sprite == brick3)
        {
            scoreManager.AddScore(1);
            spriteRenderer.sprite = brick2;
            //scoreManager.AddScore(1);
        }
        else if (spriteRenderer.sprite == brick2)
        {
            scoreManager.AddScore(1);
            spriteRenderer.sprite = brick1;
           // scoreManager.AddScore(1);
        }
        else if (spriteRenderer.sprite == brick1)
        {
            scoreManager.AddScore(1);
            spriteRenderer.sprite = brick;
            //scoreManager.AddScore(1);
        }
        else 
        {
            scoreManager.AddScore(1);
            brickCounter--;
            //scoreManager.AddScore(2);
            //kýrýlacak
            Destroy(gameObject);
            Debug.Log(brickCounter);
            if (brickCounter == 0)
            {
                // yeni sahneyi açan kod
                if (currentSceneName == "SampleScene")
                {
                    Application.LoadLevel("GoLevelTwo");
                }
                else if (currentSceneName == "Level2")
                {
                    Application.LoadLevel("GoLevelThree");
                }
                else if (currentSceneName == "Level3")
                {
                    Application.LoadLevel("GameOverScene");
                }
               

            }
        }


    }
    // Update is called once per frame
    void Update()
    {


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("top bricke carpti");
            ChangeBrickSprite();
        }

    }
}
