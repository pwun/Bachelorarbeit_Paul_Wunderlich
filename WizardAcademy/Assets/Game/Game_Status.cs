using UnityEngine;
using System.Collections;

public class Game_Status : MonoBehaviour {

    //Fill with Data from Server
    protected string player_name = "Nicht Verbunden";
    protected int player_id = 0;
    protected int level = 1;
    protected int math_level = 1;
    protected int english_level = 1;
    protected int xp = 10;
    protected int neededXp = 100;

    static Game_Status status;

    // Use this for initialization
    void Start() {
        if (status != null)
        {
            Destroy(this.gameObject);
            Debug.Log("Duplicate Game_Status destroyed itself.");
            return;
        }
        status = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update() {
        checkLevelUp();
    }

    void checkLevelUp()
    {
        if (xp >= neededXp)
        {
            xp = xp - neededXp;
            neededXp *= 2;
            level++;
            //TODO: Play Levelup Sound
        }
    }


    public string getName()
    {
        return player_name;
    }
    public int getLevel()
    {
        return level;
    }
    public int getXp()
    {
        return xp;
    }
    public int getNeededXp()
    {
        return neededXp;
    }
    public int getId()
    {
        return player_id;
    }

    public void addXp(int add)
    {
        xp = xp + add;
    }
    public void setName(string name)
    {
        player_name = name;
    }
    public void setId(int id)
    {
        player_id = id;
    }
    public void setXp(int number)
    {
        xp = number;
    }
    public void setMathXp(int number)
    {
        math_level = number;
    }
    public void setEnglishXp(int number)
    {
        english_level = number;
    }
}
