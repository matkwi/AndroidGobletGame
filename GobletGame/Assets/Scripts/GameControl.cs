using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    //private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    public static GameObject Bat, Bunny, Duck, Chicken;
    public static bool isBatPlaying = true, isBunnyPlaying = true, isDuckPlaying = true, isChickenPlaying = true;

    public static int diceSideThrown = 10;
    public static int BatStartWaypoint = 0;
    public static int BunnyStartWaypoint = 0;
    public static int DuckStartWaypoint = 0;
    public static int ChickenStartWaypoint = 0;

    public static bool gameOver = false;

    // Use this for initialization
    void Start () {

        //whoWinsTextShadow = GameObject.Find("WhoWinsText");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //player2MoveText = GameObject.Find("Player2MoveText");

        if (isBatPlaying) Bat = GameObject.Find("Bat");
        else Destroy(GameObject.Find("Bat"));
        
        if (isBunnyPlaying) Bunny = GameObject.Find("Bunny");
        else Destroy(GameObject.Find("Bunny"));
        
        if (isDuckPlaying) Duck = GameObject.Find("Duck");
        else Destroy(GameObject.Find("Duck"));
        
        if (isChickenPlaying) Chicken = GameObject.Find("Chicken");
        else Destroy(GameObject.Find("Chicken"));

        if (isBatPlaying) {
            Bat.GetComponent<Player>().moveAllowed = false;
            Bat.GetComponent<Player>().myTurn = 1;
        }

        if (isBunnyPlaying) {
            Bunny.GetComponent<Player>().moveAllowed = false;
            Bunny.GetComponent<Player>().myTurn = 2;

        }

        if (isDuckPlaying) {
            Duck.GetComponent<Player>().moveAllowed = false;
            Duck.GetComponent<Player>().myTurn = 3;
        }

        if (isChickenPlaying) {
            Chicken.GetComponent<Player>().moveAllowed = false;
            Chicken.GetComponent<Player>().myTurn = 4;
        }

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isBatPlaying) {
            if (Bat.GetComponent<Player>().iterator >= diceSideThrown) {
                if (Bat.GetComponent<Player>().transform.position == Bat.GetComponent<Player>()
                    .waypoints[Bat.GetComponent<Player>().waypointIndex].transform.position) {
                    Bat.GetComponent<Player>().iterator = 0;
                    Bat.GetComponent<Player>().moveAllowed = false;
                    Dice.playerIsMoving = false;
                    
                    if(isBunnyPlaying) Bunny.GetComponent<Player>().refreshEq = true;
                    else if(isDuckPlaying) Duck.GetComponent<Player>().refreshEq = true;
                    else if(isChickenPlaying) Chicken.GetComponent<Player>().refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                BatStartWaypoint = Bat.GetComponent<Player>().waypointIndex - 1;
            }
            
            if (Bat.GetComponent<Player>().waypointIndex == Bat.GetComponent<Player>().waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isBunnyPlaying) {
            if (Bunny.GetComponent<Player>().iterator >= diceSideThrown) {
                if (Bunny.GetComponent<Player>().transform.position == Bunny.GetComponent<Player>()
                    .waypoints[Bunny.GetComponent<Player>().waypointIndex].transform.position) {
                    Bunny.GetComponent<Player>().iterator = 0;
                    Bunny.GetComponent<Player>().moveAllowed = false;
                    Dice.playerIsMoving = false;

                    if (isDuckPlaying) Duck.GetComponent<Player>().refreshEq = true;
                    else if (isChickenPlaying) Chicken.GetComponent<Player>().refreshEq = true;
                    else if (isBatPlaying) Bat.GetComponent<Player>().refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                BunnyStartWaypoint = Bunny.GetComponent<Player>().waypointIndex - 1;
            }
            
            if (Bunny.GetComponent<Player>().waypointIndex == Bunny.GetComponent<Player>().waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isDuckPlaying) {
            if (Duck.GetComponent<Player>().iterator >= diceSideThrown) {
                if (Duck.GetComponent<Player>().transform.position == Duck.GetComponent<Player>()
                    .waypoints[Duck.GetComponent<Player>().waypointIndex].transform.position) {
                    Duck.GetComponent<Player>().iterator = 0;
                    Duck.GetComponent<Player>().moveAllowed = false;
                    Dice.playerIsMoving = false;

                    if (isChickenPlaying) Chicken.GetComponent<Player>().refreshEq = true;
                    else if (isBatPlaying) Bat.GetComponent<Player>().refreshEq = true;
                    else if (isBunnyPlaying) Bunny.GetComponent<Player>().refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                DuckStartWaypoint = Duck.GetComponent<Player>().waypointIndex - 1;
            }
            
            if (Duck.GetComponent<Player>().waypointIndex == Duck.GetComponent<Player>().waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isChickenPlaying) {
            if (Chicken.GetComponent<Player>().iterator >= diceSideThrown) {
                if (Chicken.GetComponent<Player>().transform.position == Chicken.GetComponent<Player>()
                    .waypoints[Chicken.GetComponent<Player>().waypointIndex].transform.position) {
                    Chicken.GetComponent<Player>().iterator = 0;
                    Chicken.GetComponent<Player>().moveAllowed = false;
                    Dice.playerIsMoving = false;

                    if (isBatPlaying) Bat.GetComponent<Player>().refreshEq = true;
                    else if (isBunnyPlaying) Bunny.GetComponent<Player>().refreshEq = true;
                    else if (isDuckPlaying) Duck.GetComponent<Player>().refreshEq = true;
                }

                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                ChickenStartWaypoint = Chicken.GetComponent<Player>().waypointIndex - 1;
            }
            
            if (Chicken.GetComponent<Player>().waypointIndex == Chicken.GetComponent<Player>().waypoints.Length) {
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
                Bat.GetComponent<Player>().moveAllowed = true;
                break;

            case 2:
                Bunny.GetComponent<Player>().moveAllowed = true;
                break;
            
            case 3:
                Duck.GetComponent<Player>().moveAllowed = true;
                break;
            
            case 4:
                Chicken.GetComponent<Player>().moveAllowed = true;
                break;
            
        }
    }
}
