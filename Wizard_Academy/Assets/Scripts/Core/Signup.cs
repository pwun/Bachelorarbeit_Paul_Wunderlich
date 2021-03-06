﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Signup : MonoBehaviour {

    public string inputUsername;
    public string inputPassword;
    public string inputPassword2;
    public int inputClass;

    string SignupURL = "http://wunderlich-paul.de/wizard/Signup.php";

    // Use this for initialization
    void Start () {
        GameObject.Find("Username_Input").GetComponent<InputField>().Select();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitRegister();
        if (Input.GetKeyDown(KeyCode.Tab)) switchFocus();
    }

    public void SubmitRegister()
    {
        //Update inputUsername;
        inputUsername = GameObject.Find("Username_Input").GetComponent<InputField>().text;
        //Update inputPasswords;
        inputPassword = GameObject.Find("Password_Input").GetComponent<InputField>().text;
        inputPassword2 = GameObject.Find("Password2_Input").GetComponent<InputField>().text;

        //Update Class
        switch (GameObject.Find("Dropdown").GetComponent<Dropdown>().value)
        {
            case 0:
                inputClass = 6;
                break;
            case 1:
                inputClass = 8;
                break;
        }

        if (inputPassword.Equals(inputPassword2))
        {
            StartCoroutine(SignupToDB(inputUsername, inputPassword, inputClass));
        }
        else
        {
            GameObject.Find("Warning").GetComponent<Text>().text = "Passwörter stimmen nicht überein.";
        }
    }

    IEnumerator SignupToDB(string username, string password, int classLevel)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", inputUsername);
        form.AddField("passwordPost", inputPassword);
        form.AddField("classPost", classLevel);

        WWW www = new WWW(SignupURL, form);
        yield return www;
        Debug.Log(www.text);
        if (www.text.Contains("registration success."))
        {
            //Load Game
            SceneManager.LoadScene("Login");
        }
        else
        {
            GameObject.Find("Warning").GetComponent<Text>().text = "Nutzername bereits vergeben.";
        }
    }

    public void switchFocus()
    {
        //if Username_Input is active -> make Password_Input active
        // & the other way around
        if (GameObject.Find("Username_Input").GetComponent<InputField>().isFocused)
        {
            GameObject.Find("Password_Input").GetComponent<InputField>().Select();
        }
        else if (GameObject.Find("Password_Input").GetComponent<InputField>().isFocused)
        {
            GameObject.Find("Password2_Input").GetComponent<InputField>().Select();
        }
        else
        {
            GameObject.Find("Username_Input").GetComponent<InputField>().Select();
        }

    }
}
