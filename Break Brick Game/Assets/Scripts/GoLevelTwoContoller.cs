using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLevelTwoContoller : MonoBehaviour
{
    public void GoLevelTwoNow(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}

 public void GoToMainMenu(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
}

}
