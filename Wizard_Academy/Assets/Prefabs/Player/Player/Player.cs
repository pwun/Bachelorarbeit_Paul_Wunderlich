using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameObject go;
	Animator anim;

    string signupURL = "http://wunderlich-paul.de/wizard/SignupItem.php";
    string updateURL = "http://wunderlich-paul.de/wizard/UpdateItems.php";
    string infoURL = "http://wunderlich-paul.de/wizard/ItemInfo.php";

	public int sex, body = 1, hair = 1, legs = 1, feet = 1, torso = 0, arms = 0, hands = 0, helmet = 0, weapon = 1, belt = 0;
    public string sex_pos = "12", body_pos, hair_pos, legs_pos, feet_pos, torso_pos, arms_pos, hands_pos, helmet_pos, weapon_pos, belt_pos;


    UserData data;

	// Use this for initialization
	void Start () {
		go = GetComponent<GameObject> ();
		anim = GetComponent<Animator> ();
        data = GameObject.Find("User_Data").GetComponent<UserData>();
		Init (data.id);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Do(string action){
		switch (action) {
			case "Attack":
			case "Hurt":
			case "Die":
				anim.SetTrigger (action);
				break;
			case "Walk":
				anim.SetBool("Idle", false);
				break;
		}
	}

	void Init(int id){
		//Server Anfrage ItemInfo -> falls nicht: SignupItem
        StartCoroutine(ReadFromDB(id));  
	}

    IEnumerator ReadFromDB(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        WWW www = new WWW(infoURL, form);
        yield return www;
        Debug.Log("Answer from Server:" + www.text);
        if (string.IsNullOrEmpty(www.text)){
            StartCoroutine(Signup(id));
        }
        else
        {
            UpdateData(www.text);
        }
    }

    IEnumerator Signup(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        WWW www = new WWW(signupURL, form);
        yield return www;
        Debug.Log("Answer from Server:" + www.text);
        StartCoroutine(ReadFromDB(id));
    }

    void UpdateData(string answer)
    {
        //Set All Values from String <- GetIntValue, GetStringValue
        sex = GetIntValue(answer, "'sex'");
        body = GetIntValue(answer, "'body'");
        hair = GetIntValue(answer, "'hair'");
        feet = GetIntValue(answer, "'feet'");
        legs = GetIntValue(answer, "'legs'");
        torso = GetIntValue(answer, "'torso'");
        arms = GetIntValue(answer, "'arms'");
        hands = GetIntValue(answer, "'hands'");
        weapon = GetIntValue(answer, "'weapon'");
        helmet = GetIntValue(answer, "'helmet'");
        belt = GetIntValue(answer, "'belt'");

        body_pos = GetStringValue(answer, "'body_pos'");
        hair_pos = GetStringValue(answer, "'hair_pos'");
        feet_pos = GetStringValue(answer, "'feet_pos'");
        legs_pos = GetStringValue(answer, "'legs_pos'");
        torso_pos = GetStringValue(answer, "'torso_pos'");
        arms_pos = GetStringValue(answer, "'arms_pos'");
        hands_pos = GetStringValue(answer, "'hands_pos'");
        weapon_pos = GetStringValue(answer, "'weapon_pos'");
        helmet_pos = GetStringValue(answer, "'helmet_pos'");
        belt_pos = GetStringValue(answer, "'belt_pos'");
        Refresh();
    }

    public void Save(int id)
    {
        StartCoroutine(SaveToDB(id));
    }

    IEnumerator SaveToDB(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("sexPost", sex);
        form.AddField("bodyPost", body);
        form.AddField("hairPost", hair);
        form.AddField("feetPost", feet);
        form.AddField("legsPost", legs);
        form.AddField("torsoPost", torso);
        form.AddField("armsPost", arms);
        form.AddField("handsPost", hands);
        form.AddField("weaponPost", weapon);
        form.AddField("helmetPost", helmet);
        form.AddField("beltPost", belt);
        form.AddField("body_posPost", body_pos);
        form.AddField("hair_posPost", hair_pos);
        form.AddField("feet_posPost", feet_pos);
        form.AddField("legs_posPost", legs_pos);
        form.AddField("torso_posPost", torso_pos);
        form.AddField("arms_posPost", arms_pos);
        form.AddField("hands_posPost", hands_pos);
        form.AddField("weapon_posPost", weapon_pos);
        form.AddField("helmet_posPost", helmet_pos);
        form.AddField("belt_posPost", belt_pos);
        WWW www = new WWW(updateURL, form);
        yield return www;
        Debug.Log("Answer from Server:" + www.text);
    }

    public void Refresh(){
		SetAppearance("Body",body,body_pos);
		SetAppearance("Pants",legs,legs_pos);
		SetAppearance("Feet",feet,feet_pos);
		SetAppearance("Torso",torso,torso_pos);
		SetAppearance("Hair",hair,hair_pos);
		SetAppearance("Weapon",weapon,weapon_pos);
		SetAppearance("Arms",arms,arms_pos);
		SetAppearance("Hands",hands,hands_pos);
		SetAppearance("Helmet",helmet,helmet_pos);
		SetAppearance("Belt",belt,belt_pos);
        //Server Update UpdateItem
	}

	public void SetAppearance(string ArmorPart, int id,string pos){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wearables_"+ArmorPart)) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
		}
        if (pos.Contains(id + "")) GameObject.Find("Player_" + ArmorPart + "_" + id).GetComponent<SpriteRenderer>().enabled = true;
        else Debug.Log("Id " + id + " Not Contained In List For " + ArmorPart + " : " + pos);
	}
    int GetIntValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length + 1);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return System.Int32.Parse(value);
    }

    string GetStringValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length + 1);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

}
