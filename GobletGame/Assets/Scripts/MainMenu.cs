using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void CreateGame() {
        SceneManager.LoadScene("Scenes/CreateNewGame");
    }

    public void HowToPlay() {
        SceneManager.LoadScene("Scenes/HowToPlay");
    }
    
    public void About() {
        SceneManager.LoadScene("Scenes/About");
    }

    public void Exit() {
        Application.Quit();
    }
}
