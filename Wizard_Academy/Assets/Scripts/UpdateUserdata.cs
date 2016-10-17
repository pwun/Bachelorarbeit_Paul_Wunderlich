using UnityEngine;
using System.Collections;

public class UpdateUserdata : MonoBehaviour {

    UserData data;
    Main main;
    string LoginURL = "http://wunderlich-paul.de/wizard/UserInfo.php";
    // Use this for initialization
    void Start () {
        main = GetComponent<Main>();
        refresh();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void refresh()
    {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        StartCoroutine(ReadFromDB(data.getName()));
    }

    IEnumerator ReadFromDB(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        WWW www = new WWW(LoginURL, form);
        yield return www;
        Debug.Log("Answer from Server:"+www.text);
        updateData(www.text);
        main.continueUpdating();
    }

    int GetIntValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length +1);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return System.Int32.Parse(value);
    }

    void updateData(string result)
    {
        result = result.Split('<')[0];
        data.initClass(GetIntValue(result, "'class'"));
        data.initId(GetIntValue(result, "'id'"));
        data.initNeededXp(GetIntValue(result, "'max_xp'"));
        data.initXp(GetIntValue(result, "'xp'"));
        data.initLevel(GetIntValue(result, "'lvl'"));
        data.initMathXp(GetIntValue(result, "'m_xp'"));
        data.initEnglishXp(GetIntValue(result, "'e_xp'"));
        data.initLifes(GetIntValue(result, "'lifes'"));
        data.armor_nr = GetIntValue(result, "'armor'");
        data.head_nr = GetIntValue(result, "'head'");
    }
}
