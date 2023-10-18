using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMaker : MonoBehaviour
{
    public static CoinMaker Instance { get; private set; }
    //kay�t i�in
    private const string COINS_KEY = "Coins";
    private int coins;
    [SerializeField] private TMP_Text coin;


    //bu kodun amac� coin s�n�f�n�n yok olmas�n� �nlemek
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Oyun ba�lad���nda coin say�s�n� Player Prefs'ten �ekiyoruz
        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
        UpdateCoinsUI();
    }

    //coin eklenen kod
    public void AddCoins(int amount)
    {
        // Coin say�s�n� art�r ve PlayerPrefs'te g�ncelle
        coins += amount;
        PlayerPrefs.SetInt(COINS_KEY, coins);
        Debug.Log("eklendi");
        // UI'yi g�ncelle
        UpdateCoinsUI();
    }

    //ship al�nd���nda harcama yapan kod
    public bool SpendCoins(int amount)
    {
        Debug.Log("Spend Coins cagirildi");
        // E�er yeterli coin varsa harcama yap ve true d�nd�r
        if (coins >= amount)
        {
            Debug.Log("Spend Coins cagirildi ve harcandi");
            coins -= amount;
            PlayerPrefs.SetInt(COINS_KEY, coins);

            // UI'yi g�ncelle
            UpdateCoinsUI();

            return true;
        }
        // Yeterli coin yoksa false d�nd�r
        else
        {
            return false;
        }
    }

    //textte g�steren kod
    private void UpdateCoinsUI()
    {
        coin.text = coins.ToString();
    }
}
