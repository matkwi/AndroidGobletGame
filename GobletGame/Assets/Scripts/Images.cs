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

}
