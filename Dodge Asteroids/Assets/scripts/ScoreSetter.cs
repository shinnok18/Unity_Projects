using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSetter : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private static float score = 0;
    private int lastAddedScore = -1; // Ekleyeceðimiz yeni bir alan
    public const string HIGH_SCORE = "HighScore";

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1;
        scoreText.text = "Score:" + Mathf.FloorToInt(score).ToString();

        int flooredScore = Mathf.FloorToInt(score);

        // Eðer skor 10'un katý olduysa ve son eklenen skordan farklýysa coin ekleyin
        if (flooredScore % 10 == 0 && flooredScore != lastAddedScore)
        {       //Singelton sýnýfý
            CoinMaker.Instance.AddCoins(10);
            lastAddedScore = flooredScore;
        }
    }

    //scorun 0 kalmasý için siliyor
    private void OnDestroy()
    {
        CoinMaker.Instance.AddCoins((int)score);
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
            if (score > highScore)
            {
                PlayerPrefs.SetInt(HIGH_SCORE, Mathf.FloorToInt(score));
                score = 0;
            }
        }
    }
}
