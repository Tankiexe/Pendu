using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    
    public AudioSource master;
    public AudioSource music;
    public AudioSource hit;
    public AudioSource death;
    public AudioSource correct;
    public AudioSource incorrect;
    public Slider sounds;
    public AudioMixer audioMixer;
    public Slider musicSound;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSfxValueChange(string mixerGroup)
    {
        float t = sounds.value;
        float db = Mathf.Lerp(-20f, 5f, t);
        audioMixer.SetFloat(mixerGroup ,db);
        
    }

    public void OnMusicValueChange(string mixerGroup)
    {
        float t = musicSound.value;
        float db = Mathf.Lerp(-20f, 5f, t);
        audioMixer.SetFloat(mixerGroup, db);
        
    }
    public void ToPlaySound(AudioSource source)
    {
        source.Play();
    }
}
