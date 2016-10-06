using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Train : MonoBehaviour {

    Exercises e;
    UserData data;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("NameDisplay").GetComponent<Text>().text = data.getName();
        e = GetComponent<Exercises>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) AnswerQuestion();
    }

    void AnswerQuestion() {
        e.SubmitQuestion();
    }
}
