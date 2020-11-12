using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Equipment {

    private List<Item> bombs;
    private List<Item> guns;
    private List<Item> medKits;
    private List<Item> keys;
    private List<Item> goblets;

    private TextMeshProUGUI bombAmount;
    private TextMeshProUGUI gunAmount;
    private TextMeshProUGUI medkitAmount;
    private TextMeshProUGUI keyAmount;
    private TextMeshProUGUI gobletAmount;

    public Equipment() {
        bombs = new List<Item>();
        guns = new List<Item>();
        medKits = new List<Item>();
        keys = new List<Item>();
        goblets = new List<Item>();
        
        bombAmount = GameObject.Find("bombAmount").GetComponent<TextMeshProUGUI>();
        gunAmount = GameObject.Find("gunAmount").GetComponent<TextMeshProUGUI>();
        medkitAmount = GameObject.Find("medkitAmount").GetComponent<TextMeshProUGUI>();
        keyAmount = GameObject.Find("keyAmount").GetComponent<TextMeshProUGUI>();
        //gobletAmount = GameObject.Find("gobletAmount").GetComponent<TextMeshProUGUI>();
    }

    public void AddBomb() {
        bombs.Add(new Item { itemType = Item.ItemType.Bomb });
        bombAmount.SetText(bombs.Count.ToString());
    }
    
    public void AddGun() {
        guns.Add(new Item { itemType = Item.ItemType.Gun });
        gunAmount.SetText(guns.Count.ToString());
    }
    
    public void AddMedKit() {
        medKits.Add(new Item { itemType = Item.ItemType.MedKit });
        medkitAmount.SetText(medKits.Count.ToString());
    }
    
    public void AddKey(int amount) {
        for (int i = 0; i < amount; i++) {
            keys.Add(new Item { itemType = Item.ItemType.Key });
        }
        keyAmount.SetText(keys.Count.ToString());
    }
    
    public void AddGoblet() {
        goblets.Add(new Item { itemType = Item.ItemType.Goblet });
        gobletAmount.SetText(goblets.Count.ToString());
    }

    public void DeleteBomb() {
        bombs.RemoveAt(getBombsCount() - 1);
        bombAmount.SetText(bombs.Count.ToString());
    }
    
    public void DeleteGun() {
        guns.RemoveAt(getGunsCount() - 1);
        gunAmount.SetText(guns.Count.ToString());
    }
    
    public void DeleteMedKit() {
        medKits.RemoveAt(getMedKitsCount() - 1);
        medkitAmount.SetText(medKits.Count.ToString());
    }
    
    public void DeleteGoblet() {
        goblets.RemoveAt(getGobletsCount() - 1);
        gobletAmount.SetText(goblets.Count.ToString());
    }
    
    public void DeleteKey(int amount) {
        for (int i = 0; i < amount; i++) {
            if (getKeysCount().Equals(0)) break;
            keys.RemoveAt(getKeysCount() - 1);
        }
        keyAmount.SetText(keys.Count.ToString());
    }

    public List<Item> getBombs() {
        return bombs;
    }
    
    public List<Item> getGuns() {
        return guns;
    }
    
    public List<Item> getMedKits() {
        return medKits;
    }
    
    public List<Item> getKeys() {
        return keys;
    }
    
    public List<Item> getGoblets() {
        return goblets;
    }

    public int getBombsCount() {
        return bombs.Count;
    }
    
    public int getGunsCount() {
        return guns.Count;
    }
    
    public int getMedKitsCount() {
        return medKits.Count;
    }
    
    public int getKeysCount() {
        return keys.Count;
    }
    
    public int getGobletsCount() {
        return goblets.Count;
    }

    public void setBombAmount(int number) {
        bombAmount.SetText(number.ToString());
    }
    
    public void setGunAmount(int number) {
        gunAmount.SetText(number.ToString());
    }
    
    public void setMedKitAmount(int number) {
        medkitAmount.SetText(number.ToString());
    }
    
    public void setKeyAmount(int number) {
        keyAmount.SetText(number.ToString());
    }
    
    public void setGobletAmount(int number) {
        //gobletAmount.SetText(number.ToString());
    }

    public void refreshEquipment() {
        bombAmount.SetText(bombs.Count.ToString());
        gunAmount.SetText(guns.Count.ToString());
        medkitAmount.SetText(medKits.Count.ToString());
        keyAmount.SetText(keys.Count.ToString());
    }
}
