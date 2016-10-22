using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    string LoginURL = "http://wunderlich-paul.de/wizard/Login.php";
    string LoadURL = "http://wunderlich-paul.de/wizard/UserInfo.php";

    UserData data;

    InputField UsernameInput;
    InputField PwInput;
    Text Warning;

    public void Start()
    {
        UsernameInput = GameObject.Find("Username_Input").GetComponent<InputField>();
        PwInput = GameObject.Find("Password_Input").GetComponent<InputField>();
        Warning =  GameObject.Find("Warning").GetComponent<Text>();
        GameObject.Find("Submit_Button").GetComponent<Button>().onClick.AddListener(() => { SubmitLogin(); });
		UsernameInput.Select();
    }

    public void SubmitLogin(){
        StartCoroutine(LoginToDB(UsernameInput.text, PwInput.text));
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form);
        yield return www;
        if(www.text.Contains("id")){
            string id = www.text.Substring(www.text.IndexOf(':')+1);
            StartCoroutine(ReadFromDB(id));
        }
        else Warning.text = "Falsches Passwort";
    }

    IEnumerator ReadFromDB(string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        WWW www = new WWW(LoadURL, form);
        yield return www;
        updateData(www.text);
        Debug.Log("Answer from Server:"+www.text);
        /*if(data.torso==0)
        {
            SceneManager.LoadScene("PlayerCreation");
        }
        else { SceneManager.LoadScene("Main");}
        */
        SceneManager.LoadScene("Customizer");
    }

    void updateData(string result)
    {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        data.name = UsernameInput.text;
        data.class_level = GetIntValue(result, "'class'");
        data.id = GetIntValue(result, "'id'");
        data.xp_needed = GetIntValue(result, "'max_xp'");
        data.xp = GetIntValue(result, "'xp'");
        data.level = GetIntValue(result, "'lvl'");
        //data.SetMathXp(GetIntValue(result, "'m_xp'");
        //data.SetEnglishXp(GetIntValue(result, "'e_xp'");
        data.lifes = GetIntValue(result, "'lifes'");
        //data.armor_nr = GetIntValue(result, "'armor'");
        //data.head_nr = GetIntValue(result, "'helmet'");
        //data.armor_pos = GetStringValue(result, "'armor_pos'");
        //data.head_pos = GetStringValue(result, "'helmet_pos'");

		//POSSTRING = GETSTRINGVALUE
		//ITEMSTRING = GETITEMMBLIBLABLUB
		Log.LogEntry ("Login",GetIntValue(result, "'id'"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitLogin();
        if (Input.GetKeyDown(KeyCode.Tab)) switchFocus();
    }

    public void switchFocus()
    {
        if (UsernameInput.isFocused) PwInput.Select();
        else UsernameInput.Select();
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
