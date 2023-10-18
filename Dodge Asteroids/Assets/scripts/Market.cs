using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public void OnSpaceshipButtonClicked(SpaceShip spaceship)
    {
        Debug.Log("butona týklandý, gemi satýn alýnmaya calýsýlýyor!!");
        if (CoinMaker.Instance.SpendCoins(100)) // Burada parayý harcýyoruz.
        {
            Debug.Log("para çýktý, gemi satýn alýnýyor");
            GameManager.Instance.ChangeSpaceship(spaceship);
        }
    }
}
