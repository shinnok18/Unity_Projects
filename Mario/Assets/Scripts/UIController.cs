using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3;

    public Sprite fullHeart, emptyHeart;

    
    
    private void Awake(){
        instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHeartMeter()
    {
        switch(Health.instance.currentHealth){

            case 3:
            heart1.sprite=fullHeart;
            heart2.sprite=fullHeart;
            heart3.sprite=fullHeart;
            break;
            case 2:
            heart1.sprite=fullHeart;
            heart2.sprite=fullHeart;
            heart3.sprite=emptyHeart;
            break;
            case 1:
            heart1.sprite=fullHeart;
            heart2.sprite=emptyHeart;
            heart3.sprite=emptyHeart;
            break;
            case 0:
            Application.LoadLevel("GameOver");
            break;

        }
    }

    
}
