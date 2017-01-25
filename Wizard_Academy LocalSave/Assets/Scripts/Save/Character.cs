using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Character
{
    public int id;
    public string Name, Subject;
    public int ClassLevel, Level, Xp, XpNeeded, Coins, Lifes, Difficulty, TrainTask;
    public int Sex, Body, Hair, Feet, Legs, Torso, Belt, Arms, Hands, Weapon, Helmet;
    public List<int> SexPos, BodyPos, HairPos, FeetPos, LegsPos, TorsoPos, BeltPos, ArmsPos, HandsPos, WeaponPos, HelmetPos;
    public List<int> Unlocked;
    public int[] XpList = {200, 200, 400, 600, 1000, 1200, 1400, 1800, 2100, 2400, 2800, 3200, 3600, 5000};

    public Character(string name, int classLevel, int _id)
    {
        id = _id;
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

    public void AddXp(int newXp)
    {
        Xp += newXp;
        if (Xp >= XpNeeded)
        {
            if (Level == 3 || Level == 6 || Level == 9 || Level == 12) {
                //BossKampf
                Xp = XpNeeded;
            }
            else {
                Level++;
                Xp -= XpNeeded;
                XpNeeded = XpList[Level];
                Coins += 3;
            }
        }
    }

    public void LevelUp() {
        Level++;
        Xp = 0;
        XpNeeded = XpList[Level];
        Coins += 3;
    }

    public void initItems()
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
        Unlocked = new List<int>();
        Unlocked.Add(0);
        Unlocked.Add(1);
        Unlocked.Add(6);
        Unlocked.Add(13);
        Unlocked.Add(14);






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