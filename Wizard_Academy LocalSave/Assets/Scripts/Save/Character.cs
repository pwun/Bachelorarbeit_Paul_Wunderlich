using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Character
{

    public string Name;
    public int ClassLevel, Level, Xp, XpNeeded, Coins, Lifes, Subject, Difficulty;
    public int Sex, Body, Hair, Feet, Legs, Torso, Belt, Arms, Hands, Weapon, Helmet;
    public List<int> SexPos, BodyPos, HairPos, FeetPos, LegsPos, TorsoPos, BeltPos, ArmsPos, HandsPos, WeaponPos, HelmetPos;

    public Character(string name, int classLevel)
    {
        Name = name;
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
        SexPos = new List<int>();
        SexPos.Add(1);
        BodyPos = new List<int>();
        BodyPos.Add(1);
        BodyPos.Add(2);
        HairPos = new List<int>();
        HairPos.Add(1);
        FeetPos = new List<int>();
        FeetPos.Add(1);
        LegsPos = new List<int>();
        LegsPos.Add(1);
        TorsoPos = new List<int>();
        TorsoPos.Add(0);
        TorsoPos.Add(1);
        TorsoPos.Add(3);
        BeltPos = new List<int>();
        BeltPos.Add(0);
        ArmsPos = new List<int>();
        ArmsPos.Add(0);
        HandsPos = new List<int>();
        HandsPos.Add(0);
        WeaponPos = new List<int>();
        WeaponPos.Add(1);
        HelmetPos = new List<int>();
        HelmetPos.Add(0);
    }
}