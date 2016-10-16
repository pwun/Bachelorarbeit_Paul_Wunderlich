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
        if(data.getLifes() < 1)
        {
            Coins.color = Color.red;
            GameObject.Find("Start").GetComponent<Button>().interactable = false;
            GameObject.Find("Reminder").transform.localScale= new Vector3(1, 1, 1);
        }
        /* else
         {
             Coins.color = Color.green;
             GameObject.Find("Start").GetComponent<Button>().interactable = true;
             GameObject.Find("Reminder").transform.localScale = new Vector3(0, 0, 0);
         }*/
        Coins.text = "Aktuelle Münzen: " + data.getLifes();

    }

    public void LoadGame()
    {
        data.subLifes(1);
        data.Save();
        data.LogEntry("mini1start");
        SceneManager.LoadScene("Mini1");
    }
}
