using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGameButtons : MonoBehaviour {
    
    private Toggle toggleHumanBat;
    private Toggle toggleAIBat;
    private Toggle toggleHumanBunny;
    private Toggle toggleAIBunny;
    private Toggle toggleHumanDuck;
    private Toggle toggleAIDuck;
    private Toggle toggleHumanChicken;
    private Toggle toggleAIChicken;

    private int count;

    private TextMeshProUGUI warning;
    private void Start() {
        toggleHumanBat = GameObject.Find("ToggleHuman").GetComponent<Toggle>();
        toggleAIBat = GameObject.Find("ToggleAI").GetComponent<Toggle>();
        toggleHumanBunny = GameObject.Find("ToggleHuman2").GetComponent<Toggle>();
        toggleAIBunny = GameObject.Find("ToggleAI2").GetComponent<Toggle>();
        toggleHumanDuck = GameObject.Find("ToggleHuman3").GetComponent<Toggle>();
        toggleAIDuck = GameObject.Find("ToggleAI3").GetComponent<Toggle>();
        toggleHumanChicken = GameObject.Find("ToggleHuman4").GetComponent<Toggle>();
        toggleAIChicken = GameObject.Find("ToggleAI4").GetComponent<Toggle>();

        count = 0;
        warning = GameObject.Find("Warning").GetComponent<TextMeshProUGUI>();
    }

    public void Play() {
        PreSettings preSettings = new PreSettings();

        if (toggleHumanBat.isOn || toggleAIBat.isOn) {
            preSettings.IsBatPlaying = true;
            count++;
        }
        else preSettings.IsBatPlaying = false;

        if (toggleHumanBunny.isOn || toggleAIBunny.isOn) {
            preSettings.IsBunnyPlaying = true;
            count++;
        }
        else preSettings.IsBunnyPlaying = false;

        if (toggleHumanDuck.isOn || toggleAIDuck.isOn) {
            preSettings.IsDuckPlaying = true;
            count++;
        }
        else preSettings.IsDuckPlaying = false;

        if (toggleHumanChicken.isOn || toggleAIChicken.isOn) {
            preSettings.IsChickenPlaying = true;
            count++;
        }
        else preSettings.IsChickenPlaying = false;

        preSettings.IsAIBat = toggleAIBat.isOn;
        preSettings.IsAIBunny = toggleAIBunny.isOn;
        preSettings.IsAIDuck = toggleAIDuck.isOn;
        preSettings.IsAIChicken = toggleAIChicken.isOn;
        
        if (count > 1) SceneManager.LoadScene("Scenes/SampleScene");
        else warning.SetText("Pick at least 2 players");
    }

    public void Back() {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void ToggleBatHumanClicked() {
        if (toggleAIBat.isOn) toggleAIBat.isOn = false;
    }
    
    public void ToggleBunnyHumanClicked() {
        if (toggleAIBunny.isOn) toggleAIBunny.isOn = false;
    }
    
    public void ToggleDuckHumanClicked() {
        if (toggleAIDuck.isOn) toggleAIDuck.isOn = false;
    }
    
    public void ToggleChickenHumanClicked() {
        if (toggleAIChicken.isOn) toggleAIChicken.isOn = false;
    }
    
    public void ToggleBatAIClicked() {
        if (toggleHumanBat.isOn) toggleHumanBat.isOn = false;
    }
    
    public void ToggleBunnyAIClicked() {
        if (toggleHumanBunny.isOn) toggleHumanBunny.isOn = false;
    }
    
    public void ToggleDuckAIClicked() {
        if (toggleHumanDuck.isOn) toggleHumanDuck.isOn = false;
    }
    
    public void ToggleChickenAIClicked() {
        if (toggleHumanChicken.isOn) toggleHumanChicken.isOn = false;
    }
}
