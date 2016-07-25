using UnityEngine;
using System.Collections;

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
		
}
