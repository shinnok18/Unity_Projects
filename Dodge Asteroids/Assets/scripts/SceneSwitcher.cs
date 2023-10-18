using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SwitchToGame()
    {
        SceneManager.LoadScene("SampleScene");
        ResumeGame();
    }

    public  void backToGame()
    {
        SceneManager.LoadScene("SampleScene");
        ResumeGame();
    }

    public void SwitchToShop()
    {
        SceneManager.LoadScene("Market");
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
