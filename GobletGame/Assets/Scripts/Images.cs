using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Images : MonoBehaviour {
    
    [FormerlySerializedAs("Bomb")] [SerializeField] public GameObject bomb;
    [FormerlySerializedAs("BombSelected")] [SerializeField] private GameObject bombSelected;
    [FormerlySerializedAs("Gun")] [SerializeField] public GameObject gun;
    [FormerlySerializedAs("GunSelected")] [SerializeField] private GameObject gunSelected;
    [FormerlySerializedAs("MedKit")] [SerializeField] public GameObject medKit;
    [FormerlySerializedAs("MedKitSelected")] [SerializeField] private GameObject medKitSelected;
    [FormerlySerializedAs("Key")] [SerializeField] public GameObject key;
    [FormerlySerializedAs("Bat")] [SerializeField] public GameObject bat;
    [FormerlySerializedAs("Bunny")] [SerializeField] public GameObject bunny;
    [FormerlySerializedAs("Duck")] [SerializeField] public GameObject duck;
    [FormerlySerializedAs("Chicken")] [SerializeField] public GameObject chicken;

    public void SetBombSelected(bool x) {
        bomb.SetActive(!x);
        bombSelected.SetActive(x);
    }
    
    public void SetGunSelected(bool x) {
        gun.SetActive(!x);
        gunSelected.SetActive(x);
    }
    
    public void SetMedKitSelected(bool x) {
        medKit.SetActive(!x);
        medKitSelected.SetActive(x);
    }

    public void SetWhosTurnImage(string x) {
        switch (x) {
            case "Bat":
                bat.SetActive(true);
                bunny.SetActive(false);
                duck.SetActive(false);
                chicken.SetActive(false);
                break;
            case "Bunny":
                bat.SetActive(false);
                bunny.SetActive(true);
                duck.SetActive(false);
                chicken.SetActive(false);
                break;
            case "Duck":
                bat.SetActive(false);
                bunny.SetActive(false);
                duck.SetActive(true);
                chicken.SetActive(false);
                break;
            case "Chicken":
                bat.SetActive(false);
                bunny.SetActive(false);
                duck.SetActive(false);
                chicken.SetActive(true);
                break;
        }
    }

}
