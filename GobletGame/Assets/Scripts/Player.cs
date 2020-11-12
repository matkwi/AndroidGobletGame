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
    public int waypointIndex;

    [HideInInspector] 
    public int iterator;

    public bool moveAllowed;

    private string arrowDirection;

    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    private Equipment equipment;
    public bool refreshEq = true;
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
    
    private GameObject Dice;
    private Images images;

    // Use this for initialization
	private void Start () {
        stopForChest = false;
        moveAllowed = false;
        waypointIndex = 0;
        iterator = 0;
        transform.position = waypoints[waypointIndex].transform.position;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        equipment = new Equipment();
        equipment.AddKey(30);
        Dice = GameObject.Find("Dice");
        images = GameObject.Find("Images").GetComponent<Images>();
    }
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
        }

        if (myTurn == Dice.GetComponent<Dice>().whosTurn && Input.GetMouseButtonDown(0)) {
            if (!isWeaponChosen && !attackDone) chooseWeapon();
            if (isWeaponChosen) Attack();
        }

        if (refreshEq) {
            equipment.refreshEquipment();
            refreshEq = false;
            attackDone = false;
        }

        if (moveAllowed)
            Move();
        
        if (Input.GetKeyDown(KeyCode.Space) && moveAllowed) {
            //TakeDamage(2);
            equipment.AddBomb();
            //GameControl.Bunny.GetComponent<FollowThePath>().TakeDamage(2);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && moveAllowed) {
            //TakeDamage(2);
            equipment.DeleteBomb();
            //GameControl.Bunny.GetComponent<FollowThePath>().TakeDamage(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && moveAllowed) {
            equipment.refreshEquipment();
            foreach (Item item in equipment.getBombs()) {
                Debug.Log(item.itemType);
            }
        }
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
            Chest chest = GameObject.Find("Chest").GetComponent<Chest>();
            Chest.changePosition = true;
            stopForChest = false;
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    
    void GiveHealth(int healthAmount) {
        currentHealth += healthAmount;
        if (currentHealth > 10) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            setArrowDirection(hit.collider.gameObject.name);
        }
    }    
    
    private void chooseWeapon() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            string weapon = hit.collider.gameObject.name;
            if (weapon.Equals(BOMB) && equipment.getBombsCount() > 0) {
                images.SetBombSelected(true);
                weaponChosen = BOMB;
                isWeaponChosen = true;
            }
            else if (weapon.Equals(GUN) && equipment.getGunsCount() > 0) {
                images.SetGunSelected(true);
                weaponChosen = GUN;
                isWeaponChosen = true;
            }
            else if (weapon.Equals(MEDKIT) && equipment.getMedKitsCount() > 0) {
                images.SetMedKitSelected(true);
                weaponChosen = MEDKIT;
                isWeaponChosen = true;
            }
        }
    }
    
    private void Attack() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            string player = hit.collider.gameObject.name;
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
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1) {
            if (transform.position == waypoints[waypointIndex].transform.position && !stopForChest) {
                if (transform.position == waypoints[0].transform.position) {
                    waypointIndex += 0;
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
    
}
