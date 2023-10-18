using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public Button LevelOneButton;
    public Button LevelTwoButton;
    public Button LevelThreeButton;
    public Button LevelFourButton;
    public Button LevelFiveButton;
    public int musicIndex = 0;

    private void Start()
    {
        LevelOneButton.onClick.AddListener(PlayMusicOnClick);
        LevelTwoButton.onClick.AddListener(PlayMusicOnClick);
        LevelThreeButton.onClick.AddListener(PlayMusicOnClick);
        LevelFourButton.onClick.AddListener(PlayMusicOnClick);
        LevelFiveButton.onClick.AddListener(PlayMusicOnClick);
    }

    private void PlayMusicOnClick()
    {
        AudioController.instance.PlayMusic(musicIndex);
    }
}
