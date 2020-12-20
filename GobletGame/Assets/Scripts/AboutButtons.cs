using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutButtons : MonoBehaviour {

    public void Back() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
