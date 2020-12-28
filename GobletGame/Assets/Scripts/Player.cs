using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class Player : MonoBehaviour {

    public Transform[] waypoints;

    private float _moveSpeed;

    [HideInInspector] 
    public bool aiPlayer;

    [HideInInspector] 
    public bool diceRolled;

    [HideInInspector]
    public int waypointIndex;

    [HideInInspector] 
    public int iterator;

    [HideInInspector]
    public bool moveAllowed;

    private string _arrowDirection;

    [HideInInspector]
    public int maxHealth = 10;
    
    [HideInInspector]
    public int currentHealth;

    public HealthBar healthBar;
    private Equipment _equipment;
    
    [HideInInspector]
    public bool refreshEq = false;
    
    [HideInInspector]
    public int myTurn;

    private bool _isWeaponChosen;
    private string _weaponChosen = "";
    private const string Bomb = "Bomb";
    private const string Gun = "Gun";
    private const string Medkit = "MedKit";
    private const string Key = "Key";
    private const string None = "";
    private static bool _attackDone;
    private bool _stopForChest;
    
    private Dice _dice;
    private Images _images;
    private SoundManager _soundManager;

    private TextMeshProUGUI _chooseDirection;
    
    // Use this for initialization
	private void Start () {
        diceRolled = false;
        _stopForChest = false;
        moveAllowed = false;
        refreshEq = false;
        _attackDone = false;
        _isWeaponChosen = false;
        _moveSpeed = 5f;
        waypointIndex = 0;
        iterator = 0;
        transform.position = waypoints[waypointIndex].transform.position;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _equipment = new Equipment(gameObject.name);
        _equipment.AddKey(30);
        _dice = GameObject.Find("Dice").GetComponent<Dice>();
        _images = GameObject.Find("Images").GetComponent<Images>();
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _chooseDirection = GameObject.Find("ChooseDirection").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
	private void Update () {
        
        if (Input.GetMouseButtonDown(0) && !aiPlayer) {
            ArrowClicked();
        }

        if (myTurn == Dice.WhosTurn && Input.GetMouseButtonDown(0) && !aiPlayer) {
            if (!_attackDone) ChooseWeaponPlayer();
            if (_isWeaponChosen) AttackPlayer();
        }

        if (refreshEq) {
            refreshEq = false;
            _attackDone = false;
            _equipment.RefreshEquipment();
        }

        if (aiPlayer && myTurn == Dice.WhosTurn && !diceRolled && !Dice.PlayerIsMoving) {
            AIPlayerMove();
        }

        if (moveAllowed)
            Move();
    }
    
    private void WaitForAnimation(ParticleSystem animation, string animationType) {
        if (animationType.Equals("explosion")) StartCoroutine(WaitForExplosion(animation));
        else if (animationType.Equals("goblet")) StartCoroutine(WaitForChest(animation));
    }

    private IEnumerator WaitForExplosion(ParticleSystem animation) {
        do {
            yield return null;
        } while ( animation.isPlaying );
        currentHealth = maxHealth;
        int[] tab = {0, 19, 37, 45};
        Random random = new Random();
        int x = random.Next(0, tab.Length);
        waypointIndex = tab[x];
        transform.position = waypoints[waypointIndex].transform.position;
        healthBar.SetHealth(currentHealth);
    }
    
    private IEnumerator WaitForChest(ParticleSystem animation) {
        do {
            yield return null;
        } while ( animation.isPlaying );
        _equipment.DeleteKey(40);
        _equipment.AddGoblet();
        _soundManager.PlayCollectSound();
        Chest chest = GameObject.Find("Chest").GetComponent<Chest>();
        chest.changePosition = true;
        if (_equipment.GETGobletsCount() == 4) {
            WhoWon whoWon = new WhoWon();
            whoWon.Winner = gameObject.name;
            GameControl.GameOver = true;
        }
        else _stopForChest = false;
    }

    private void AIPlayerMove() {
        if (!_attackDone) {
            if (currentHealth < 7 && _equipment.GETMedKitsCount() > 0) {
                ChooseWeapon(Medkit);
                if (_isWeaponChosen) Attack(gameObject.name);
            }
            else if (_equipment.GETGunsCount() > 0) {
                ChooseWeapon(Gun);
                Random random = new Random();
                List<string> characters = new List<string>();
                foreach (string c in GameControl.CharactersPlaying) {
                    characters.Add(c);
                }
                characters.Remove(gameObject.name);
                int x = random.Next(0, characters.Count);
                if (_isWeaponChosen) {
                    Attack(characters[x]);
                }
            }
            else if (_equipment.GETBombsCount() > 0) {
                ChooseWeapon(Bomb);
                Random random = new Random();
                List<string> characters = new List<string>();
                foreach (string c in GameControl.CharactersPlaying) {
                    characters.Add(c);
                }
                characters.Remove(gameObject.name);
                int x = random.Next(0, characters.Count);
                if (_isWeaponChosen) {
                    Attack(characters[x]);
                }
            }
        }

        _dice.aiPlayerDiceRoll = true;
        diceRolled = true;
    }

    private void Animation(string animationObject) {
        ParticleSystem gobletAnimation = GameObject.Find(animationObject + gameObject.name).GetComponent<ParticleSystem>();
        if(!gobletAnimation.isPlaying) gobletAnimation.Play();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bomb") && iterator == GameControl.DiceSideThrown) {
            Animation("BombAnimation");
            _equipment.AddBomb();
            _soundManager.PlayCollectSound();
        }
        else if (other.CompareTag("Gun") && iterator == GameControl.DiceSideThrown) {
            Animation("GunAnimation");
            _equipment.AddGun();
            _soundManager.PlayCollectSound();
        }
        else if (other.CompareTag("MedKit") && iterator == GameControl.DiceSideThrown) {
            Animation("MedKitAnimation");
            _equipment.AddMedKit();
            _soundManager.PlayCollectSound();
        }
        else if (other.CompareTag("Key") && iterator == GameControl.DiceSideThrown) {
            Animation("KeyAnimation");
            Random random = new Random();
            _equipment.AddKey(random.Next(8, 13));
            _soundManager.PlayCollectSound();
        }
        else if (other.CompareTag("Chest")) {
            _stopForChest = true;
            if (_equipment.GETKeysCount() >= 40) {
                ParticleSystem gobletAnimation = AnimateGoblet();
                WaitForAnimation(gobletAnimation, "goblet");
            }
            else _stopForChest = false;
        }
    }

    private void TakeDamage(int damage, ParticleSystem animation, string name) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Player player = GameObject.Find(name).GetComponent<Player>();
            player._equipment.AddKey(5);
            WaitForAnimation(animation, "explosion");
        }
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
            SetArrowDirection(hit.collider.gameObject.name);
        }
    }    
    
    private void ChooseWeapon(string weapon) {
        if (weapon.Equals(Bomb) && _equipment.GETBombsCount() > 0) {
                _images.SetBombSelected(true);
                _images.SetGunSelected(false);
                _images.SetMedKitSelected(false);
                _weaponChosen = Bomb;
                _isWeaponChosen = true;
        }
        else if (weapon.Equals(Gun) && _equipment.GETGunsCount() > 0) {
            _images.SetGunSelected(true);
            _images.SetBombSelected(false);
            _images.SetMedKitSelected(false);
            _weaponChosen = Gun;
            _isWeaponChosen = true;
        }
        else if (weapon.Equals(Medkit) && _equipment.GETMedKitsCount() > 0) {
            _images.SetMedKitSelected(true);
            _images.SetGunSelected(false);
            _images.SetBombSelected(false);
            _weaponChosen = Medkit;
            _isWeaponChosen = true;
        }
        
    }

    private void ChooseWeaponPlayer() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit) {
            string weapon = hit.collider.gameObject.name;
            ChooseWeapon(weapon);
        }
    }

    private ParticleSystem AnimateExplosion(string player) {
        ParticleSystem explosionAnimation = GameObject.Find("Explosion" + player).GetComponent<ParticleSystem>();
        if(!explosionAnimation.isPlaying) explosionAnimation.Play();
        return explosionAnimation;
    }

    private void AnimateHealing(string player) {
        ParticleSystem healingAnimation = GameObject.Find("HealingAnimation" + player).GetComponent<ParticleSystem>();
        if(!healingAnimation.isPlaying) healingAnimation.Play();
    }
    
    private ParticleSystem AnimateGoblet() {
        ParticleSystem gobletAnimation = GameObject.Find("GobletAnimation" + gameObject.name).GetComponent<ParticleSystem>();
        if(!gobletAnimation.isPlaying) gobletAnimation.Play();
        return gobletAnimation;
    }

    private void Attack(string player) {
        if (_weaponChosen.Equals(Bomb)) {
            if (player.Equals("Bat") && myTurn != 1) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayBombSound();
                GameControl.Bat.GetComponent<Player>().TakeDamage(4, explosionAnimation, gameObject.name);
                _equipment.DeleteBomb();
                _equipment.SetBombAmount(_equipment.GETBombsCount()); 
                _isWeaponChosen = false; 
                _weaponChosen = None; 
                _attackDone = true; 
                _images.SetBombSelected(false);
            }
            else if (player.Equals("Bunny") && myTurn != 2) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayBombSound();
                GameControl.Bunny.GetComponent<Player>().TakeDamage(4, explosionAnimation, gameObject.name);
                _equipment.DeleteBomb();
                _equipment.SetBombAmount(_equipment.GETBombsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetBombSelected(false);
            }
            else if (player.Equals("Duck") && myTurn != 3) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayBombSound();
                GameControl.Duck.GetComponent<Player>().TakeDamage(4, explosionAnimation, gameObject.name);
                _equipment.DeleteBomb();
                _equipment.SetBombAmount(_equipment.GETBombsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetBombSelected(false);
            }
            else if (player.Equals("Chicken") && myTurn != 4) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayBombSound();
                GameControl.Chicken.GetComponent<Player>().TakeDamage(4, explosionAnimation, gameObject.name);
                _equipment.DeleteBomb();
                _equipment.SetBombAmount(_equipment.GETBombsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetBombSelected(false);
            }
        }
        else if (_weaponChosen.Equals(Gun)) {
            if (player.Equals("Bat") && myTurn != 1) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayGunSound();
                GameControl.Bat.GetComponent<Player>().TakeDamage(6, explosionAnimation, gameObject.name);
                _equipment.DeleteGun();
                _equipment.SetGunAmount(_equipment.GETGunsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetGunSelected(false);
            }
            else if (player.Equals("Bunny") && myTurn != 2) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayGunSound();
                GameControl.Bunny.GetComponent<Player>().TakeDamage(6, explosionAnimation, gameObject.name);
                _equipment.DeleteGun();
                _equipment.SetGunAmount(_equipment.GETGunsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetGunSelected(false);
            }
            else if (player.Equals("Duck") && myTurn != 3) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayGunSound();
                GameControl.Duck.GetComponent<Player>().TakeDamage(6, explosionAnimation, gameObject.name);
                _equipment.DeleteGun();
                _equipment.SetGunAmount(_equipment.GETGunsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetGunSelected(false);
            }
            else if (player.Equals("Chicken") && myTurn != 4) {
                ParticleSystem explosionAnimation = AnimateExplosion(player);
                _soundManager.PlayGunSound();
                GameControl.Chicken.GetComponent<Player>().TakeDamage(6, explosionAnimation, gameObject.name);
                _equipment.DeleteGun();
                _equipment.SetGunAmount(_equipment.GETGunsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetGunSelected(false);
            }
        }
        else if (_weaponChosen.Equals(Medkit)) {
            if (player.Equals("Bat")) {
                GameControl.Bat.GetComponent<Player>().GiveHealth(5);
                _soundManager.PlayMedKitSound();
                _equipment.DeleteMedKit();
                _equipment.SetMedKitAmount(_equipment.GETMedKitsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetMedKitSelected(false);
                AnimateHealing(player);
            }
            else if (player.Equals("Bunny")) {
                GameControl.Bunny.GetComponent<Player>().GiveHealth(5);
                _soundManager.PlayMedKitSound();
                _equipment.DeleteMedKit();
                _equipment.SetMedKitAmount(_equipment.GETMedKitsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetMedKitSelected(false);
                AnimateHealing(player);
            }
            else if (player.Equals("Duck")) {
                GameControl.Duck.GetComponent<Player>().GiveHealth(5);
                _soundManager.PlayMedKitSound();
                _equipment.DeleteMedKit();
                _equipment.SetMedKitAmount(_equipment.GETMedKitsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetMedKitSelected(false);
                AnimateHealing(player);
            }
            else if (player.Equals("Chicken")) {
                GameControl.Chicken.GetComponent<Player>().GiveHealth(5);
                _soundManager.PlayMedKitSound();
                _equipment.DeleteMedKit();
                _equipment.SetMedKitAmount(_equipment.GETMedKitsCount());
                _isWeaponChosen = false;
                _weaponChosen = None;
                _attackDone = true;
                _images.SetMedKitSelected(false);
                AnimateHealing(player);
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
            if (transform.position == waypoints[waypointIndex].transform.position && !_stopForChest) {
                if (transform.position == waypoints[0].transform.position) {
                    if(_chooseDirection.text.Equals("")) _chooseDirection.SetText("Choose Direction");
                    waypointIndex += 0;
                    if (aiPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowDown1", "ArrowRight1"});
                    }
                    if (_arrowDirection.Equals("ArrowDown1")) {
                        _chooseDirection.SetText("");
                        waypointIndex += 57;
                        iterator += 1;
                    }

                    if (_arrowDirection.Equals("ArrowRight1")) {
                        _chooseDirection.SetText("");
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[57].transform.position) {
                    waypointIndex -= 26;
                    iterator += 1;
                }
                else if (transform.position == waypoints[19].transform.position) {
                    if(_chooseDirection.text.Equals("")) _chooseDirection.SetText("Choose Direction");
                    waypointIndex += 0;
                    if (aiPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowDown2", "ArrowUp1"});
                    }
                    if (_arrowDirection.Equals("ArrowDown2")) {
                        _chooseDirection.SetText("");
                        waypointIndex = 58;
                        iterator += 1;
                    }

                    if (_arrowDirection.Equals("ArrowUp1")) {
                        _chooseDirection.SetText("");
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[66].transform.position) {
                    waypointIndex = 19;
                    iterator += 1;
                }
                else if (transform.position == waypoints[37].transform.position) {
                    if(_chooseDirection.text.Equals("")) _chooseDirection.SetText("Choose Direction");
                    waypointIndex += 0;
                    if (aiPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowDown3", "ArrowLeft1"});
                    }
                    if (_arrowDirection.Equals("ArrowDown3")) {
                        _chooseDirection.SetText("");
                        waypointIndex = 67;
                        iterator += 1;
                    }

                    if (_arrowDirection.Equals("ArrowLeft1")) {
                        _chooseDirection.SetText("");
                        waypointIndex += 1;
                        iterator += 1;
                    }
                }
                else if (transform.position == waypoints[75].transform.position) {
                    waypointIndex = 43;
                    iterator += 1;
                }
                else if (transform.position == waypoints[45].transform.position) {
                    if(_chooseDirection.text.Equals("")) _chooseDirection.SetText("Choose Direction");
                    waypointIndex += 0;
                    if (aiPlayer) {
                        SetRandomArrowDirection(new List<string>{"ArrowRight2", "ArrowUp2"});
                    }
                    if (_arrowDirection.Equals("ArrowRight2")) {
                        _chooseDirection.SetText("");
                        waypointIndex = 76;
                        iterator += 1;
                    }

                    if (_arrowDirection.Equals("ArrowUp2")) {
                        _chooseDirection.SetText("");
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
                _moveSpeed * Time.deltaTime);
        }
    }

    private void SetArrowDirection(string direction) {
        _arrowDirection = direction;
    }

    private void SetRandomArrowDirection(List<string> directions) {
        Random random = new Random();
        int x = random.Next(0, 2);
        SetArrowDirection(directions[x]);
    }
    
}
