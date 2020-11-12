using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour {
    
    [SerializeField] private GameObject Bomb;
    [SerializeField] private GameObject BombSelected;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject GunSelected;
    [SerializeField] private GameObject MedKit;
    [SerializeField] private GameObject MedKitSelected;

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
