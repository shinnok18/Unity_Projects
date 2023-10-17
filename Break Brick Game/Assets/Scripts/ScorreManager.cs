using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScorreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static int score = 0;

    void Start()
    {
      //  scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }



    public void AddScore(int points)
    {
        Debug.Log("cagirildi");
        score += points;
        scoreText.text =  score.ToString();
    }


}
