using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour {

    Image math;
    Image english;
    Button switchButton;
    GameObject switchObj;
    Button closeButton;
    GameObject closeObj;
    Button helpButton;
    GameObject helpObj;
    Text switchText;


    GameObject Main_CharDisplay;
    GameObject Main_Player;

    private void Start()
    {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Mini1")))
        {
            GameObject.Find("controller").GetComponent<Pause>().SwitchPause();
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Main")))
        {
            Main_CharDisplay = GameObject.Find("CharDisplay");
            Main_Player = GameObject.Find("Player");
        }
        math = (Image)GameObject.Find("Math").GetComponent<Image>();
        english = (Image)GameObject.Find("English").GetComponent<Image>();
        switchButton = (Button)GameObject.Find("Help_Switch").GetComponent<Button>();
        switchButton.onClick.AddListener(() => { switchImages(); });
        closeButton = (Button)GameObject.Find("Help_Close").GetComponent<Button>();
        closeButton.onClick.AddListener(() => { closeHelp(); });
        helpButton = (Button)GameObject.Find("Help_Button").GetComponent<Button>();
        helpButton.onClick.AddListener(() => { openHelp(); });

        switchObj = GameObject.Find("Help_Switch");
        closeObj = GameObject.Find("Help_Close");
        helpObj = GameObject.Find("Help_Button");

        switchText = (Text)switchButton.GetComponentInChildren<Text>();

        closeHelp();
    }

    private void closeHelp() {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Main")))
        {
            Main_CharDisplay.SetActive(true);
            Main_Player.SetActive(true);
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Mini1")))
        {
            GameObject.Find("controller").GetComponent<Pause>().SwitchPause();
        }
        math.enabled = false;
        english.enabled = false;
        switchObj.SetActive(false);
        closeObj.SetActive(false);
        helpObj.SetActive(true);
    }

    private void openHelp() {
        //if(menu){disable char display}
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Main"))) {
            Main_CharDisplay.SetActive(false);
            Main_Player.SetActive(false);
        }
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Mini1")))
        {
            GameObject.Find("controller").GetComponent<Pause>().SwitchPause();
        }
        //if(mini1){pause}
        math.enabled = false;
        english.enabled = true;
        switchObj.SetActive(true);
        closeObj.SetActive(true);
        helpObj.SetActive(false);
        switchText.text = "zu Mathe wechseln";
    }

    private void switchImages() {
        if (english.enabled)
        {
            english.enabled = false;
            math.enabled = true;
            switchText.text = "zu Englisch wechseln";
        }
        else {
            english.enabled = true;
            math.enabled = false;
            switchText.text = "zu Mathe wechseln";
        }
    }
}
