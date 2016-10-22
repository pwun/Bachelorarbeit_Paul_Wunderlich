using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character
{

    public string Name;
    public int Id, ClassLevel, Level, Xp, XpNeeded, Coins, Lifes, Subject, Difficulty;
    public int Sex, Body, Hair, Feet, Legs, Torso, Belt, Arms, Hands, Weapon, Helmet;
    public ArrayList<int> SexPos, BodyPos, HairPos, FeetPos, LegsPos, TorsoPos, BeltPos, ArmsPos, HandsPos, WeaponPos, HelmetPos;

    public Character(string name, int id, int classLevel)
    {
        Name = name;
        Id = id;
        ClassLevel = classLevel;
        Level = 1;
        Xp = 0;
        XpNeeded = 200;
        Coins = 3;
        Lifes = 3;
        initItemPos();
        initItems();
    }

    void initItems()
    {
        Sex = 1;
        Body = 1;
        Hair = 1;
        Feet = 1;
        Legs = 1;
        Torso = 0;
        Belt = 0;
        Arms = 0;
        Hands = 0;
        Weapon = 1;
        Helmet = 0;
    }

    void initItemPos()
    {
        SexPos = new ArrayList<int>().Add(1);
        BodyPos = new ArrayList<int>().Add(1, 2);
        HairPos = new ArrayList<int>().Add(1);
        FeetPos = new ArrayList<int>().Add(1);
        LegsPos = new ArrayList<int>().Add(1);
        TorsoPos = new ArrayList<int>().Add(0, 1, 3);
        BeltPos = new ArrayList<int>().Add(0);
        ArmsPos = new ArrayList<int>().Add(0);
        HandsPos = new ArrayList<int>().Add(0);
        WeaponPos = new ArrayList<int>().Add(1);
        HelmetPos = new ArrayList<int>().Add(0);
    }
}