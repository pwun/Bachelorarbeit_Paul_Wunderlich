﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHelper : MonoBehaviour
{

    ItemDatabase database;

    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public Sprite coin;

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
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
        int[] unlockedItems = Game.current.hero.Unlocked.ToArray();
        for (int i = 0; i < unlockedItems.Length; i++)
        {
            AddItem(unlockedItems[i]);
        }
        if (Game.current.hero.Level > 3)
        {
            AddItem(2);
        }
        if (Game.current.hero.Level > 6)
        {
            AddItem(3);
        }
        if (Game.current.hero.Level > 9)
        {
            AddItem(4);
        }
        if (Game.current.hero.Level > 12)
        {
            AddItem(5);
        }
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemById(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
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

    public void GetItem() {
        int[] itemIds = new int[] { 7, 8, 9, 10, 11, 12, 15, 16, 17, 18, 19 };
        int itemId = itemIds[Random.Range(0, 11)];
        if (Game.current.hero.Unlocked.Count < 16 + (Game.current.hero.Level / 3))//2,3,4,5 -> boss drops //0,1,6,13,14 -> start
        {
            while (ItemInInventory(itemId))
            {
                itemId = itemIds[Random.Range(0, 11)];
            }
            Game.current.hero.Unlocked.Add(itemId);
            AddItem(itemId);
            GameObject.Find("LootImage").GetComponent<Image>().sprite = database.FetchItemById(itemId).Sprite;
        }
        else {
            GameObject.Find("LootText").GetComponent<Text>().text = "Du hast bereits alle zufälligen Items gefunden & erhältst stattdessen eine Münze";
            GameObject.Find("LootImage").GetComponent<Image>().sprite = coin;
            Game.current.hero.Coins++;
            SaveLoad.Save();
        }
        
    }

    public bool ItemInInventory(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == id) return true;
        }
        return false;
    }

    public void ResetPlayer()
    {
        Game.current.hero.initItems();
        GameObject.Find("Player").GetComponent<Player>().Refresh();
    }
}
