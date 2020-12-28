using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class InGameButtons : MonoBehaviour {

    [SerializeField] private GameObject pauseMenu;

    private Toggle _toggleSound;

    public void PauseButton() {
        pauseMenu.SetActive(true);
        _toggleSound = GameObject.Find("ToggleSound").GetComponent<Toggle>();
        _toggleSound.isOn = AudioListener.volume.Equals(1f);
        Time.timeScale = 0f;
    }

    public void ToggleSound() {
        if (AudioListener.volume.Equals(1f)) AudioListener.volume = 0f;
        else AudioListener.volume = 1f;
    }

    public void Back() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit() {
        Application.Quit();
    }
    
}
