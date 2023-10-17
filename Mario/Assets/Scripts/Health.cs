using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static Health instance;
    // Start is called before the first frame update
    private void Awake(){
        instance=this;
    }
    void Start()
    {
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        AudioController.instance.PlayMusic(3); 
        currentHealth--;
        if(currentHealth <= 0)

        {

            currentHealth=0;
            gameObject.SetActive(false);
            Application.LoadLevel("GameOver");
        }
        UIController.instance.UpdateHeartMeter();
    }
}
