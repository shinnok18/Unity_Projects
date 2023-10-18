using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public void OnSpaceshipButtonClicked(SpaceShip spaceship)
    {
        Debug.Log("butona t�kland�, gemi sat�n al�nmaya cal�s�l�yor!!");
        if (CoinMaker.Instance.SpendCoins(100)) // Burada paray� harc�yoruz.
        {
            Debug.Log("para ��kt�, gemi sat�n al�n�yor");
            GameManager.Instance.ChangeSpaceship(spaceship);
        }
    }
}
