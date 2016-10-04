using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Header_Script : MonoBehaviour {

    Game_Status status;

    Text name_label;
    Text level_label;
    Text xp_label;

	// Use this for initialization
	void Start () {
        status = GameObject.Find("EventSystem").GetComponent<Game_Status>();

        name_label = GameObject.Find("PlayerName").GetComponent<Text>();
        xp_label = GameObject.Find("PlayerLevel").GetComponent<Text>();
        level_label = GameObject.Find("PlayerXp").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        name_label.text = status.getName();
        level_label.text = "Lvl.:" + status.getLevel();
        xp_label.text = status.getXp() + "/" + status.getNeededXp();
	}
}
