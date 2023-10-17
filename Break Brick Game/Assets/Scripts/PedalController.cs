using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalController : MonoBehaviour
{
    [SerializeField] float ekranGenisligiUnitCinsinden = 16f;




    // Use this for initialization
    void Start()
    {
      

    }
    // Update is called once per frame
    void Update()
    {
        float farePozUnitCinsinden = Input.mousePosition.x / Screen.width * ekranGenisligiUnitCinsinden;
        Vector2 pedalPozisyonu = new Vector2(farePozUnitCinsinden, transform.position.y);
        transform.position = pedalPozisyonu;
    }

}
