using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoWon {

    private static string winner;

    public WhoWon() {
        
    }

    public string Winner {
        get => winner;
        set => winner = value;
    }
}
