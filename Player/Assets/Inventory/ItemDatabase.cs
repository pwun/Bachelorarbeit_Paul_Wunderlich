using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    private void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath+"/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    public Item FetchItemById(int id) {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    public Item[] GetAll() {
        return database.ToArray();
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++) {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"], itemData[i]["slug"].ToString(), (int)itemData[i]["index"]));
        }
    }
}

public class Item{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
    public int Index { get; set; }

    public Item(int id, string title, int value, string slug, int index) {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + Slug);
        this.Index = index;
    }

    public Item() {
        this.ID = -1;
    }
}