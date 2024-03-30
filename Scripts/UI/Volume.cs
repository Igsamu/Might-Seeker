using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void MusicControl(float sliderMusic)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderMusic) * 20);
    }
}
