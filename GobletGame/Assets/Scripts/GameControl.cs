using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    //private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    public static Player Bat, Bunny, Duck, Chicken;
    public static bool isBatPlaying = true, isBunnyPlaying = true, isDuckPlaying = true, isChickenPlaying = true;
    
    public static int diceSideThrown = 10;

    public static bool gameOver = false;

    // Use this for initialization
    void Start () {

        //whoWinsTextShadow = GameObject.Find("WhoWinsText");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //player2MoveText = GameObject.Find("Player2MoveText");

        if (isBatPlaying) Bat = GameObject.Find("Bat").GetComponent<Player>();
        else Destroy(GameObject.Find("Bat"));
        
        if (isBunnyPlaying) Bunny = GameObject.Find("Bunny").GetComponent<Player>();
        else Destroy(GameObject.Find("Bunny"));
        
        if (isDuckPlaying) Duck = GameObject.Find("Duck").GetComponent<Player>();
        else Destroy(GameObject.Find("Duck"));
        
        if (isChickenPlaying) Chicken = GameObject.Find("Chicken").GetComponent<Player>();
        else Destroy(GameObject.Find("Chicken"));

        if (isBatPlaying) {
            Bat.moveAllowed = false;
            Bat.myTurn = 1;
        }

        if (isBunnyPlaying) {
            Bunny.moveAllowed = false;
            Bunny.myTurn = 2;

        }

        if (isDuckPlaying) {
            Duck.moveAllowed = false;
            Duck.myTurn = 3;
        }

        if (isChickenPlaying) {
            Chicken.moveAllowed = false;
            Chicken.myTurn = 4;
        }

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update() {

        if (isBatPlaying) {
            if (Bat.iterator >= diceSideThrown) {
                if (Bat.transform.position == Bat.waypoints[Bat.waypointIndex].transform.position) {
                    Bat.iterator = 0;
                    Bat.moveAllowed = false;
                    Dice.playerIsMoving = false;
                    
                    if(isBunnyPlaying) Bunny.refreshEq = true;
                    else if(isDuckPlaying) Duck.refreshEq = true;
                    else if(isChickenPlaying) Chicken.refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
            }
            
            if (Bat.waypointIndex == Bat.waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isBunnyPlaying) {
            if (Bunny.iterator >= diceSideThrown) {
                if (Bunny.transform.position == Bunny.waypoints[Bunny.waypointIndex].transform.position) {
                    Bunny.iterator = 0;
                    Bunny.moveAllowed = false;
                    Dice.playerIsMoving = false;

                    if (isDuckPlaying) Duck.refreshEq = true;
                    else if (isChickenPlaying) Chicken.refreshEq = true;
                    else if (isBatPlaying) Bat.refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
            }
            
            if (Bunny.waypointIndex == Bunny.waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isDuckPlaying) {
            if (Duck.iterator >= diceSideThrown) {
                if (Duck.transform.position == Duck.waypoints[Duck.waypointIndex].transform.position) {
                    Duck.iterator = 0;
                    Duck.moveAllowed = false;
                    Dice.playerIsMoving = false;

                    if (isChickenPlaying) Chicken.refreshEq = true;
                    else if (isBatPlaying) Bat.refreshEq = true;
                    else if (isBunnyPlaying) Bunny.refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
            }
            
            if (Duck.waypointIndex == Duck.waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isChickenPlaying) {
            if (Chicken.iterator >= diceSideThrown) {
                if (Chicken.transform.position == Chicken.waypoints[Chicken.waypointIndex].transform.position) {
                    Chicken.iterator = 0;
                    Chicken.moveAllowed = false;
                    Dice.playerIsMoving = false;

                    if (isBatPlaying) Bat.refreshEq = true;
                    else if (isBunnyPlaying) Bunny.refreshEq = true;
                    else if (isDuckPlaying) Duck.refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
            }
            
            if (Chicken.waypointIndex == Chicken.waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                Bat.moveAllowed = true;
                break;

            case 2:
                Bunny.moveAllowed = true;
                break;
            
            case 3:
                Duck.moveAllowed = true;
                break;
            
            case 4:
                Chicken.moveAllowed = true;
                break;
            
        }
    }
}
