using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public AudioClip music = null;
    public static AudioSource audioSource;
    public static AudioManager instance { get; private set; }
    private bool gameSound = false;
    public Slider volumeValue = null;

    public void SoundMute()
    {
        gameSound = !gameSound; //실행할 때 마다 반대값을 넣어준다.
        if (gameSound == true)
        {
            audioSource.mute = true;
        }
        else if (gameSound == false)
        {
            audioSource.mute = false;
        }
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
        if (music != null)
        {
            audioSource.clip = music;
            audioSource.loop = true;
            audioSource.Play();
            //audioSource.volume = 0.3f;
        }
    }
    public void PlaySfx(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    void Update()
    {
       audioSource.volume = volumeValue.value;
    }
}
