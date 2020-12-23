using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public static int whosTurn;
    private bool coroutineAllowed = true;
    public static bool playerIsMoving;
    public bool AIPlayerDiceRoll;
    
    private Images images;

    // Use this for initialization
	private void Start () {
        playerIsMoving = false;
        images = GameObject.Find("Images").GetComponent<Images>();
        SetWhosTurnImage();
        AIPlayerDiceRoll = false;
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[9];
	}

    private void Update() {
        if (!playerIsMoving) {
            if (!GameControl.GameOver && coroutineAllowed) {
                if (AIPlayerDiceRoll) {
                    SetEquipmentImages();
                    StartCoroutine("RollTheDice");
                    AIPlayerDiceRoll = false;
                }
            }
        }
    }

    private void SetWhosTurnImage() {
        if (whosTurn == 1) images.SetWhosTurnImage("Bat");
        else if (whosTurn == 2) images.SetWhosTurnImage("Bunny");
        else if (whosTurn == 3) images.SetWhosTurnImage("Duck");
        else if (whosTurn == 4) images.SetWhosTurnImage("Chicken");
    }

    private void OnMouseDown()
    {
        if (!playerIsMoving) {
            if (!GameControl.GameOver && coroutineAllowed) {
                SetEquipmentImages();
                StartCoroutine("RollTheDice");
            }
        }
    }

    private void SetEquipmentImages() {
        images.SetBombSelected(false);
        images.SetGunSelected(false);
        images.SetMedKitSelected(false);
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++) {
            randomDiceSide = Random.Range(1, 10);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        playerIsMoving = true;

        GameControl.diceSideThrown = randomDiceSide;

        if (whosTurn == 1 && GameControl.isBatPlaying) {
            GameControl.MovePlayer(1);
        }

        if (whosTurn == 2 && GameControl.isBunnyPlaying) {
            GameControl.MovePlayer(2);
        }

        if (whosTurn == 3 && GameControl.isDuckPlaying) {
            GameControl.MovePlayer(3);
        }

        if (whosTurn == 4 && GameControl.isChickenPlaying) {
            GameControl.MovePlayer(4);
        }

        whosTurn += 1;
        if (whosTurn <= 4) {
            while (!GameControl.whoIsPlaying[whosTurn]) {
                whosTurn += 1;
                if (whosTurn == 5 || whosTurn == 6) whosTurn = 1;
                if (whosTurn > 4) break;
            }
        }
        if (whosTurn == 5 || whosTurn == 6) whosTurn = 1;
        coroutineAllowed = true;
    }
    
    public int getWhosTurn() {
        return whosTurn;
    }
}
