using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCode : MonoBehaviour
{

    public static AudioCode instance;
    public AudioSource[] musicSource;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

       // DontDestroyOnLoad(transform.gameObject);

        

    }
    // Start is called before the first frame update

    public void PlayMusic(int musicToPlay)
    {
        musicSource[musicToPlay].Stop();
        musicSource[musicToPlay].Play();


    }

}
