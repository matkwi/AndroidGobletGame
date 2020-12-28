using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGameButtons : MonoBehaviour {
    
    private Toggle _toggleHumanBat;
    private Toggle _toggleAIBat;
    private Toggle _toggleHumanBunny;
    private Toggle _toggleAIBunny;
    private Toggle _toggleHumanDuck;
    private Toggle _toggleAIDuck;
    private Toggle _toggleHumanChicken;
    private Toggle _toggleAIChicken;

    private int _count;

    private TextMeshProUGUI _warning;
    private void Start() {
        _toggleHumanBat = GameObject.Find("ToggleHuman").GetComponent<Toggle>();
        _toggleAIBat = GameObject.Find("ToggleAI").GetComponent<Toggle>();
        _toggleHumanBunny = GameObject.Find("ToggleHuman2").GetComponent<Toggle>();
        _toggleAIBunny = GameObject.Find("ToggleAI2").GetComponent<Toggle>();
        _toggleHumanDuck = GameObject.Find("ToggleHuman3").GetComponent<Toggle>();
        _toggleAIDuck = GameObject.Find("ToggleAI3").GetComponent<Toggle>();
        _toggleHumanChicken = GameObject.Find("ToggleHuman4").GetComponent<Toggle>();
        _toggleAIChicken = GameObject.Find("ToggleAI4").GetComponent<Toggle>();

        _count = 0;
        _warning = GameObject.Find("Warning").GetComponent<TextMeshProUGUI>();
    }

    public void Play() {
        PreSettings preSettings = new PreSettings();

        if (_toggleHumanBat.isOn || _toggleAIBat.isOn) {
            preSettings.IsBatPlaying = true;
            _count++;
        }
        else preSettings.IsBatPlaying = false;

        if (_toggleHumanBunny.isOn || _toggleAIBunny.isOn) {
            preSettings.IsBunnyPlaying = true;
            _count++;
        }
        else preSettings.IsBunnyPlaying = false;

        if (_toggleHumanDuck.isOn || _toggleAIDuck.isOn) {
            preSettings.IsDuckPlaying = true;
            _count++;
        }
        else preSettings.IsDuckPlaying = false;

        if (_toggleHumanChicken.isOn || _toggleAIChicken.isOn) {
            preSettings.IsChickenPlaying = true;
            _count++;
        }
        else preSettings.IsChickenPlaying = false;

        preSettings.IsAIBat = _toggleAIBat.isOn;
        preSettings.IsAIBunny = _toggleAIBunny.isOn;
        preSettings.IsAIDuck = _toggleAIDuck.isOn;
        preSettings.IsAIChicken = _toggleAIChicken.isOn;
        
        if (_count > 1) SceneManager.LoadScene("Scenes/SampleScene");
        else _warning.SetText("Pick at least 2 players");
    }

    public void Back() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void ToggleBatHumanClicked() {
        if (_toggleAIBat.isOn) _toggleAIBat.isOn = false;
    }
    
    public void ToggleBunnyHumanClicked() {
        if (_toggleAIBunny.isOn) _toggleAIBunny.isOn = false;
    }
    
    public void ToggleDuckHumanClicked() {
        if (_toggleAIDuck.isOn) _toggleAIDuck.isOn = false;
    }
    
    public void ToggleChickenHumanClicked() {
        if (_toggleAIChicken.isOn) _toggleAIChicken.isOn = false;
    }
    
    public void ToggleBatAIClicked() {
        if (_toggleHumanBat.isOn) _toggleHumanBat.isOn = false;
    }
    
    public void ToggleBunnyAIClicked() {
        if (_toggleHumanBunny.isOn) _toggleHumanBunny.isOn = false;
    }
    
    public void ToggleDuckAIClicked() {
        if (_toggleHumanDuck.isOn) _toggleHumanDuck.isOn = false;
    }
    
    public void ToggleChickenAIClicked() {
        if (_toggleHumanChicken.isOn) _toggleHumanChicken.isOn = false;
    }
}
