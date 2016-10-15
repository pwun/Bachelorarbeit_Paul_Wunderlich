using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1 : MonoBehaviour {

    Exercises e;
    UserData data;

    Text Question;
    Text Answer1;
    Text Answer2;
    Text Answer3;
    Rigidbody Answers;

    Vector3 left;
    float speed = 40.0f;


    int CorrectCounter;
    int IncorrectCounter;

    // Use this for initialization
    void Start () {
        left = new Vector3(-1, 0, 0);

        data = GameObject.Find("User_Data").GetComponent<UserData>();
        e = GetComponent<Exercises>();
        e.GetTrainExercises("e", data.getClass(), 2, data.getLevel());

        Question = GameObject.Find("Question").GetComponent<Text>();
        Answer1 = GameObject.Find("Answer1").GetComponent<Text>();
        Answer2 = GameObject.Find("Answer2").GetComponent<Text>();
        Answer3 = GameObject.Find("Answer3").GetComponent<Text>();
        Answers = GameObject.Find("Answers").GetComponent<Rigidbody>();

        CorrectCounter = 0;
        IncorrectCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Begin() {
        e.StartExercise();
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").transform.localScale = new Vector3(0, 0, 0);
        updateUi();
    }

    void updateUi()
    {
        Question.text = e.current_question;
        Answer1.text = e.current_answer1;
        Answer2.text = e.current_answer2;
        Answer3.text = e.current_answer3;
        Answers.velocity = left * speed;
    }
}
