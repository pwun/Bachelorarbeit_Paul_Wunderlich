using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    UserData data;
    UpdateUserdata updater;

    Text name_display;
    Text level_display;
    Text xp_display;
    Text xp_e_display;
    Text xp_m_display;
    Text life_display;
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

    public void Train()
    {
        StartCoroutine(data.Train());
    }

    public void Save()
    {
        data.Save();
    }

    public void Quit()
    {
        StartCoroutine(data.Logout());
    }

    void initUiElements()
    {
        name_display = GameObject.Find("UsernameDisplay").GetComponent<Text>();
        level_display = GameObject.Find("LevelDisplay").GetComponent<Text>();
        xp_display = GameObject.Find("XpDisplay").GetComponent<Text>();
        //xp_e_display = GameObject.Find("XpDisplayEnglish").GetComponent<Text>();
        //xp_m_display = GameObject.Find("XpDisplayMath").GetComponent<Text>();
        life_display = GameObject.Find("LifeDisplay").GetComponent<Text>();
    }

    void initUi() {
        name_display.text = data.getName();
        level_display.text = "Lvl.:  "+data.getLevel();
        xp_display.text = data.getXp() + "/" + data.getNeededXp() + " XP";
        //xp_e_display.text = "Englisch: "+data.getEnglishXp()+" XP";
        //xp_m_display.text = "Mathe: " + data.getMathXp()+" XP";
        life_display.text = data.getLifes() + " Münzen";
    }

    public void addXpMath(int addXp){data.addXpMath(addXp);}
    public void addXpEnglish(int addXp){data.addXpEnglish(addXp);}
    public void addLifes(int nrLifes){data.addLifes(nrLifes);}
    public void subLifes(int nrLifes){data.subLifes(nrLifes);}
    public void resetStats() { data.wipe();  }
}
