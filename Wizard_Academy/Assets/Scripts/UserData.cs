using UnityEngine;
using System.Collections;

public class UserData : MonoBehaviour {

    string name = "test";
    int id = 0;
    int class_level = 0;
    int level = 1;
    int xp = 0;
    int xp_math = 0;
    int xp_english = 0;
    int xp_needed = 100;
    int lifes = 0;
    public int current_dif = 1;
    public string current_subject = "m";

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
            xp_needed += 25;
            level++;
            lifes++;
            //Upload to DB
        }
    }

    public void setName(string newName) { name = newName; }
    public string getName() { return name; }

    public int getId() { return id; }
    public int getXp() { return xp; }
    public int getNeededXp() { return xp_needed; }
    public int getLevel() { return level; }
    public int getMathXp() { return xp_math; }
    public int getEnglishXp() { return xp_english; }
    public int getLifes() { return lifes; }
    public int getClass() { return class_level; }
    //tbc
    public void initId(int newId) { id = newId; }
    public void initClass(int newClass) { class_level = newClass; }
    public void initLevel(int newLevel) { level = newLevel; }
    public void initXp(int newXp) { xp = newXp; }
    public void initNeededXp(int newNeededXp) { xp_needed = newNeededXp; }
    public void initMathXp(int newMathXp) { xp_math = newMathXp; }
    public void initEnglishXp( int newEnglishXp) { xp_english = newEnglishXp; }
    public void initLifes(int newLifes) { lifes = newLifes; }

    public void addXpMath(int addXp) {
        xp += addXp;
        xp_math += addXp;
        checkLevelUp();
    }
    public void addXpEnglish(int addXp)
    {
        xp += addXp;
        xp_english += addXp;
        checkLevelUp();
    }
    public void addLifes(int nrLifes)
    {
        lifes += nrLifes;
    }
    public void subLifes(int nrLifes)
    {
        lifes -= nrLifes;
    }

    public void wipe()
    {
        level = 1;
        xp = 0;
        xp_math = 0;
        xp_english = 0;
        xp_needed = 100;
        lifes = 3;
    }
}
