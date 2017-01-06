using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainSettings : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitSettings();
    }

    public void SubmitSettings()
    {
        if (GameObject.Find("Sub_Dropdown").GetComponent<Dropdown>().value == 0)
        {
            Game.current.hero.Subject = "e";
        }
        else
        {
            Game.current.hero.Subject = "m";
        }
        //Change Scene
        SaveLoad.Save();
        SceneManager.LoadScene("Train");
    }
}
