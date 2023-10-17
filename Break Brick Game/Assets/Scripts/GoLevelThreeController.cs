using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoLevelThreeController : MonoBehaviour
{
      public void GoLevelThreeNow(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}

 public void GoToMainMenu(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-4);
}
}
