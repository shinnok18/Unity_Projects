using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinMaker : MonoBehaviour
{
    public static CoinMaker Instance { get; private set; }
    //kayýt için
    private const string COINS_KEY = "Coins";
    private int coins;
    [SerializeField] private TMP_Text coin;


    //bu kodun amacý coin sýnýfýnýn yok olmasýný önlemek
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

        // Oyun baþladýðýnda coin sayýsýný Player Prefs'ten çekiyoruz
        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
        UpdateCoinsUI();
    }

    //coin eklenen kod
    public void AddCoins(int amount)
    {
        // Coin sayýsýný artýr ve PlayerPrefs'te güncelle
        coins += amount;
        PlayerPrefs.SetInt(COINS_KEY, coins);
        Debug.Log("eklendi");
        // UI'yi güncelle
        UpdateCoinsUI();
    }

    //ship alýndýðýnda harcama yapan kod
    public bool SpendCoins(int amount)
    {
        Debug.Log("Spend Coins cagirildi");
        // Eðer yeterli coin varsa harcama yap ve true döndür
        if (coins >= amount)
        {
            Debug.Log("Spend Coins cagirildi ve harcandi");
            coins -= amount;
            PlayerPrefs.SetInt(COINS_KEY, coins);

            // UI'yi güncelle
            UpdateCoinsUI();

            return true;
        }
        // Yeterli coin yoksa false döndür
        else
        {
            return false;
        }
    }

    //textte gösteren kod
    private void UpdateCoinsUI()
    {
        coin.text = coins.ToString();
    }
}
