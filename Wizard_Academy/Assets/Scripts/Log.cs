using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

    UserData data;
    string LogURL = "http://wunderlich-paul.de/wizard/Log.php";

    // Use this for initialization
    void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LogEntry(string action)
    {
        int id = data.getId();

        WWWForm form = new WWWForm();
        form.AddField("useridPost", id);
        form.AddField("actionPost", action);
        WWW www = new WWW(LogURL, form);
    }

    public void LogEntry(string action, string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("useridPost", id);
        form.AddField("actionPost", action);
        WWW www = new WWW(LogURL, form);
    }
}
