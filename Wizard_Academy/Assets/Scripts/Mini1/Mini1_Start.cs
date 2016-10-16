using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Start : MonoBehaviour {
    UserData data;
    Text Coins;
    Log log;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        log = GameObject.Find("Log").GetComponent<Log>();
        Coins = GameObject.Find("Coins").GetComponent<Text>();
        Coins.text = "Aktuelle Münzen: "+data.getLifes();
	}
	
    public void LoadGame()
    {
        data.subLifes(1);
        data.Save();
        log.LogEntry("mini1start");
        SceneManager.LoadScene("Mini1");
    }
}
