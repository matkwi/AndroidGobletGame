using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour {

    private Sprite[] _diceSides;
    private SpriteRenderer _rend;
    public static int WhosTurn;
    private bool _coroutineAllowed = true;
    public static bool PlayerIsMoving;
    [FormerlySerializedAs("AIPlayerDiceRoll")] public bool aiPlayerDiceRoll;
    
    private Images _images;

    // Use this for initialization
	private void Start () {
        PlayerIsMoving = false;
        _images = GameObject.Find("Images").GetComponent<Images>();
        SetWhosTurnImage();
        aiPlayerDiceRoll = false;
        _rend = GetComponent<SpriteRenderer>();
        _diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        _rend.sprite = _diceSides[9];
	}

    private void Update() {
        if (!PlayerIsMoving) {
            if (!GameControl.GameOver && _coroutineAllowed) {
                if (aiPlayerDiceRoll) {
                    SetEquipmentImages();
                    StartCoroutine("RollTheDice");
                    aiPlayerDiceRoll = false;
                }
            }
        }
    }

    private void SetWhosTurnImage() {
        if (WhosTurn == 1) _images.SetWhosTurnImage("Bat");
        else if (WhosTurn == 2) _images.SetWhosTurnImage("Bunny");
        else if (WhosTurn == 3) _images.SetWhosTurnImage("Duck");
        else if (WhosTurn == 4) _images.SetWhosTurnImage("Chicken");
    }

    private void OnMouseDown()
    {
        if (!PlayerIsMoving) {
            if (!GameControl.GameOver && _coroutineAllowed) {
                SetEquipmentImages();
                StartCoroutine("RollTheDice");
            }
        }
    }

    private void SetEquipmentImages() {
        _images.SetBombSelected(false);
        _images.SetGunSelected(false);
        _images.SetMedKitSelected(false);
    }

    private IEnumerator RollTheDice()
    {
        _coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++) {
            randomDiceSide = Random.Range(1, 10);
            _rend.sprite = _diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        PlayerIsMoving = true;

        GameControl.DiceSideThrown = randomDiceSide;
        
        if (WhosTurn == 1 && GameControl.IsBatPlaying) {
            GameControl.MovePlayer(1);
        }

        if (WhosTurn == 2 && GameControl.IsBunnyPlaying) {
            GameControl.MovePlayer(2);
        }

        if (WhosTurn == 3 && GameControl.IsDuckPlaying) {
            GameControl.MovePlayer(3);
        }

        if (WhosTurn == 4 && GameControl.IsChickenPlaying) {
            GameControl.MovePlayer(4);
        }

        WhosTurn += 1;
        if (WhosTurn <= 4) {
            while (!GameControl.WhoIsPlaying[WhosTurn]) {
                WhosTurn += 1;
                if (WhosTurn == 5 || WhosTurn == 6) WhosTurn = 1;
                if (WhosTurn > 4) break;
            }
        }
        if (WhosTurn == 5 || WhosTurn == 6) WhosTurn = 1;
        _coroutineAllowed = true;
    }
    
    public int GETWhosTurn() {
        return WhosTurn;
    }
}
