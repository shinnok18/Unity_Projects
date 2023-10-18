using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShipControl : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    private Camera cam;
    private Rigidbody rb;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("trigger oldu: "+ other.name);
        if (other.CompareTag("Finish"))
        {
            //sonraki sahneye ge�ecek, kazand�n�z!!!
            Debug.Log("TEBR�KLER OYUNU KAZANDINIZ!!!");
            SceneManager.LoadScene("SampleScene");

        }


    }

    // Update is called once per frame
    void Update()
    {
        moveIt();
        stayInScreen();
    }

    public void moveIt()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {

            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = cam.ScreenToWorldPoint(touchPosition);
            // Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, cam.nearClipPlane));

            direction = worldPosition - transform.position;

            direction.z = 0;
            direction.Normalize();
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    public void stayInScreen()
    {
        Vector3 newPos = transform.position;
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);

        if (viewPos.x > 1)
        {
            newPos.x = -newPos.x + 0.2f;
        }
        else if (viewPos.x < 0)
        {
            newPos.x = -newPos.x - 0.2f;
        }

        if (viewPos.y > 1)
        {
            newPos.y = -newPos.y + 0.2f;
        }
        else if (viewPos.y < 0)
        {
            newPos.y = -newPos.y - 0.2f;
        }

        transform.position = newPos;

    }

    private void FixedUpdate()
    {
        if (direction == Vector3.zero)
        {
            return;
        }

        rb.AddForce(direction * moveSpeed, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
