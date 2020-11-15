using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int whosTurn = 1;
    private bool coroutineAllowed = true;
    public static bool playerIsMoving = false;
    public bool AIPlayerDiceRoll;
    
    private Images images;

    // Use this for initialization
	private void Start () {
        images = GameObject.Find("Images").GetComponent<Images>();
        AIPlayerDiceRoll = false;
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[9];
	}

    private void Update() {
        if (!playerIsMoving) {
            if (!GameControl.gameOver && coroutineAllowed) {
                if (AIPlayerDiceRoll) {
                    SetEquipmentImages();
                    StartCoroutine("RollTheDice");
                    AIPlayerDiceRoll = false;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (!playerIsMoving) {
            if (!GameControl.gameOver && coroutineAllowed) {
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
        else if (whosTurn == 1 && !GameControl.isBatPlaying) {
            whosTurn += 1;
        }
        
        if (whosTurn == 2 && GameControl.isBunnyPlaying) {
            GameControl.MovePlayer(2);
        } 
        else if (whosTurn == 2 && !GameControl.isBunnyPlaying) {
            whosTurn += 1;
        }
        
        if (whosTurn == 3 && GameControl.isDuckPlaying) {
            GameControl.MovePlayer(3);
        } 
        else if (whosTurn == 3 && !GameControl.isDuckPlaying) {
            whosTurn += 1;
        }
        
        if (whosTurn == 4 && GameControl.isChickenPlaying) {
            GameControl.MovePlayer(4);
        } 
        else if (whosTurn == 4 && !GameControl.isChickenPlaying) {
            whosTurn += 1;
        }
        
        whosTurn += 1;
        if (whosTurn == 5 || whosTurn == 6) whosTurn = 1;
        coroutineAllowed = true;
    }

    public int getWhosTurn() {
        return whosTurn;
    }
}
