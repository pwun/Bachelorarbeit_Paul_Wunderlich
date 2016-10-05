using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    UserData data;
    UpdateUserdata updater;

    Text name_display;
    Text level_display;
    Text xp_display;
	// Use this for initialization
	void Start () {
        //updater = GetComponent<UpdateUserdata>();
        //updater.refresh();
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        initUiElements();
        initUi();
	}
	
	// Update is called once per frame
	void Update () {
        initUi();
	}

    void initUiElements()
    {
        name_display = GameObject.Find("UsernameDisplay").GetComponent<Text>();
        level_display = GameObject.Find("LevelDisplay").GetComponent<Text>();
        xp_display = GameObject.Find("XpDisplay").GetComponent<Text>();
    }

    void initUi() {
        name_display.text = data.getName();
        level_display.text = "Lvl.:  "+data.getLevel();
        xp_display.text = data.getXp() + "/" + data.getNeededXp() + " XP";
    }
}
