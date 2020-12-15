using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    
    public static Player Bat, Bunny, Duck, Chicken;
    private bool AIBat, AIBunny, AIDuck, AIChicken;
    public static bool isBatPlaying, isBunnyPlaying, isDuckPlaying, isChickenPlaying;
    
    public static List<string> charactersPlaying = new List<string>();
    
    public static int diceSideThrown = 10;

    public static bool gameOver = false;
    
    private Images images;

    // Use this for initialization
    void Start () {
        
        LoadPreSettings();
        
        images = GameObject.Find("Images").GetComponent<Images>();

        if (isBatPlaying) {
            Bat = GameObject.Find("Bat").GetComponent<Player>();
            Bat.AIPlayer = AIBat;
            charactersPlaying.Add("Bat");
        }
        else Destroy(GameObject.Find("Bat"));

        if (isBunnyPlaying) {
            Bunny = GameObject.Find("Bunny").GetComponent<Player>();
            Bunny.AIPlayer = AIBunny;
            charactersPlaying.Add("Bunny");
        }
        else Destroy(GameObject.Find("Bunny"));

        if (isDuckPlaying) {
            Duck = GameObject.Find("Duck").GetComponent<Player>();
            Duck.AIPlayer = AIDuck;
            charactersPlaying.Add("Duck");
        }
        else Destroy(GameObject.Find("Duck"));

        if (isChickenPlaying) {
            Chicken = GameObject.Find("Chicken").GetComponent<Player>();
            Chicken.AIPlayer = AIChicken;
            charactersPlaying.Add("Chicken");
        }
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
    }

    private void LoadPreSettings() {
        
        PreSettings preSettings = new PreSettings();

        isBatPlaying = preSettings.IsBatPlaying;
        isBunnyPlaying = preSettings.IsBunnyPlaying;
        isDuckPlaying = preSettings.IsDuckPlaying;
        isChickenPlaying = preSettings.IsChickenPlaying;
        
        AIBat = preSettings.IsAIBat;
        AIBunny = preSettings.IsAIBunny;
        AIDuck = preSettings.IsAIDuck;
        AIChicken = preSettings.IsAIChicken;
    }

    // Update is called once per frame
    private void Update() {

        if (isBatPlaying) {
            if (Bat.iterator >= diceSideThrown) {
                if (Bat.transform.position == Bat.waypoints[Bat.waypointIndex].transform.position) {
                    Bat.iterator = 0;
                    Bat.moveAllowed = false;
                    Dice.playerIsMoving = false;
                    images.SetWhosTurnImage(Dice.whosTurn);
                    Bat.DiceRolled = false;
                    
                    if(isBunnyPlaying) Bunny.refreshEq = true;
                    else if(isDuckPlaying) Duck.refreshEq = true;
                    else if(isChickenPlaying) Chicken.refreshEq = true;
                }
            }
            
            if (Bat.waypointIndex == Bat.waypoints.Length) {
                gameOver = true;
            }
        }
        
        if (isBunnyPlaying) {
            if (Bunny.iterator >= diceSideThrown) {
                if (Bunny.transform.position == Bunny.waypoints[Bunny.waypointIndex].transform.position) {
                    Bunny.iterator = 0;
                    Bunny.moveAllowed = false;
                    Dice.playerIsMoving = false;
                    images.SetWhosTurnImage(Dice.whosTurn);
                    Bunny.DiceRolled = false;

                    if (isDuckPlaying) Duck.refreshEq = true;
                    else if (isChickenPlaying) Chicken.refreshEq = true;
                    else if (isBatPlaying) Bat.refreshEq = true;
                }
            }
            
            if (Bunny.waypointIndex == Bunny.waypoints.Length) {
                gameOver = true;
            }
        }
        
        if (isDuckPlaying) {
            if (Duck.iterator >= diceSideThrown) {
                if (Duck.transform.position == Duck.waypoints[Duck.waypointIndex].transform.position) {
                    Duck.iterator = 0;
                    Duck.moveAllowed = false;
                    Dice.playerIsMoving = false;
                    images.SetWhosTurnImage(Dice.whosTurn);
                    Duck.DiceRolled = false;

                    if (isChickenPlaying) Chicken.refreshEq = true;
                    else if (isBatPlaying) Bat.refreshEq = true;
                    else if (isBunnyPlaying) Bunny.refreshEq = true;
                }
            }
            
            if (Duck.waypointIndex == Duck.waypoints.Length) {
                gameOver = true;
            }
        }
        
        if (isChickenPlaying) {
            if (Chicken.iterator >= diceSideThrown) {
                if (Chicken.transform.position == Chicken.waypoints[Chicken.waypointIndex].transform.position) {
                    Chicken.iterator = 0;
                    Chicken.moveAllowed = false;
                    Dice.playerIsMoving = false;
                    images.SetWhosTurnImage(Dice.whosTurn);
                    Chicken.DiceRolled = false;

                    if (isBatPlaying) Bat.refreshEq = true;
                    else if (isBunnyPlaying) Bunny.refreshEq = true;
                    else if (isDuckPlaying) Duck.refreshEq = true;
                }
            }
            
            if (Chicken.waypointIndex == Chicken.waypoints.Length) {
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
