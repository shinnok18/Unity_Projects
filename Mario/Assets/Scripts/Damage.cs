using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        //if(other.gameObject.CompareTag("Player")){
        if(other.tag=="Player"){

        
            //other.gameObject.GetComponent<Health>().TakeDamage();
            //FindObjectOfType<Health>().TakeDamage();
            Health.instance.TakeDamage();
            
        }
        }
    }

