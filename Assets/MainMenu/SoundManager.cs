using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("generalVolume"))
        {
            PlayerPrefs.SetFloat("generalVolume",1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("generalVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("generalVolume", volumeSlider.value);
    }
}
