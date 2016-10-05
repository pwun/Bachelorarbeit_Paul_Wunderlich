using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

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
        if(dl.CheckLogin(name, password))
        {
            ChangeScene("Game_Main");
            //Load User Data (Name, Level etc)
        }
        else
        {
            //Show Error message
        }
    }
		
}
