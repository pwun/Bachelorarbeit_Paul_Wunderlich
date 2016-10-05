using UnityEngine;
using System.Collections;

public class UserData : MonoBehaviour {

    string name = "test";
    int id = 0;
    int class_level = 0;
    int level = 0;
    int xp = 0;
    int xp_math = 0;
    int xp_english = 0;
    int xp_needed = 100;
    int lifes = 0;

    static UserData current;

    // Use this for initialization
    void Start()
    {
        if (current != null)
        {
            Destroy(this.gameObject);
            Debug.Log("Duplicate Game_Status destroyed itself.");
            return;
        }
        current = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //checkLevelUp();
    }

    void checkLevelUp()
    {
        if (xp >= xp_needed)
        {
            xp = xp - xp_needed;
            xp_needed *= 2;
            level++;
            //Upload to DB
        }
    }

    public void setName(string newName) { name = newName; }
    public string getName() { return name; }

    public int getId() { return id; }
    public int getXp() { return xp; }
    public int getNeededXp() { return xp_needed; }
    public int getLevel() { return level; }
    //tbc
    public void initId(int newId) { id = newId; }
    public void initLevel(int newLevel) { level = newLevel; }
    public void initXp(int newXp) { xp = newXp; }
    public void initNeededXp(int newNeededXp) { xp_needed = newNeededXp; }


}
