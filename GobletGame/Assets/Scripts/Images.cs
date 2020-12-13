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

    public void SetWhosTurnImage(int x) {
        switch (x) {
            case 1:
                Bat.SetActive(true);
                Bunny.SetActive(false);
                Duck.SetActive(false);
                Chicken.SetActive(false);
                break;
            case 2:
                Bat.SetActive(false);
                Bunny.SetActive(true);
                Duck.SetActive(false);
                Chicken.SetActive(false);
                break;
            case 3:
                Bat.SetActive(false);
                Bunny.SetActive(false);
                Duck.SetActive(true);
                Chicken.SetActive(false);
                break;
            case 4:
                Bat.SetActive(false);
                Bunny.SetActive(false);
                Duck.SetActive(false);
                Chicken.SetActive(true);
                break;
        }
    }

}
