using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour {

    private static bool _firstTimePlayed = true;
    
    private void Awake() {
        if (_firstTimePlayed) {
            DontDestroyOnLoad(transform.gameObject);
            _firstTimePlayed = false;
        }
        else Destroy(gameObject);
    }
}
