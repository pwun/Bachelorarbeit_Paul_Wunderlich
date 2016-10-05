using UnityEngine;
using System.Collections;

public class Game_Status : MonoBehaviour {

    //Fill with Data from Server
    protected string player_id = "hanswurst";
    protected int level = 1;
    protected int math_level = 1;
    protected int english_level = 1;
    protected int xp = 0;
    protected int neededXp = 100;

    static Game_Status status;

	// Use this for initialization
	void Start () {
        if (status!= null)
        {
            Destroy(this.gameObject);
            Debug.Log("Duplicate Game_Status destroyed itself.");
            return;
        }
        status = this;
        GameObject.DontDestroyOnLoad( this.gameObject );
	}
	
	// Update is called once per frame
	void Update () {
        checkLevelUp();
	}

    void checkLevelUp()
    {
        if(xp >= neededXp)
        {
            xp = xp - neededXp;
            neededXp *= 2;
            level++;
            //TODO: Play Levelup Sound
        }
    }


    public string getName()
    {
        return player_id;
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

    public void addXp(int add)
    {
        xp = xp + add;
    }
    
}
