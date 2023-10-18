using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private static float score = 0;
    public const string HIGH_SCORE = "HighScore";
   
    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1;
        scoreText.text = "Score:"+Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
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
