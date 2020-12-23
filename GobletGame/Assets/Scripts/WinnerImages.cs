using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerImages : MonoBehaviour {
    
    [SerializeField] public GameObject Bat;
    [SerializeField] public GameObject Bunny;
    [SerializeField] public GameObject Duck;
    [SerializeField] public GameObject Chicken;
    
    // Start is called before the first frame update
    void Start() {
        SetWinner();
    }

    private void SetWinner() {
        WhoWon whoWon = new WhoWon();
        if(whoWon.Winner.Equals("Bat")) Bat.SetActive(true);
        else if(whoWon.Winner.Equals("Bunny")) Bunny.SetActive(true);
        else if(whoWon.Winner.Equals("Duck")) Duck.SetActive(true);
        else if(whoWon.Winner.Equals("Chicken")) Chicken.SetActive(true);
    }
}
