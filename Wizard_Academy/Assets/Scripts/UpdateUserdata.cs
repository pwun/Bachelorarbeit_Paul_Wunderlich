using UnityEngine;
using System.Collections;

public class UpdateUserdata : MonoBehaviour {

    UserData data;
    string LoginURL = "localhost/wizard_academy/UserInfo.php";
    // Use this for initialization
    void Start () {
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
    }

    int GetIntValue(string data, string index)
    {
        //PROBLEM: XP, MAX_XP, M_XP, E_XP
        string value = data.Substring(data.IndexOf(index) + index.Length +1);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return System.Int32.Parse(value);
    }

    void updateData(string result)
    {
        data.initNeededXp(GetIntValue(result, "max_xp"));
        data.initXp(GetIntValue(result, "xp"));
        data.initLevel(GetIntValue(result, "lvl"));
    }
}
