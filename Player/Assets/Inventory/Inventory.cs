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

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 20;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
        int[] unlockedItems = new int[] { 0, 5, 10 };//Get from Player
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
        //Game.current.hero.InitItems();
    }
}
