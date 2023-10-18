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
        // Alfa de�erini 1 yaparak paneli g�r�n�r k�lar.
        canvasGroup.alpha = 1;

        // Raycast'lar� engellemeyi a�ar.
        canvasGroup.blocksRaycasts = true;

        // Kullan�c� etkile�imini a�ar.
        canvasGroup.interactable = true;
    }

    public void HidePanel()
    {
        // Alfa de�erini 0 yaparak paneli g�r�nmez k�lar.
        canvasGroup.alpha = 0;

        // Raycast'lar� engellemeyi kapat�r.
        canvasGroup.blocksRaycasts = false;

        // Kullan�c� etkile�imini kapat�r.
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
        //buras� Ship e �arp�p �arpmad���n� anlayan kod. 
        //normalde buna gerek yok, zaten astroidler tek shipe �arpabilir
        //ama ben her oyun i�in ge�erli olan bir kod yazmak istedim
        while (go != null)
        {
            if (go.CompareTag("Player"))
            {
                Debug.Log("Astroid collided with the spaceship!");

                ShowPanel();
                PauseGame();
                
                // PauseGame();
                // Astroid tag�na sahip olan objeyi bulan kod
                Transform parentObject = transform.parent;

                while (parentObject != null && !parentObject.CompareTag("Astroid"))
                {
                    parentObject = parentObject.parent;
                }


               
                    // bulununca astroid objesini collidir� ile birlikte yok et
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
