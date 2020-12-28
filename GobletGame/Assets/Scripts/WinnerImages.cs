using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WinnerImages : MonoBehaviour {
    
    [FormerlySerializedAs("Bat")] [SerializeField] public GameObject bat;
    [FormerlySerializedAs("Bunny")] [SerializeField] public GameObject bunny;
    [FormerlySerializedAs("Duck")] [SerializeField] public GameObject duck;
    [FormerlySerializedAs("Chicken")] [SerializeField] public GameObject chicken;
    
    // Start is called before the first frame update
    void Start() {
        SetWinner();
    }

    private void SetWinner() {
        WhoWon whoWon = new WhoWon();
        if(whoWon.Winner.Equals("Bat")) bat.SetActive(true);
        else if(whoWon.Winner.Equals("Bunny")) bunny.SetActive(true);
        else if(whoWon.Winner.Equals("Duck")) duck.SetActive(true);
        else if(whoWon.Winner.Equals("Chicken")) chicken.SetActive(true);
    }
}
