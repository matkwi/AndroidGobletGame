using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HTPImages : MonoBehaviour {
    
    [SerializeField] public GameObject Image1;
    [SerializeField] public GameObject Image2;
    [SerializeField] public GameObject Image3;
    [SerializeField] public GameObject Image4;
    [SerializeField] public GameObject Image5;

    public string Text1 = "GobletGame is turn based. The aim of the game is to collect 4 goblets which you can take from chest if you have 40 keys.";
    public string Text2 = "Before the game you can choose 2-4 players and if every each of them is controlled by human or computer.";
    public string Text3 = "To move you need roll the dice which is in the right corner of the screen.";
    public string Text4 = "Before each turn you can use items from your equipment to shoot your opponents or heal yourself. Items are on the bottom of the screen.";
    public string Text5 = "To collect items you just need to be lucky and step on to the item by rolling the dice :)";

    public TextMeshProUGUI TutorialText;

    public int counter;
    
    private void Start() {
        TutorialText = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();
        counter = 1;
    }
}
