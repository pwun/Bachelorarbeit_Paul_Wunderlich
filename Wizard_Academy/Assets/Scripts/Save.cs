using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

    UserData data;
    string username;
    int id;
    int lvl;
    int xp;
    int max_xp;
    int m_xp;
    int e_xp;
    int lifes;

    string UpdateURL = "http://wunderlich-paul.de/wizard/Update.php";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // save when Strg+s is pressed ?    if (Input.GetKeyDown(KeyCode.Return)) SubmitRegister();
    }

    public void UpdateDB()
    {
        data = GameObject.Find("User_Data").GetComponent<UserData>();

        username = data.getName();
        id = data.getId();
        lvl = data.getLevel();
        xp = data.getXp();
        max_xp = data.getNeededXp();
        m_xp = data.getMathXp();
        e_xp = data.getEnglishXp();
        lifes = data.getLifes();

        StartCoroutine(SendToDB());
    }

    IEnumerator SendToDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("lvlPost", lvl);
        form.AddField("xpPost", xp);
        form.AddField("max_xpPost", max_xp);
        form.AddField("m_xpPost", m_xp);
        form.AddField("e_xpPost", e_xp);
        form.AddField("lifesPost", lifes);

        WWW www = new WWW(UpdateURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text.Contains("update success."))
        {
            Debug.Log("Succesfully saved Data");
            //Load Game
        }
        else
        {
            //Send Error-Feedback
            //Username already exists?
            //Clear Fields
        }
    }

}

