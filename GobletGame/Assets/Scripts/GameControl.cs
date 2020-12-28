using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    
    public static Player Bat, Bunny, Duck, Chicken;

    private bool _aiBat, _aiBunny, _aiDuck, _aiChicken;
    public static bool IsBatPlaying, IsBunnyPlaying, IsDuckPlaying, IsChickenPlaying;
    
    public static List<bool> WhoIsPlaying = new List<bool>();

    public static List<string> CharactersPlaying = new List<string>();
    
    public static int DiceSideThrown = 10;

    public static bool GameOver;
    
    private Images _images;

    // Use this for initialization
    void Start () {

        LoadPreSettings();
        
        CharactersPlaying.Clear();

        GameOver = false;

        _images = GameObject.Find("Images").GetComponent<Images>();

        if (IsBatPlaying) {
            Bat = GameObject.Find("Bat").GetComponent<Player>();
            Bat.aiPlayer = _aiBat;
            CharactersPlaying.Add("Bat");
        }
        else Destroy(GameObject.Find("Bat"));

        if (IsBunnyPlaying) {
            Bunny = GameObject.Find("Bunny").GetComponent<Player>();
            Bunny.aiPlayer = _aiBunny;
            CharactersPlaying.Add("Bunny");
        }
        else Destroy(GameObject.Find("Bunny"));

        if (IsDuckPlaying) {
            Duck = GameObject.Find("Duck").GetComponent<Player>();
            Duck.aiPlayer = _aiDuck;
            CharactersPlaying.Add("Duck");
        }
        else Destroy(GameObject.Find("Duck"));

        if (IsChickenPlaying) {
            Chicken = GameObject.Find("Chicken").GetComponent<Player>();
            Chicken.aiPlayer = _aiChicken;
            CharactersPlaying.Add("Chicken");
        }
        else Destroy(GameObject.Find("Chicken"));

        if (IsBatPlaying) {
            Bat.moveAllowed = false;
            Bat.myTurn = 1;
        }

        if (IsBunnyPlaying) {
            Bunny.moveAllowed = false;
            Bunny.myTurn = 2;
        }

        if (IsDuckPlaying) {
            Duck.moveAllowed = false;
            Duck.myTurn = 3;
        }

        if (IsChickenPlaying) {
            Chicken.moveAllowed = false;
            Chicken.myTurn = 4;
        }

        if (IsChickenPlaying) Dice.WhosTurn = 4;
        if (IsDuckPlaying) Dice.WhosTurn = 3;
        if (IsBunnyPlaying) Dice.WhosTurn = 2;
        if (IsBatPlaying) Dice.WhosTurn = 1;
    }

    private void LoadPreSettings() {
        
        PreSettings preSettings = new PreSettings();

        IsBatPlaying = preSettings.IsBatPlaying;
        IsBunnyPlaying = preSettings.IsBunnyPlaying;
        IsDuckPlaying = preSettings.IsDuckPlaying;
        IsChickenPlaying = preSettings.IsChickenPlaying;
        
        _aiBat = preSettings.IsAIBat;
        _aiBunny = preSettings.IsAIBunny;
        _aiDuck = preSettings.IsAIDuck;
        _aiChicken = preSettings.IsAIChicken;
        
        WhoIsPlaying.Clear();
        WhoIsPlaying.Add(false);
        WhoIsPlaying.Add(preSettings.IsBatPlaying);
        WhoIsPlaying.Add(preSettings.IsBunnyPlaying);
        WhoIsPlaying.Add(preSettings.IsDuckPlaying);
        WhoIsPlaying.Add(preSettings.IsChickenPlaying);
    }

    // Update is called once per frame
    private void Update() {

        if (IsBatPlaying) {
            if (Bat.iterator >= DiceSideThrown) {
                if (Bat.transform.position == Bat.waypoints[Bat.waypointIndex].transform.position) {
                    Bat.iterator = 0;
                    Bat.moveAllowed = false;
                    Dice.PlayerIsMoving = false;
                    Bat.diceRolled = false;

                    if (IsBunnyPlaying) {
                        _images.SetWhosTurnImage("Bunny");
                        Bunny.refreshEq = true;
                    }
                    else if (IsDuckPlaying) {
                        _images.SetWhosTurnImage("Duck");
                        Duck.refreshEq = true;
                    }
                    else if (IsChickenPlaying) {
                        _images.SetWhosTurnImage("Chicken");
                        Chicken.refreshEq = true;
                    }
                }
            }
        }
        
        if (IsBunnyPlaying) {
            if (Bunny.iterator >= DiceSideThrown) {
                if (Bunny.transform.position == Bunny.waypoints[Bunny.waypointIndex].transform.position) {
                    Bunny.iterator = 0;
                    Bunny.moveAllowed = false;
                    Dice.PlayerIsMoving = false;
                    Bunny.diceRolled = false;

                    if (IsDuckPlaying) {
                        _images.SetWhosTurnImage("Duck");
                        Duck.refreshEq = true;
                    }
                    else if (IsChickenPlaying) {
                        _images.SetWhosTurnImage("Chicken");
                        Chicken.refreshEq = true;
                    }
                    else if (IsBatPlaying) {
                        _images.SetWhosTurnImage("Bat");
                        Bat.refreshEq = true;
                    }
                }
            }
        }
        
        if (IsDuckPlaying) {
            if (Duck.iterator >= DiceSideThrown) {
                if (Duck.transform.position == Duck.waypoints[Duck.waypointIndex].transform.position) {
                    Duck.iterator = 0;
                    Duck.moveAllowed = false;
                    Dice.PlayerIsMoving = false;
                    Duck.diceRolled = false;

                    if (IsChickenPlaying) {
                        _images.SetWhosTurnImage("Chicken");
                        Chicken.refreshEq = true;
                    }
                    else if (IsBatPlaying) {
                        _images.SetWhosTurnImage("Bat");
                        Bat.refreshEq = true;
                    }
                    else if (IsBunnyPlaying) {
                        _images.SetWhosTurnImage("Bunny");
                        Bunny.refreshEq = true;
                    }
                }
            }
        }
        
        if (IsChickenPlaying) {
            if (Chicken.iterator >= DiceSideThrown) {
                if (Chicken.transform.position == Chicken.waypoints[Chicken.waypointIndex].transform.position) {
                    Chicken.iterator = 0;
                    Chicken.moveAllowed = false;
                    Dice.PlayerIsMoving = false;
                    Chicken.diceRolled = false;

                    if (IsBatPlaying) {
                        _images.SetWhosTurnImage("Bat");
                        Bat.refreshEq = true;
                    }
                    else if (IsBunnyPlaying) {
                        _images.SetWhosTurnImage("Bunny");
                        Bunny.refreshEq = true;
                    }
                    else if (IsDuckPlaying) {
                        _images.SetWhosTurnImage("Duck");
                        Duck.refreshEq = true;
                    }
                }
            }
        }
        
        if (GameOver) {
            SceneManager.LoadScene("Scenes/WinnerScene");
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
