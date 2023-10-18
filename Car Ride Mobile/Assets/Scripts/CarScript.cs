using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarScript : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float turnSpeedVal = 200f;

    private float horizontalInput;
    private int sceneIndex;

    void Start()
    {
        // Mevcut sahnenin indexini al
         sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    // Update is called once per frame
    void Update()
    {
        speed += speedIncrease * Time.deltaTime;
        transform.Rotate(0f, horizontalInput * turnSpeedVal * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        //Debug.Log("trigger oldu: "+ other.name);
        if (other.CompareTag("Finish"))
        {
            //sonraki sahneye geçecek, kazandýnýz!!!
            Debug.Log("TEBRÝKLER OYUNU KAZANDINIZ!!!");
            SceneManager.LoadScene(sceneIndex+1);
        }
        if (other.CompareTag("obstacle"))
        {
            Debug.Log("collision happend!");
            SceneManager.LoadScene(sceneIndex + 1);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("kayaya çarptý: "+collision.gameObject.name);
            SceneManager.LoadScene(sceneIndex+1);
        }
    }



    public void deneme()
    {
        Debug.Log("deneme ");
    }
    public void Turn(int value)
    {
        horizontalInput = value;
    }


}
