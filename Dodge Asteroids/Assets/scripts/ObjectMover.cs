using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Hareket etmesini istedi�iniz objenin pozisyonunu g�ncelleyin
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
