using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    //private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject Bat, Bunny, Duck, Chicken;
    public static bool isBatPlaying = true, isBunnyPlaying = true, isDuckPlaying = true, isChickenPlaying = true;

    public static int diceSideThrown = 0;
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

        if (isBatPlaying) Bat.GetComponent<FollowThePath>().moveAllowed = false;
        if (isBunnyPlaying) Bunny.GetComponent<FollowThePath>().moveAllowed = false;
        if (isDuckPlaying) Duck.GetComponent<FollowThePath>().moveAllowed = false;
        if (isChickenPlaying) Chicken.GetComponent<FollowThePath>().moveAllowed = false;

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isBatPlaying) {
            if (Bat.GetComponent<FollowThePath>().iterator > diceSideThrown) {
                Bat.GetComponent<FollowThePath>().iterator = 1;
                Bat.GetComponent<FollowThePath>().moveAllowed = false;
                Dice.playerIsMoving = false;
                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                BatStartWaypoint = Bat.GetComponent<FollowThePath>().waypointIndex - 1;
            }
            
            if (Bat.GetComponent<FollowThePath>().waypointIndex == Bat.GetComponent<FollowThePath>().waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isBunnyPlaying) {
            if (Bunny.GetComponent<FollowThePath>().iterator > diceSideThrown) {
                Bunny.GetComponent<FollowThePath>().iterator = 1;
                Bunny.GetComponent<FollowThePath>().moveAllowed = false;
                Dice.playerIsMoving = false;
                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                BunnyStartWaypoint = Bunny.GetComponent<FollowThePath>().waypointIndex - 1;
            }
            
            if (Bunny.GetComponent<FollowThePath>().waypointIndex == Bunny.GetComponent<FollowThePath>().waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isDuckPlaying) {
            if (Duck.GetComponent<FollowThePath>().iterator > diceSideThrown) {
                Duck.GetComponent<FollowThePath>().iterator = 1;
                Duck.GetComponent<FollowThePath>().moveAllowed = false;
                Dice.playerIsMoving = false;
                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                DuckStartWaypoint = Duck.GetComponent<FollowThePath>().waypointIndex - 1;
            }
            
            if (Duck.GetComponent<FollowThePath>().waypointIndex == Duck.GetComponent<FollowThePath>().waypoints.Length) {
                //whoWinsTextShadow.gameObject.SetActive(true);
                //whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
                gameOver = true;
            }
        }
        
        if (isChickenPlaying) {
            if (Chicken.GetComponent<FollowThePath>().iterator > diceSideThrown) {
                Chicken.GetComponent<FollowThePath>().iterator = 1;
                Chicken.GetComponent<FollowThePath>().moveAllowed = false;
                Dice.playerIsMoving = false;
                //player1MoveText.gameObject.SetActive(false);
                //player2MoveText.gameObject.SetActive(true);
                ChickenStartWaypoint = Chicken.GetComponent<FollowThePath>().waypointIndex - 1;
            }
            
            if (Chicken.GetComponent<FollowThePath>().waypointIndex == Chicken.GetComponent<FollowThePath>().waypoints.Length) {
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
                Bat.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                Bunny.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            
            case 3:
                Duck.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            
            case 4:
                Chicken.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            
        }
    }
}
