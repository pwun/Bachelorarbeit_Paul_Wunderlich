using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour {

    string LoginURL = "http://wunderlich-paul.de/wizard/Signup.php";
    int nextId;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Username_Input").GetComponent<InputField>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitRegister();
    }

    public void SubmitRegister()
    {
        int classLevel = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        switch (classLevel)
        {
            case 0:
                classLevel = 6;
                break;
            case 1:
                classLevel = 8;
                break;
        }
        string heroName = GameObject.Find("Username_Input").GetComponent<InputField>().text;
        nextId = -1;
        nextId = SignupAtDB(heroName, classLevel);
        if (nextId == -1) {
            //Wait
            Debug.Log("Waiting for id...");
        }
        Debug.Log("ID: " + nextId);
        Game game = new Game(heroName, classLevel, nextId);
        Game.current = game;
        SaveLoad.Save();
        Log.LogEntry("Registration");
        SceneManager.LoadScene("Customizer");
    }

    int SignupAtDB(string _username, int _class)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", _username);
        form.AddField("passwordPost", "generic");
        form.AddField("classPost", _class);
        WWW www = new WWW(LoginURL, form);
        while (!www.isDone) {
        //wait
        }
        if (www.text.Contains("id:"))
        {
            string id = www.text.Substring(www.text.IndexOf(':') + 1);
            int result = int.Parse(id);
            return result;
        }
        else {
            Debug.Log("Registration failed:"+ www.text);
            return -1;
        }
    }
}
