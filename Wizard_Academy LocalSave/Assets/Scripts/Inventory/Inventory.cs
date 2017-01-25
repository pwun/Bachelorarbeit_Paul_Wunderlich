﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    ItemDatabase database;

    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    public Button colorR1;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        SaveLoad.Load();
        database = GetComponent<ItemDatabase>();

        slotAmount = 20;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        GameObject.Find("Color_Reset").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 0; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        if (Game.current.hero.achievements.Contains(1)){
            GameObject.Find("Color_R1").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 1; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }else{Destroy(GameObject.Find("Color_R1"));}
        if (Game.current.hero.achievements.Contains(1))
        {
            GameObject.Find("Color_R1").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 1; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_R1")); }
        if (Game.current.hero.achievements.Contains(2))
        {
            GameObject.Find("Color_R2").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 2; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_R2")); }
        if (Game.current.hero.achievements.Contains(3))
        {
            GameObject.Find("Color_R3").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 3; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_R3")); }
        if (Game.current.hero.achievements.Contains(4))
        {
            GameObject.Find("Color_R4").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 4; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_R4")); }
        if (Game.current.hero.achievements.Contains(5))
        {
            GameObject.Find("Color_B1").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 5; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_B1")); }
        if (Game.current.hero.achievements.Contains(6))
        {
            GameObject.Find("Color_B2").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 6; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_B2")); }
        if (Game.current.hero.achievements.Contains(7))
        {
            GameObject.Find("Color_B3").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 7; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_B3")); }
        if (Game.current.hero.achievements.Contains(8))
        {
            GameObject.Find("Color_B4").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 8; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_B4")); }
        if (Game.current.hero.achievements.Contains(9))
        {
            GameObject.Find("Color_S1").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 9; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_S1")); }
        if (Game.current.hero.achievements.Contains(10))
        {
            GameObject.Find("Color_S2").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 10; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_S2")); }
        if (Game.current.hero.achievements.Contains(11))
        {
            GameObject.Find("Color_S3").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 11; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_S3")); }
        if (Game.current.hero.achievements.Contains(12))
        {
            GameObject.Find("Color_S4").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.color = 12; SaveLoad.Save(); GameObject.Find("Player").GetComponent<Player>().setColor(); });
        }
        else { Destroy(GameObject.Find("Color_S4")); }        


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
        if (Game.current.hero.Level > 3)
        {
            if (!Game.current.hero.Unlocked.Contains(4))
            {
                Game.current.hero.Unlocked.Add(4);
            }
        }
        if (Game.current.hero.Level > 6)
        {
            if (!Game.current.hero.Unlocked.Contains(2))
            {
                Game.current.hero.Unlocked.Add(2);
            }
        }
        if (Game.current.hero.Level > 9)
        {
            if (!Game.current.hero.Unlocked.Contains(5))
            {
                Game.current.hero.Unlocked.Add(5);
            }
        }
        if (Game.current.hero.Level > 12)
        {
            if (!Game.current.hero.Unlocked.Contains(3))
            {
                Game.current.hero.Unlocked.Add(3);
            }
        }
        SaveLoad.Save();
        int[] unlockedItems = Game.current.hero.Unlocked.ToArray();
        for (int i = 0; i < unlockedItems.Length; i++) {
            AddItem(unlockedItems[i]);
        }
    }

    public void AddItem(int id) {
        Item itemToAdd = database.FetchItemById(id);
        for (int i = 0; i < items.Count; i++) {
            if(items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                slots[i].AddComponent<Slot>();
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.name = itemToAdd.Title;
                itemObj.transform.position = Vector2.zero;
                break;
            }
        }
    }

    public bool ItemInInventory(int id) {
        for (int i = 0; i < items.Count; i++) {
            if (items[i].ID == id) return true;
        }
        return false;
    }

    public void ResetPlayer() {
        Game.current.hero.initItems();
        GameObject.Find("Player").GetComponent<Player>().Refresh();
    }
}
