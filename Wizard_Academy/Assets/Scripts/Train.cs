using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Train : MonoBehaviour {

    Exercises e;
    UserData data;

    Text ExerciseCounter;
    Text Question;
    Text Task;
    Text Result;
    InputField AnswerInput;

    string question = "";
    // Use this for initialization
    void Start()
    {
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("NameDisplay").GetComponent<Text>().text = data.getName();
        e = GetComponent<Exercises>();
        e.GetTrainExercises(data.current_subject, data.getClass(), 1, data.getLevel());
    }

    public void Begin()
    {
        e.StartExercise();
        initUi();
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").transform.localScale = new Vector3(0, 0, 0);
    }

    void initUi()
    {
        ExerciseCounter = GameObject.Find("ExerciseCounter").GetComponent<Text>();
        Question = GameObject.Find("Question").GetComponent<Text>();
        Task = GameObject.Find("Task").GetComponent<Text>();
        Result = GameObject.Find("Result").GetComponent<Text>();
        AnswerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        AnswerInput.Select();

        refreshUi();
    }

    void refreshUi()
    {
        ExerciseCounter.text = e.nrExercise + "/" + e.nrExerciseMax;
        Question.text = e.current_question;
        Task.text = e.current_task;
    }

    // Update is called once per frame
    void Update()
    {
        //refreshUi();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameObject.Find("Submit_Question").GetComponent<Button>().enabled){AnswerQuestion();}
            else{NextQuestion();}
        }
    }

    
    public void AnswerQuestion()
    {
        if (AnswerInput.text.Equals(e.current_answer))
        {
            Result.text = "Richtig!";
        }
        else
        {
            Result.text = "Falsch! Richtige Antwort: " + e.current_answer;
        }
        //switch button
        GameObject.Find("Next_Question").GetComponent<Button>().enabled = true;
        GameObject.Find("Next_Question").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Submit_Question").GetComponent<Button>().enabled = false;
        GameObject.Find("Submit_Question").transform.localScale = new Vector3(0, 0, 0);
        refreshUi();
    }

    public void NextQuestion()
    {
        Result.text = "";
        AnswerInput.text = "";
        AnswerInput.Select();
        GameObject.Find("Submit_Question").GetComponent<Button>().enabled = true;
        GameObject.Find("Submit_Question").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Next_Question").GetComponent<Button>().enabled = false;
        GameObject.Find("Next_Question").transform.localScale = new Vector3(0, 0, 0);
        e.NextQuestion();
        refreshUi();
    }
}

