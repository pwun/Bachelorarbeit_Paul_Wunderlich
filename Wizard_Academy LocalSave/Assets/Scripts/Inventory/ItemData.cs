using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour {
    public Item item;

    public void Clicked() {
        switch (item.Value) {
            case 1: Game.current.hero.Torso = item.Index;break;
            case 2: Game.current.hero.Legs = item.Index; break;
            case 3: Game.current.hero.Arms = item.Index; break;
            case 4: Game.current.hero.Hands = item.Index; break;
            case 5: Game.current.hero.Belt = item.Index; break;
            case 6: Game.current.hero.Helmet = item.Index; break;
        }
        GameObject.Find("Player").GetComponent<Player>().Refresh();
        SaveLoad.Save();
    }
}
