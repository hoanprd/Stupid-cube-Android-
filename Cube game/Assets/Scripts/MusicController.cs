using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider1;
    [SerializeField] Slider volumeSlider2;
    //public AudioSource AS1;
    //public AudioSource AS2;
    public AudioSource BGM;
    public AudioSource JS;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume1"))
        {
            PlayerPrefs.SetFloat("musicVolume1", 1);
            Load1();
        }
        else
        {
            Load1();
        }
        if (!PlayerPrefs.HasKey("musicVolume2"))
        {
            PlayerPrefs.SetFloat("musicVolume2", 1);
            Load2();
        }
        else
        {
            Load2();
        }
    }
    public void ChangeVolume1()
    {
        //AudioListener.volume = volumeSlider1.value;
        BGM.volume = volumeSlider1.value;
        Save1();
    }
    public void ChangeVolume2()
    {
        JS.volume = volumeSlider2.value;
        Save2();
    }
    private void Load1()
    {
        volumeSlider1.value = PlayerPrefs.GetFloat("musicVolume1");
    }
    private void Load2()
    {
        volumeSlider2.value = PlayerPrefs.GetFloat("musicVolume2");
    }
    private void Save1()
    {
        PlayerPrefs.SetFloat("musicVolume1", volumeSlider1.value);
    }
    private void Save2()
    {
        PlayerPrefs.SetFloat("musicVolume2", volumeSlider2.value);
    }
}
