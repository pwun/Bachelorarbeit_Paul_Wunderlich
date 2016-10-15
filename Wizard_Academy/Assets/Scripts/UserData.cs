using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour {

    string LogURL = "http://wunderlich-paul.de/wizard/Log.php";
    string UpdateURL = "http://wunderlich-paul.de/wizard/Update.php";

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

    public IEnumerator Train()
    {
        bool finished = LogEntry("train start", false);
        yield return finished;
        SceneManager.LoadScene("TrainSetup");
    }

    public IEnumerator Logout()
    {
        Debug.Log("Logout..............");
        Save();
        bool finished = LogEntry("logout", false);
        yield return finished;
        SceneManager.LoadScene("Login");
        Debug.Log("........done");
    }

    bool LogEntry(string action, bool feedback)
    {
        WWWForm form = new WWWForm();
        form.AddField("useridPost", id);
        form.AddField("actionPost", action);
        WWW www = new WWW(LogURL, form);
        Debug.Log("Logged: " + action);
        return true;
    }

    public void LogEntry(string action)
    {
        WWWForm form = new WWWForm();
        form.AddField("useridPost", id);
        form.AddField("actionPost", action);
        WWW www = new WWW(LogURL, form);
        Debug.Log("Logged: " + action);
    }

    public void LogEntry(string action, string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("useridPost", id);
        form.AddField("actionPost", action);
        WWW www = new WWW(LogURL, form);
        Debug.Log("Logged: " + action);
    }

    public void Save()
    {
        StartCoroutine(SendToDB());
    }

    public IEnumerator QuitTrain()
    {
        Save();
        bool finished = LogEntry("train end", false);
        yield return finished;
        SceneManager.LoadScene("Main");
    }

    IEnumerator SendToDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("lvlPost", level);
        form.AddField("xpPost", xp);
        form.AddField("max_xpPost", xp_needed);
        form.AddField("m_xpPost", xp_math);
        form.AddField("e_xpPost", xp_english);
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
            Debug.Log("Error: Couldn't Save Data");
            //Send Error-Feedback
            //Username already exists?
            //Clear Fields
        }
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
