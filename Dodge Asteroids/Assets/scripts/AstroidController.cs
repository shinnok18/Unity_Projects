using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidController : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GameObject.FindWithTag("Panel").GetComponent<CanvasGroup>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanel()
    {
        // Alfa deðerini 1 yaparak paneli görünür kýlar.
        canvasGroup.alpha = 1;

        // Raycast'larý engellemeyi açar.
        canvasGroup.blocksRaycasts = true;

        // Kullanýcý etkileþimini açar.
        canvasGroup.interactable = true;
    }

    public void HidePanel()
    {
        // Alfa deðerini 0 yaparak paneli görünmez kýlar.
        canvasGroup.alpha = 0;

        // Raycast'larý engellemeyi kapatýr.
        canvasGroup.blocksRaycasts = false;

        // Kullanýcý etkileþimini kapatýr.
        canvasGroup.interactable = false;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        //burasý Ship e çarpýp çarpmadýðýný anlayan kod. 
        //normalde buna gerek yok, zaten astroidler tek shipe çarpabilir
        //ama ben her oyun için geçerli olan bir kod yazmak istedim
        while (go != null)
        {
            if (go.CompareTag("Player"))
            {
                Debug.Log("Astroid collided with the spaceship!");

                ShowPanel();
                PauseGame();
                
                // PauseGame();
                // Astroid tagýna sahip olan objeyi bulan kod
                Transform parentObject = transform.parent;

                while (parentObject != null && !parentObject.CompareTag("Astroid"))
                {
                    parentObject = parentObject.parent;
                }


               
                    // bulununca astroid objesini collidirý ile birlikte yok et
                    if (parentObject != null)
                    {
                        Destroy(parentObject.gameObject);
                        
                    }
          
                

                return;
            }

            if (go.transform.parent == null)
                break;

            go = go.transform.parent.gameObject;
        }

    }



}
