using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private Sounds _sounds;
    private GameObject _soundGameObject;

    private void Start() {
        _sounds = GameObject.Find("Sounds").GetComponent<Sounds>();
        _soundGameObject = new GameObject("Sound");
    }

    public void PlayBombSound() {
        AudioSource audioSource = _soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(_sounds.bombSound);
    }
    
    public void PlayGunSound() {
        AudioSource audioSource = _soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(_sounds.gunSound);
    }
    
    public void PlayMedKitSound() {
        AudioSource audioSource = _soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(_sounds.medKitSound);
    }
    
    public void PlayCollectSound() {
        AudioSource audioSource = _soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(_sounds.collectSound);
    }
}
