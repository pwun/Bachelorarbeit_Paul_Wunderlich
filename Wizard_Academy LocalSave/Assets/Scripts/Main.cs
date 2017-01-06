using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    UserData data;

    Text name_display;
    Text level_display;
    Text xp_display;
    Text xp_e_display;
    Text xp_m_display;
    Text life_display;
	// Use this for initialization
	void Start () {
        SaveLoad.Load();
        Game.current = SaveLoad.savedGames[SaveLoad.savedGames.Count - 1];
        initUiElements();
		GameObject.Find("Save_Button").GetComponent<Button>().onClick.AddListener(() => { SaveLoad.Save(); SceneManager.LoadScene("Startmenu"); });
        GameObject.Find("Train_Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("TrainSetup"); });
        GameObject.Find("Mini1_Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("Mini1_Start"); });
        GameObject.Find("Test_Cheat_Button").GetComponent<Button>().onClick.AddListener(() => { Game.current.hero.AddXp(100); });
        GameObject.Find("Test_Reset_Button").GetComponent<Button>().onClick.AddListener(() => { resetStats(); });
        GameObject.Find("EditChar").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Customizer"));
    }

    void Update()
    {
        initUi();
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
        name_display.text = Game.current.hero.Name;
        level_display.text = "Lvl.:  " + Game.current.hero.Level;
        xp_display.text = Game.current.hero.Xp + "/" + Game.current.hero.XpNeeded + " XP";
        //xp_e_display.text = "Englisch: "+data.getEnglishXp()+" XP";
        //xp_m_display.text = "Mathe: " + data.getMathXp()+" XP";
        life_display.text = Game.current.hero.Coins + " Münzen";
    }

    //public void addXpMath(int addXp){data.addXpMath(addXp);}
    //public void addXpEnglish(int addXp){data.addXpEnglish(addXp);}
    public void resetStats() { SceneManager.LoadScene("Signup"); }//{ Game.current.hero = new Character(Game.current.hero.Name, Game.current.hero.ClassLevel); }
}
