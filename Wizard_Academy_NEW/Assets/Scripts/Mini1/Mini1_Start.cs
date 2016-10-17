using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Start : MonoBehaviour {
    UserData data;
    Text Coins;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        Coins = GameObject.Find("Coins").GetComponent<Text>();
        if(data.lifes < 1)
        {
            Coins.color = Color.red;
            GameObject.Find("Start").GetComponent<Button>().interactable = false;
            GameObject.Find("Reminder").transform.localScale= new Vector3(1, 1, 1);
        }
        Coins.text = "Aktuelle Münzen: " + data.lifes;
        GameObject.Find("Start").GetComponent<Button>().onClick.AddListener(() => { data.lifes--;  data.Save("Mini1"); });
    }

    public void LoadGame()
    {
        data.lifes--;
        data.Save("Mini1");
    }
}
