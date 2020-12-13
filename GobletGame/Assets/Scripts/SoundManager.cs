using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager {
    
    static Sounds sounds = GameObject.Find("Sounds").GetComponent<Sounds>();
    private static GameObject soundGameObject = new GameObject("Sound");
    public static void PlayBombSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.bombSound);
    }
    
    public static void PlayGunSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.gunSound);
    }
    
    public static void PlayMedKitSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.medKitSound);
    }
    
    public static void PlayCollectSound() {
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sounds.collectSound);
    }
}
