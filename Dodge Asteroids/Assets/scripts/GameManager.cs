using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SpaceShip defaultSpaceShip;
    [SerializeField] public List<SpaceShip> spaceships;
    public static SpaceShip activeSpaceship;

    // Player referansýný saklamak için bir deðiþken
    private GameObject player;

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

        if (activeSpaceship == null)
        {
            activeSpaceship = defaultSpaceShip;
        }
    }
    void Start()
    {
        // sceneLoaded eventine bir listener ekliyoruz
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Eðer sahne SampleScene ise CreateShip fonksiyonunu çaðýr
        if (scene.name == "SampleScene")
        {
            CreateShip();
        }
    }

    void CreateShip()
    {
        Debug.Log("createShip methodu cagirildi");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Eski uzay gemisini yok et
        foreach (Transform child in player.transform)
        {
            Destroy(child.gameObject);
        }

        // Yeni uzay gemisini oluþtur ve player objesinin child'i yap
        GameObject newShipObject = Instantiate(activeSpaceship.prefab, player.transform);
        newShipObject.transform.localPosition = Vector3.zero;
        newShipObject.transform.localRotation = Quaternion.identity;

        Debug.Log("New ship: " + activeSpaceship.name);
    }

    void OnDestroy()
    {
        // sceneLoaded eventinden listener'ý çýkarýyoruz
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeSpaceship(SpaceShip newSpaceship)
    {
        if (CoinMaker.Instance.SpendCoins(500)) // Burada parayý harcýyoruz.
        {
            Debug.Log("para çýktý, gemi satýn alýnýyor");
            activeSpaceship = newSpaceship;
            Debug.Log("New ship: " + activeSpaceship.name);
            // Herhangi bir sahne deðiþikliðini burada ekleyin
        }

    }
}
