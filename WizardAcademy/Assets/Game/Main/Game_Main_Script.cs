using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_Main_Script : MonoBehaviour {

    Text name;
    Slider xp;
    Slider math_xp;
    Slider english_xp;
    Text level;
	// Use this for initialization
	void Start () {
        Debug.Log("Main Script running");
        Game_Status status = GameObject.Find("Game_Status").GetComponent<Game_Status>();
        name = GameObject.Find("Name").GetComponent<Text>();
        level = GameObject.Find("Level").GetComponent<Text>();
        xp = GameObject.Find("XP Slider").GetComponent<Slider>();
        math_xp = GameObject.Find("Math Slider").GetComponent<Slider>();
        english_xp = GameObject.Find("English Slider").GetComponent<Slider>();

        name.text = status.getName();
        level.text = "Lvl.: " + status.getLevel();
        xp.maxValue = status.getNeededXp();
        xp.value = status.getXp();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
