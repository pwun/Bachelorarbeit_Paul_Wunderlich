using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    UserData data;
    PlayerCreation player;

    Text name_display;
    Text level_display;
    Text xp_display;
    Text xp_e_display;
    Text xp_m_display;
    Text life_display;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        initUiElements();
        GameObject.Find("Save_Button").GetComponent<Button>().onClick.AddListener(() => { data.Save("Login"); });
        GameObject.Find("Train_Button").GetComponent<Button>().onClick.AddListener(() => { data.Save("TrainSetup"); });
        GameObject.Find("Mini1_Button").GetComponent<Button>().onClick.AddListener(() => { data.Save("Mini1_Start"); });
        GameObject.Find("Test_Cheat_Button").GetComponent<Button>().onClick.AddListener(() => { data.addXp(100); });
        GameObject.Find("Test_Reset_Button").GetComponent<Button>().onClick.AddListener(() => { data.wipe(); });
    }

    public void continueUpdating()
    {
        initUi();
        player.SetArmor(data.armor_nr);
        player.SetHead(data.head_nr);
    }
	
	// Update is called once per frame
	void Update () {
        initUi();
	}

    public void Train()
    {
        //StartCoroutine(data.Train());
    }

    public void Save()
    {
        //data.Save();
    }

    public void Quit()
    {
        //StartCoroutine(data.Logout());
    }

    void initUiElements()
    {
        name_display = GameObject.Find("UsernameDisplay").GetComponent<Text>();
        level_display = GameObject.Find("LevelDisplay").GetComponent<Text>();
        xp_display = GameObject.Find("XpDisplay").GetComponent<Text>();
        //xp_e_display = GameObject.Find("XpDisplayEnglish").GetComponent<Text>();
        //xp_m_display = GameObject.Find("XpDisplayMath").GetComponent<Text>();
        life_display = GameObject.Find("LifeDisplay").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerCreation>();
    }

    void initUi() {
        name_display.text = data.name;
        level_display.text = "Lvl.:  "+data.level;
        xp_display.text = data.xp + "/" + data.xp_needed + " XP";
        //xp_e_display.text = "Englisch: "+data.getEnglishXp()+" XP";
        //xp_m_display.text = "Mathe: " + data.getMathXp()+" XP";
        life_display.text = data.lifes + " Münzen";
    }

    //public void addXpMath(int addXp){data.addXpMath(addXp);}
    //public void addXpEnglish(int addXp){data.addXpEnglish(addXp);}
    public void resetStats() { data.wipe();  }
}
