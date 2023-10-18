using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreSetter : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private static float score = 0;
    private int lastAddedScore = -1; // Ekleyece�imiz yeni bir alan
    public const string HIGH_SCORE = "HighScore";

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1;
        scoreText.text = "Score:" + Mathf.FloorToInt(score).ToString();

        int flooredScore = Mathf.FloorToInt(score);

        // E�er skor 10'un kat� olduysa ve son eklenen skordan farkl�ysa coin ekleyin
        if (flooredScore % 10 == 0 && flooredScore != lastAddedScore)
        {       //Singelton s�n�f�
            CoinMaker.Instance.AddCoins(10);
            lastAddedScore = flooredScore;
        }
    }

    //scorun 0 kalmas� i�in siliyor
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
