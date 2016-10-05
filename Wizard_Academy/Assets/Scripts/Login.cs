using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public string inputUsername;
    public string inputPassword;

    string LoginURL = "localhost/wizard_academy/Login.php";

    void Start()
    {
        GameObject.Find("Username_Input").GetComponent<InputField>().Select();
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitLogin();
        if (Input.GetKeyDown(KeyCode.Tab)) switchFocus();
    }

    public void SubmitLogin()
    {
        //Update inputUsername;
        inputUsername = GameObject.Find("Username_Input").GetComponent<InputField>().text;
        //Update inputPassword;
        inputPassword = GameObject.Find("Password_Input").GetComponent<InputField>().text;

        StartCoroutine(LoginToDB(inputUsername, inputPassword));
    }

    public void switchFocus()
    {
        //if Username_Input is active -> make Password_Input active
        // & the other way around
        if (GameObject.Find("Username_Input").GetComponent<InputField>().isFocused)
        {
            GameObject.Find("Password_Input").GetComponent<InputField>().Select();
        }
        else
        {
            GameObject.Find("Username_Input").GetComponent<InputField>().Select();
        }
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", inputUsername);
        form.AddField("passwordPost", inputPassword);

        WWW www = new WWW(LoginURL, form);
        yield return www;
        Debug.Log(www.text);
        if(www.text.Equals("login success"))
        {
            //Update Persistant Game Data
            GameObject.Find("User_Data").GetComponent<UserData>().setName(inputUsername);
            //Load Game
            SceneManager.LoadScene("Main");
        }
        else
        {
            //Send Error-Feedback
            //Clear Fields
        }
    }
}
