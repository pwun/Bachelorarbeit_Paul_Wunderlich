using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{

    public static Game current;
    public Character hero;

    public Game(string name, int classLevel)
    {
        hero = new Character(name, classLevel);
    }

}