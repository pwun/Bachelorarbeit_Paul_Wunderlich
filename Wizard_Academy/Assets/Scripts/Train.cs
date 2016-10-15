using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour {

    Exercises e;
    UserData data;

    Text ExerciseCounter;
    Text Question;
    Text Task;
    Text Result;
    InputField AnswerInput;

    int CorrectCounter;
    int IncorrectCounter;

    string question = "";
    // Use this for initialization
    void Start()
    {
        CorrectCounter = 0;
        IncorrectCounter = 0;
        data = GameObject.Find("User_Data").GetComponent<UserData>();
        GameObject.Find("NameDisplay").GetComponent<Text>().text = data.getName();
        e = GetComponent<Exercises>();
        e.GetTrainExercises(data.current_subject, data.getClass(), 1, data.getLevel());
        //Use Start Button as Loading Indicator
        /*Button startButton = GameObject.Find("Start").GetComponent<Button>();
        while (e.Ready())
        {
            startButton.interactable = false;
        }
        startButton.interactable = true;*/
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
            CorrectCounter++;
        }
        else
        {
            Result.text = "Falsch! Richtige Antwort: " + e.current_answer;
            IncorrectCounter++;
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
        if (!e.NextQuestion())
        {
            //End of Test
            if(CorrectCounter+IncorrectCounter != e.nrExerciseMax)
            {
                Debug.Log("Error giving XP: RightAnswers:"+CorrectCounter+" + WrongAnswers:"+IncorrectCounter+" don't add up to NrAnswers:"+e.nrExerciseMax);
            }
            else
            {
                StartCoroutine(Close());
            }
        }
        else {
            refreshUi();
        }
    }

    IEnumerator Close()
    {
        int xp = 50 + CorrectCounter * 5;
        string answer = "";
        if (data.current_subject.Equals("e"))
        {
            data.addXpEnglish(xp);
            GetComponent<Save>().UpdateDB();
            Debug.Log("Added EnglishXp:" + xp);
            answer = "e:" + xp;
        }
        else if (data.current_subject.Equals("m"))
        {
            data.addXpMath(xp);
            GetComponent<Save>().UpdateDB();
            Debug.Log("Added MathXp:" + xp);
            answer = "m:" + xp;
        }
        else
        {
            Debug.Log("Error giving XP: Subject:" + data.current_subject + " not found");
            answer = "error";
        }
        GameObject.Find("Log").GetComponent<Log>().LogEntry("train");
        yield return answer;
        SceneManager.LoadScene("Main");
    }
}

