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
        e.fetchExercises(data.getLevel(), data.current_dif, data.current_subject, "%1%", data.getClass() );
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) AnswerQuestion();
    }

    public void AnswerQuestion() {
        string answer = e.SubmitQuestion();
        GameObject.Find("Answer_Text").GetComponent<Text>().text = answer;
        GameObject.Find("Submit_Question").GetComponent<Button>().enabled = false;
        GameObject.Find("Submit_Question").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Next_Question").GetComponent<Button>().enabled = true;
    }
    public void NextQuestion()
    {
        GameObject.Find("Answer_Text").GetComponent<Text>().text = "";
        GameObject.Find("Submit_Question").GetComponent<Button>().enabled = true;
        GameObject.Find("Submit_Question").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Next_Question").GetComponent<Button>().enabled = false;
        e.next();
    }
}
