using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public AudioSource music;
    public GameObject panel;
    public Text levelDisplay;
    void Start()
    {
        music.volume = .5f;
        panel.SetActive(false);
        levelDisplay.text = "50%";
        PlayerPrefs.SetFloat("volume", .5f);
    }
    public void Open()
    {
        panel.SetActive(true);
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Up()
    {
        music.volume += .1f;
        levelDisplay.text = Mathf.RoundToInt(music.volume * 100) + "%";
    }
    public void Down()
    {
        music.volume -= .1f;
        levelDisplay.text = Mathf.RoundToInt(music.volume * 100) + "%";
    }
}
