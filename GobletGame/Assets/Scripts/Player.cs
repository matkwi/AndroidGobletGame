using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Player : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector] 
    public bool AIPlayer;

    [HideInInspector] 
    public bool DiceRolled;

    [HideInInspector]
    public int waypointIndex;

    [HideInInspector] 
    public int iterator;

    [HideInInspector]
    public bool moveAllowed;

    private string arrowDirection;

    [HideInInspector]
    public int maxHealth = 10;
    [HideInInspector]
    public int currentHealth;

    public HealthBar healthBar;
    private Equipment equipment;
    [HideInInspector]
    public bool refreshEq = true;
    [HideInInspector]
    public int myTurn;
    private bool isWeaponChosen = false;
    private string weaponChosen = "";
    private string BOMB = "Bomb";
    private string GUN = "Gun";
    private string MEDKIT = "MedKit";
    private string KEY = "Key";
    private string NONE = "";
    private static bool attackDone = false;
    private bool stopForChest;
    
    private Dice Dice;
    private Images images;

    // Use this for initialization
	private void Start () {
        DiceRolled = false;
        stopForChest = false;
        moveAllowed = false;
        waypointIndex = 0;
        iterator = 0;
        transform.position = waypoints[waypointIndex].transform.position;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        equipment = new Equipment(gameObject.name);
        equipment.AddKey(30);
        Dice = GameObject.Find("Dice").GetComponent<Dice>();
        images = GameObject.Find("Images").GetComponent<Images>();
    }
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0) && !AIPlayer) {
            ArrowClicked();
        }

        if (myTurn == Dice.whosTurn && Input.GetMouseButtonDown(0) && !AIPlayer) {
            if (!attackDone) chooseWeaponPlayer();
            if (isWeaponChosen) AttackPlayer();
        }

        if (refreshEq) {
            equipment.refreshEquipment();
            refreshEq = false;
            attackDone = false;
        }

        if (AIPlayer && myTurn == Dice.whosTurn && !DiceRolled && !Dice.playerIsMoving) {
            if (!attackDone) {
                if (currentHealth < 7) {
                    chooseWeapon(MEDKIT);
                    if (isWeaponChosen) Attack(gameObject.name);
                }
                else if (equipment.getGunsCount() > 0) {
                    chooseWeapon(GUN);
                    Random random = new Random();
                    List<string> characters = GameControl.charactersPlaying;
                    characters.Remove(gameObject.name);
                    int x = random.Next(0, characters.Count);
                    if (isWeaponChosen) Attack(characters[x]);
                }
                else if (equipment.getBombsCount() > 0) {
                    chooseWeapon(BOMB);
                    Random random = new Random();
                    List<string> characters = GameControl.charactersPlaying;
                    characters.Remove(gameObject.name);
                    int x = random.Next(0, characters.Count);
                    if (isWeaponChosen) Attack(characters[x]);
                }
            }

            Dice.AIPlayerDiceRoll = true;
            DiceRolled = true;
        }

        if (moveAllowed)
            Move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bomb") && iterator == GameControl.diceSideThrown) {
            equipment.AddBomb();
        }
        else if (other.CompareTag("Gun") && iterator == GameControl.diceSideThrown) {
            equipment.AddGun();
        }
        else if (other.CompareTag("MedKit") && iterator == GameControl.diceSideThrown) {
            equipment.AddMedKit();
        }
        else if (other.CompareTag("Key") && iterator == GameControl.diceSideThrown) {
            Random random = new Random();
            equipment.AddKey(random.Next(8, 13));
        }
        else if (other.CompareTag("Chest")) {
            stopForChest = true;
            if (equipment.getKeysCount() >= 40) {
                equipment.DeleteKey(40);
                equipment.AddGoblet();
                Chest chest = GameObject.Find("Chest").GetComponent<Chest>();
                chest.changePosition = true;
            }
            stopForChest = false;
        }
    }

    private void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    
    private void GiveHealth(int healthAmount) {
        currentHealth += healthAmount;
        if (currentHealth > 10) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void ArrowClicked() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            setArrowDirection(hit.collider.gameObject.name);
        }
    }    
    
    private void chooseWeapon(string weapon) {
        if (weapon.Equals(BOMB) && equipment.getBombsCount() > 0) {
                images.SetBombSelected(true);
                images.SetGunSelected(false);
                images.SetMedKitSelected(false);
                weaponChosen = BOMB;
                isWeaponChosen = true;
        }
        else if (weapon.Equals(GUN) && equipment.getGunsCount() > 0) {
            images.SetGunSelected(true);
            images.SetBombSelected(false);
            images.SetMedKitSelected(false);
            weaponChosen = GUN;
            isWeaponChosen = true;
        }
        else if (weapon.Equals(MEDKIT) && equipment.getMedKitsCount() > 0) {
            images.SetMedKitSelected(true);
            images.SetGunSelected(false);
            images.SetBombSelected(false);
            weaponChosen = MEDKIT;
            isWeaponChosen = true;
        }
        
    }

    private void chooseWeaponPlayer() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            string weapon = hit.collider.gameObject.name;
            chooseWeapon(weapon);
        }
    }

    private void Attack(string player) {
        if (weaponChosen.Equals(BOMB)) {
                if (player.Equals("Bat") && myTurn != 1) {
                    GameControl.Bat.GetComponent<Player>().TakeDamage(4);
                    equipment.DeleteBomb();
                    equipment.setBombAmount(equipment.getBombsCount());
                    isWeaponChosen = false;
                    weaponChosen = NONE;
                    attackDone = true;
                    images.SetBombSelected(false);
                }
                else if (player.Equals("Bunny") && myTurn != 2) {
                    GameControl.Bunny.GetComponent<Player>().TakeDamage(4);
                    equipment.DeleteBomb();
                    equipment.setBombAmount(equipment.getBombsCount());
                    isWeaponChosen = false;
                    weaponChosen = NONE;
                    attackDone = true;
                    images.SetBombSelected(false);
                }
                else if (player.Equals("Duck") && myTurn != 3) {
                    GameControl.Duck.GetComponent<Player>().TakeDamage(4);
                    equipment.DeleteBomb();
                    equipment.setBombAmount(equipment.getBombsCount());
                    isWeaponChosen = false;
                    weaponChosen = NONE;
                    attackDone = true;
                    images.SetBombSelected(false);
                }
                else if (player.Equals("Chicken") && myTurn != 4) {
                    GameControl.Chicken.GetComponent<Player>().TakeDamage(4);
                    equipment.DeleteBomb();
                    equipment.setBombAmount(equipment.getBombsCount());
                    isWeaponChosen = false;
                    weaponChosen = NONE;
                    attackDone = true;
                    images.SetBombSelected(false);
                }
        }
        else if (weaponChosen.Equals(GUN)) {
            if (player.Equals("Bat") && myTurn != 1) {
                GameControl.Bat.GetComponent<Player>().TakeDamage(6);
                equipment.DeleteGun();
                equipment.setGunAmount(equipment.getGunsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetGunSelected(false);
            }
            else if (player.Equals("Bunny") && myTurn != 2) {
                GameControl.Bunny.GetComponent<Player>().TakeDamage(6);
                equipment.DeleteGun();
                equipment.setGunAmount(equipment.getGunsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetGunSelected(false);
            }
            else if (player.Equals("Duck") && myTurn != 3) {
                GameControl.Duck.GetComponent<Player>().TakeDamage(6);
                equipment.DeleteGun();
                equipment.setGunAmount(equipment.getGunsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetGunSelected(false);
            }
            else if (player.Equals("Chicken") && myTurn != 4) {
                GameControl.Chicken.GetComponent<Player>().TakeDamage(6);
                equipment.DeleteGun();
                equipment.setGunAmount(equipment.getGunsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetGunSelected(false);
            }
        }
        else if (weaponChosen.Equals(MEDKIT)) {
            if (player.Equals("Bat")) {
                GameControl.Bat.GetComponent<Player>().GiveHealth(5);
                equipment.DeleteMedKit();
                equipment.setMedKitAmount(equipment.getMedKitsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetMedKitSelected(false);
            }
            else if (player.Equals("Bunny")) {
                GameControl.Bunny.GetComponent<Player>().GiveHealth(5);
                equipment.DeleteMedKit();
                equipment.setMedKitAmount(equipment.getMedKitsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetMedKitSelected(false);
            }
            else if (player.Equals("Duck")) {
                GameControl.Duck.GetComponent<Player>().GiveHealth(5);
                equipment.DeleteMedKit();
                equipment.setMedKitAmount(equipment.getMedKitsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetMedKitSelected(false);
            }
            else if (player.Equals("Chicken")) {
                GameControl.Chicken.GetComponent<Player>().GiveHealth(5);
                equipment.DeleteMedKit();
                equipment.setMedKitAmount(equipment.getMedKitsCount());
                isWeaponChosen = false;
                weaponChosen = NONE;
                attackDone = true;
                images.SetMedKitSelected(false);
            }
        }
    }

    private void AttackPlayer() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            string player = hit.collider.gameObject.name;
            Attack(player);
        }
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1) {
            if (transform.position == waypoints[waypointIndex].transform.position && !stopForChest) {
                if (transform.position == waypoints[0].transform.position) {
                    waypointIndex += 0;
                    if (AIPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowDown1", "ArrowRight1"});
                    }
                    if (arrowDirection.Equals("ArrowDown1")) {
                        waypointIndex += 57;
                        iterator += 1;
                    }

                    if (arrowDirection.Equals("ArrowRight1")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[57].transform.position) {
                    waypointIndex -= 26;
                    iterator += 1;
                }
                else if (transform.position == waypoints[19].transform.position) {
                    waypointIndex += 0;
                    if (AIPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowDown2", "ArrowUp1"});
                    }
                    if (arrowDirection.Equals("ArrowDown2")) {
                        waypointIndex = 58;
                        iterator += 1;
                    }

                    if (arrowDirection.Equals("ArrowUp1")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[66].transform.position) {
                    waypointIndex = 19;
                    iterator += 1;
                }
                else if (transform.position == waypoints[37].transform.position) {
                    waypointIndex += 0;
                    if (AIPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowDown3", "ArrowLeft1"});
                    }
                    if (arrowDirection.Equals("ArrowDown3")) {
                        waypointIndex = 67;
                        iterator += 1;
                    }

                    if (arrowDirection.Equals("ArrowLeft1")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[75].transform.position) {
                    waypointIndex = 43;
                    iterator += 1;
                }
                else if (transform.position == waypoints[45].transform.position) {
                    waypointIndex += 0;
                    if (AIPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowRight2", "ArrowUp2"});
                    }
                    if (arrowDirection.Equals("ArrowRight2")) {
                        waypointIndex = 76;
                        iterator += 1;
                    }

                    if (arrowDirection.Equals("ArrowUp2")) {
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[79].transform.position) {
                    waypointIndex = 50;
                    iterator += 1;
                }
                else if (transform.position == waypoints[56].transform.position) {
                    waypointIndex = 0;
                    iterator += 1;
                }
                else {
                    waypointIndex += 1;
                    iterator += 1;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, 
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);
        }
    }

    private void setArrowDirection(string direction) {
        arrowDirection = direction;
    }

    private void SetRandomArrowDirection(List<string> directions) {
        Random random = new Random();
        int x = random.Next(0, 2);
        setArrowDirection(directions[x]);
    }
    
}
