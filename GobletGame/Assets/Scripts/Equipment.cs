using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Equipment {

    private List<Item> _bombs;
    private List<Item> _guns;
    private List<Item> _medKits;
    private List<Item> _keys;
    private List<Item> _goblets;

    private TextMeshProUGUI _bombAmount;
    private TextMeshProUGUI _gunAmount;
    private TextMeshProUGUI _medkitAmount;
    private TextMeshProUGUI _keyAmount;
    private TextMeshProUGUI _gobletAmount;

    public Equipment(string name) {
        _bombs = new List<Item>();
        _guns = new List<Item>();
        _medKits = new List<Item>();
        _keys = new List<Item>();
        _goblets = new List<Item>();
        
        _bombAmount = GameObject.Find("bombAmount").GetComponent<TextMeshProUGUI>();
        _gunAmount = GameObject.Find("gunAmount").GetComponent<TextMeshProUGUI>();
        _medkitAmount = GameObject.Find("medkitAmount").GetComponent<TextMeshProUGUI>();
        _keyAmount = GameObject.Find("keyAmount").GetComponent<TextMeshProUGUI>();
        _gobletAmount = GameObject.Find(name + "GobletAmount").GetComponent<TextMeshProUGUI>();
    }

    public void AddBomb() {
        _bombs.Add(new Item { itemType = Item.ItemType.Bomb });
        _bombAmount.SetText(_bombs.Count.ToString());
    }
    
    public void AddGun() {
        _guns.Add(new Item { itemType = Item.ItemType.Gun });
        _gunAmount.SetText(_guns.Count.ToString());
    }
    
    public void AddMedKit() {
        _medKits.Add(new Item { itemType = Item.ItemType.MedKit });
        _medkitAmount.SetText(_medKits.Count.ToString());
    }
    
    public void AddKey(int amount) {
        for (int i = 0; i < amount; i++) {
            _keys.Add(new Item { itemType = Item.ItemType.Key });
        }
        _keyAmount.SetText(_keys.Count.ToString());
    }
    
    public void AddGoblet() {
        _goblets.Add(new Item { itemType = Item.ItemType.Goblet });
        _gobletAmount.SetText(_goblets.Count.ToString());
    }

    public void DeleteBomb() {
        _bombs.RemoveAt(GETBombsCount() - 1);
        _bombAmount.SetText(_bombs.Count.ToString());
    }
    
    public void DeleteGun() {
        _guns.RemoveAt(GETGunsCount() - 1);
        _gunAmount.SetText(_guns.Count.ToString());
    }
    
    public void DeleteMedKit() {
        _medKits.RemoveAt(GETMedKitsCount() - 1);
        _medkitAmount.SetText(_medKits.Count.ToString());
    }
    
    public void DeleteGoblet() {
        _goblets.RemoveAt(GETGobletsCount() - 1);
        _gobletAmount.SetText(_goblets.Count.ToString());
    }
    
    public void DeleteKey(int amount) {
        for (int i = 0; i < amount; i++) {
            if (GETKeysCount().Equals(0)) break;
            _keys.RemoveAt(GETKeysCount() - 1);
        }
        _keyAmount.SetText(_keys.Count.ToString());
    }

    public List<Item> GETBombs() {
        return _bombs;
    }
    
    public List<Item> GETGuns() {
        return _guns;
    }
    
    public List<Item> GETMedKits() {
        return _medKits;
    }
    
    public List<Item> GETKeys() {
        return _keys;
    }
    
    public List<Item> GETGoblets() {
        return _goblets;
    }

    public int GETBombsCount() {
        return _bombs.Count;
    }
    
    public int GETGunsCount() {
        return _guns.Count;
    }
    
    public int GETMedKitsCount() {
        return _medKits.Count;
    }
    
    public int GETKeysCount() {
        return _keys.Count;
    }
    
    public int GETGobletsCount() {
        return _goblets.Count;
    }

    public void SetBombAmount(int number) {
        _bombAmount.SetText(number.ToString());
    }
    
    public void SetGunAmount(int number) {
        _gunAmount.SetText(number.ToString());
    }
    
    public void SetMedKitAmount(int number) {
        _medkitAmount.SetText(number.ToString());
    }
    
    public void SetKeyAmount(int number) {
        _keyAmount.SetText(number.ToString());
    }
    
    public void SetGobletAmount(int number) {
        _gobletAmount.SetText(number.ToString());
    }

    public void RefreshEquipment() {
        _bombAmount.SetText(_bombs.Count.ToString());
        _gunAmount.SetText(_guns.Count.ToString());
        _medkitAmount.SetText(_medKits.Count.ToString());
        _keyAmount.SetText(_keys.Count.ToString());
    }
}
