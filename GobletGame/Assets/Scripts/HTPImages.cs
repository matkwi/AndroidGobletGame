using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HTPImages : MonoBehaviour {
    
    [FormerlySerializedAs("Image1")] [SerializeField] public GameObject image1;
    [FormerlySerializedAs("Image2")] [SerializeField] public GameObject image2;
    [FormerlySerializedAs("Image3")] [SerializeField] public GameObject image3;
    [FormerlySerializedAs("Image4")] [SerializeField] public GameObject image4;
    [FormerlySerializedAs("Image5")] [SerializeField] public GameObject image5;

    [FormerlySerializedAs("Text1")] public string text1 = "GobletGame is turn based. The aim of the game is to collect 4 goblets which you can take from chest if you have 40 keys.";
    [FormerlySerializedAs("Text2")] public string text2 = "Before the game you can choose 2-4 players and if every each of them is controlled by human or computer.";
    [FormerlySerializedAs("Text3")] public string text3 = "To move you need roll the dice which is in the right corner of the screen.";
    [FormerlySerializedAs("Text4")] public string text4 = "Before each turn you can use items from your equipment to shoot your opponents or heal yourself. Items are on the bottom of the screen.";
    [FormerlySerializedAs("Text5")] public string text5 = "To collect items you just need to be lucky and step on to the item by rolling the dice :)";

    [FormerlySerializedAs("TutorialText")] public TextMeshProUGUI tutorialText;

    public int counter;
    
    private void Start() {
        tutorialText = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();
        counter = 1;
    }
}
