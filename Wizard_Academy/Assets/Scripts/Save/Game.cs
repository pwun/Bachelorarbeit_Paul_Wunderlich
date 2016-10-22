using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{

    public static Game current;
    public Character hero;

    public Game(string name, int id, int classLevel)
    {
        hero = new Character(name, id, classLevel);
    }

}