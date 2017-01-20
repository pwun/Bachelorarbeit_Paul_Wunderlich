using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Start : MonoBehaviour {
    Text Coins;
	// Use this for initialization
	void Start () {
        Coins = GameObject.Find("Coins").GetComponent<Text>();
        if(Game.current.hero.Coins < 1)
        {
            Coins.color = Color.red;
            GameObject.Find("Start").GetComponent<Button>().interactable = false;
            GameObject.Find("Reminder").transform.localScale= new Vector3(1, 1, 1);
        }
        Coins.text = "Aktuelle Münzen: " + Game.current.hero.Coins;
        GameObject.Find("Start").GetComponent<Button>().onClick.AddListener(() => { LoadGame(); });
    }

    public void LoadGame()
    {
        Dropdown dd = (Dropdown)GameObject.Find("Dropdown").GetComponent<Dropdown>();
        if (dd.value == 0)
        {
            Game.current.hero.Subject = "e";
        }
        else
        {
            Game.current.hero.Subject = "m";
        }
        Game.current.hero.Coins--;
        SaveLoad.Save();
        SceneManager.LoadScene("Mini1");
    }
}
