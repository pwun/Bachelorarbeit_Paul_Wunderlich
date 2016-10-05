using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    string CreateUserUrl = "localhost/wizard_academy/insert_user.php";

    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ClickRegister()
    {
        Debug.Log("Registrieren gedrückt!");
		ChangeScene ("Menu_Register");
    }

    public void ClickLogin()
    {
        Debug.Log("Anmelden gedrückt!");
		ChangeScene ("Menu_Login");
    }

    public void SubmitLogin()
    {
        string name, password;

        name = GameObject.Find("Input Mail").GetComponent<InputField>().text.ToString();
        password = GameObject.Find("Input Password").GetComponent<InputField>().text.ToString();

        Data_Loader dl = GetComponent<Data_Loader>();
        if(dl.CheckLogin(name, password)!=0)
        {
            GameObject.Find("Game_Status").GetComponent<Game_Status>().setName(name);
            GameObject.Find("Game_Status").GetComponent<Game_Status>().setId(dl.CheckLogin(name, password));
            ChangeScene("Game_Main");
            //Load User Data (Name, Level etc)
        }
        else
        {
            //Show Error message
        }
    }

    public void SubmitRegister()
    {
        string name, password, password2;

        name = GameObject.Find("Input Mail").GetComponent<InputField>().text.ToString();
        password = GameObject.Find("Input Password").GetComponent<InputField>().text.ToString();
        password2 = GameObject.Find("Input Password2").GetComponent<InputField>().text.ToString();

        if (password.Equals(password2))
        {
            CreateUser(name, password);
            ChangeScene("Menu_Login");
        }
        else
        {
            Debug.Log("Invalid Registration");
        }
    }

    private void CreateUser(string name, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", name);
        form.AddField("passwordPost", password);
        WWW www = new WWW(CreateUserUrl, form);
    }

}
