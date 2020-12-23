using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private Sounds sounds;
    private GameObject soundGameObject;

    private void Start() {
        sounds = GameObject.Find("Sounds").GetComponent<Sounds>();
        soundGameObject = new GameObject("Sound");
    }

    public void PlayBombSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.bombSound);
    }
    
    public void PlayGunSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.gunSound);
    }
    
    public void PlayMedKitSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.medKitSound);
    }
    
    public void PlayCollectSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.collectSound);
    }
}
