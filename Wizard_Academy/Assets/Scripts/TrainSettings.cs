using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainSettings : MonoBehaviour {

    UserData data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) SubmitSettings();
    }

    public void SubmitSettings()
    {
        if (GameObject.Find("Sub_Dropdown").GetComponent<Dropdown>().value == 0)
        {
            data.current_subject = "e";
        }
        else
        {
            data.current_subject = "m";
        }
        //Change Scene
        SceneManager.LoadScene("Train");
    }
}
