using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour {

    public string StoryMode;

	// Use this for initialization
	void Start () {
        GameObject.Find("Button_Dismiss").GetComponent<Button>().onClick.AddListener(() => { Destroy(GameObject.Find("StoryPanel")); });
        string title = "";
        string text = "";

        switch (StoryMode) {
            case "start":
                title = "Willkommen!";
                text = "Hier kommt ein Einführungstext in die Geschichte hin!";
                break;
            default:
                break;
        }

        GameObject.Find("StoryTitle").GetComponent<Text>().text = title;
        GameObject.Find("StoryText").GetComponent<Text>().text = text;
    }

}
