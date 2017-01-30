using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    Text name_display;
    Text level_display;
    Text xp_display;
    Text xp_e_display;
    Text xp_m_display;
    Text life_display;
    List<int> bossLevels = new List<int>();
	// Use this for initialization
	void Start () {
        bossLevels.AddRange(new int[]{ 3,6,9,12});
        SaveLoad.Load();
        Game.current = SaveLoad.savedGames[SaveLoad.savedGames.Count - 1];
        initUiElements();
		GameObject.Find("Save_Button").GetComponent<Button>().onClick.AddListener(() => {
            int answer = -1;
            answer = Log.LogEntry("Logout");
            while (answer < 0)
            { //Wait
            }
            SaveLoad.Save(); SceneManager.LoadScene("Startmenu"); });
        if (Game.current.hero.Xp == Game.current.hero.XpNeeded && bossLevels.Contains(Game.current.hero.Level))
        {
            //Unlock Boss Level
            GameObject.Find("Boss_Button").GetComponent<Button>().interactable = true;
            GameObject.Find("Boss_Button").GetComponent<UnityEngine.UI.Image>().color = Color.green;
        }
        else {
            //Lock Boss Level
            GameObject.Find("Boss_Button").GetComponent<UnityEngine.UI.Image>().color = Color.red;
            GameObject.Find("Boss_Button").GetComponent<Button>().interactable = false;
        }
        GameObject.Find("Train_Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("TrainSetup"); });
        GameObject.Find("FreeTrain_Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("FreeTrainSetup"); });
        GameObject.Find("Mini1_Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("Mini1_Start"); });
        GameObject.Find("Boss_Button").GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene("BossSettings"); });
        GameObject.Find("Test_Cheat_Button").GetComponent<Button>().onClick.AddListener(() => {
            Game.current.hero.AddXp(100);
        });
        GameObject.Find("Test_Cheat_Button2").GetComponent<Button>().onClick.AddListener(() => {
            Game.current.hero.LevelUp();
        });


        GameObject.Find("Test_Reset_Button").GetComponent<Button>().onClick.AddListener(() => { resetStats(); });
        GameObject.Find("EditChar").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Inventory"));
        Log.LogEntry("Menu");
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
