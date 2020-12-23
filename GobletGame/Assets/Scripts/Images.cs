using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour {
    
    [SerializeField] public GameObject Bomb;
    [SerializeField] private GameObject BombSelected;
    [SerializeField] public GameObject Gun;
    [SerializeField] private GameObject GunSelected;
    [SerializeField] public GameObject MedKit;
    [SerializeField] private GameObject MedKitSelected;
    [SerializeField] public GameObject Key;
    [SerializeField] public GameObject Bat;
    [SerializeField] public GameObject Bunny;
    [SerializeField] public GameObject Duck;
    [SerializeField] public GameObject Chicken;

    public void SetBombSelected(bool x) {
        Bomb.SetActive(!x);
        BombSelected.SetActive(x);
    }
    
    public void SetGunSelected(bool x) {
        Gun.SetActive(!x);
        GunSelected.SetActive(x);
    }
    
    public void SetMedKitSelected(bool x) {
        MedKit.SetActive(!x);
        MedKitSelected.SetActive(x);
    }

    public void SetWhosTurnImage(string x) {
        switch (x) {
            case "Bat":
                Bat.SetActive(true);
                Bunny.SetActive(false);
                Duck.SetActive(false);
                Chicken.SetActive(false);
                break;
            case "Bunny":
                Bat.SetActive(false);
                Bunny.SetActive(true);
                Duck.SetActive(false);
                Chicken.SetActive(false);
                break;
            case "Duck":
                Bat.SetActive(false);
                Bunny.SetActive(false);
                Duck.SetActive(true);
                Chicken.SetActive(false);
                break;
            case "Chicken":
                Bat.SetActive(false);
                Bunny.SetActive(false);
                Duck.SetActive(false);
                Chicken.SetActive(true);
                break;
        }
    }

}
