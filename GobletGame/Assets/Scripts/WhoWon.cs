using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoWon {

    private static string _winner;

    public WhoWon() {
        
    }

    public string Winner {
        get => _winner;
        set => _winner = value;
    }
}
