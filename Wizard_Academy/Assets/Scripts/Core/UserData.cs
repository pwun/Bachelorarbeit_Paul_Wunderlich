using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour {

    string UpdateURL = "http://wunderlich-paul.de/wizard/Update.php";
    static UserData current;

    public string name = "test";
    public int id = 0;
    public int class_level = 0;
    public int level = 1;
    public int xp = 0;
    public int xp_needed = 200;
    public int lifes = 0;
    public int current_dif = 1;
    public string current_subject = "m";
	//Muss auf Server
	public int body = 1, hair = 1, legs = 1, feet = 1, torso = 0, arms = 0, hands = 0, helmet = 0, weapon = 1, belt = 0;
	//Muss auf Server
	public string body_pos, hair_pos, legs_pos, feet_pos, torso_pos, arms_pos, hands_pos, helmet_pos, weapon_pos, belt_pos;

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

    public void Save(string nextScene)
    {
        //Logentry
        StartCoroutine(SendToDB(nextScene));
    }

    IEnumerator SendToDB(string nextScene)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("lvlPost", level);
        form.AddField("xpPost", xp);
        form.AddField("max_xpPost", xp_needed);
        form.AddField("lifesPost", lifes);
        //form.AddField("armorPost", armor_nr);
        //form.AddField("headPost", head_nr);
        //form.AddField("armorposPost", armor_pos);
        //form.AddField("headposPost", head_pos);
		form.AddField("Body",body);
		form.AddField("Hair",hair);
		form.AddField("Legs",legs);
		form.AddField("Feet",feet);
		form.AddField("Torso",torso);
		form.AddField("Arms",arms);
		form.AddField("Hands",hands);
		form.AddField("Helmet",helmet);
		form.AddField("Weapon",weapon);
		form.AddField("Belt",belt);

		form.AddField("BodyPos",body_pos);
		form.AddField("HairPos",hair_pos);
		form.AddField("LegsPos",legs_pos);
		form.AddField("FeetPos",feet_pos);
		form.AddField("TorsoPos",torso_pos);
		form.AddField("ArmsPos",arms_pos);
		form.AddField("HandsPos",hands_pos);
		form.AddField("HelmetPos",helmet_pos);
		form.AddField("WeaponPos",weapon_pos);
		form.AddField("BeltPos",belt_pos);
        WWW www = new WWW(UpdateURL, form);
        yield return www;
        Debug.Log(www.text);
        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void addXp(int newXp)
    {
        xp += newXp;
        checkLevelUp();
    }

    void checkLevelUp()
    {
        if (xp >= xp_needed)
        {
            xp = xp - xp_needed;
            level++;
            xp_needed = GetNewXpNeeded(level);
            lifes+=3;
        }
    }


    /*public void addXpMath(int addXp) {
        xp += addXp;
        xp_math += addXp;
        checkLevelUp();
    }
    public void addXpEnglish(int addXp)
    {
        xp += addXp;
        xp_english += addXp;
        checkLevelUp();
    }*/

    public void wipe()
    {
        level = 1;
        xp = 0;
        //xp_math = 0;
        //xp_english = 0;
        xp_needed = 200;
        lifes = 3;
		body = 1; hair = 1; legs = 1; feet = 1; torso = 0; arms = 0; hands = 0; helmet = 0; weapon = 1; belt = 0;
		body_pos = "01"; hair_pos = "01"; legs_pos="01"; feet_pos = "01"; torso_pos = "0134"; arms_pos="0"; hands_pos = "0"; helmet_pos="0134"; weapon_pos = "01"; belt_pos="0";
    }

    int GetNewXpNeeded(int level)
    {
        int xp = 0;
        switch (level)
        {
            case 2:
                xp = 400;
                break;
            case 3:
                xp = 600;
                break;
            case 4:
                xp = 1000;
                break;
            case 5:
                xp = 1200;
                break;
            case 6:
                xp = 1400;
                break;
            case 7:
                xp = 1800;
                break;
            case 8:
                xp = 2100;
                break;
            case 9:
                xp = 2400;
                break;
            case 10:
                xp = 2800;
                break;
            case 11:
                xp = 3200;
                break;
            case 12:
                xp = 3600;
                break;
            default:
                xp = 5000;
                break;
        }
        return xp;
    }
}
