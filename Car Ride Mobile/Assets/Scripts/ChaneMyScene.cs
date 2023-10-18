using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChaneMyScene : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public const string HIGH_SCORE = "HighScore";
    public string targetSceneName1 = "Level1";
    public string targetSceneName2 = "Level2";
    public string targetSceneName3 = "Level3";

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        scoreText.text = "HIGHEST SCORE: " + Mathf.FloorToInt(highScore).ToString();
    }

    public void GoToLevelOnee()
    {
        SceneManager.LoadScene(targetSceneName1);
    }

    public void GoToLevelTwo()
    {
        SceneManager.LoadScene(targetSceneName2);
    }

    public void GoToLevelThree()
    {
        SceneManager.LoadScene(targetSceneName3);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgainLevelOne()
    {
        SceneManager.LoadScene(targetSceneName1);
    }

    public void TryAgainLevelTwo()
    {
        SceneManager.LoadScene(targetSceneName2);
    }

    public void TryAgainLevelThree()
    {
        SceneManager.LoadScene(targetSceneName3);
    }
}
