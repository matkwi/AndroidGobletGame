using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    public static bool playerIsMoving = false;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[9];
	}

    private void OnMouseDown()
    {
        if (!playerIsMoving) {
            if (!GameControl.gameOver && coroutineAllowed)
                StartCoroutine("RollTheDice");
        }
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
        if (whosTurn == 5) whosTurn = 1;
        coroutineAllowed = true;
    }
}
