using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Vector2 firlatmaHizi = new Vector2(3f, 16f);
    [SerializeField] private bool oyunBasladi = false;
    [SerializeField] private GameObject ballPrefab;
    public static int ballCount = 0;
    



    private void Awake()
    {
        ballCount++;
    }

    private void OnDestroy()
    {
        ballCount--;
    }


    private void Update()
    {
        if (!oyunBasladi)
        {
            TopuFirlat();
        }
    }



    private void TopuFirlat()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oyunBasladi = true;
            GetComponent<Rigidbody2D>().velocity = firlatmaHizi;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //topu yaa�latan brick
        if (collision.gameObject.CompareTag("slow_brick"))
        {
            Destroy(collision.gameObject);

            firlatmaHizi = new Vector2(3f, 8f);
            GetComponent<Rigidbody2D>().velocity = firlatmaHizi;

            

        }
        //h�zland�rran brick
        else if (collision.gameObject.CompareTag("fast_brick"))
        {


            Destroy(collision.gameObject);

            firlatmaHizi = new Vector2(3f, 18f);
            GetComponent<Rigidbody2D>().velocity = firlatmaHizi;

            
        }
        //�o�altan brick
        else if (collision.gameObject.CompareTag("multiple_brick"))
        {
            

            //topun artaca�� kod
            Destroy(collision.gameObject);

            // Yeni bir top olu�turan kod par�as�, ayn� pozisyon ve d�nd�rme a��s�.
            GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);

            // Yeni topun h�z�
            newBall.GetComponent<Rigidbody2D>().velocity = firlatmaHizi;

        }
    }
}
