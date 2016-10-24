using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour {

    Exercises e;

    Text ExerciseCounter;
    Text Question;
    Text Task;
    Text Result;
    InputField AnswerInput;

    Button SubmitButton;
    Button NextButton;

    int CorrectCounter;
    int IncorrectCounter;

    bool running = false;

    string question = "";
    // Use this for initialization
    void Start()
    {
        CorrectCounter = 0;
        IncorrectCounter = 0;
        GameObject.Find("NameDisplay").GetComponent<Text>().text = Game.current.hero.Name;
        e = GetComponent<Exercises>();
        e.GetTrainExercises(Game.current.hero.Subject, Game.current.hero.ClassLevel, 1, Game.current.hero.Level);
    }

    public void Begin()
    {
        e.StartExercise();
        initUi();
        GameObject.Find("Start").GetComponent<Button>().enabled = false;
        GameObject.Find("Start").transform.localScale = new Vector3(0, 0, 0);
        running = true;
    }

    void initUi()
    {
        ExerciseCounter = GameObject.Find("ExerciseCounter").GetComponent<Text>();
        Question = GameObject.Find("Question").GetComponent<Text>();
        Task = GameObject.Find("Task").GetComponent<Text>();
        Result = GameObject.Find("Result").GetComponent<Text>();
        AnswerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        SubmitButton = GameObject.Find("Submit_Question").GetComponent<Button>();
        NextButton = GameObject.Find("Next_Question").GetComponent<Button>();
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
        if (running) { refreshUi(); }
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
        NextButton.enabled = true;
        SubmitButton.enabled = false;
        refreshUi();
    }

    public void NextQuestion()
    {
        SubmitButton.enabled = true;
        //GameObject.Find("Submit_Question").transform.localScale = new Vector3(1, 1, 1);
        NextButton.enabled = false;
        //GameObject.Find("Next_Question").transform.localScale = new Vector3(0, 0, 0);
        Result.text = "";
        AnswerInput.text = "";
        AnswerInput.Select();
        if (!e.NextQuestion())
        {
            //End of Test
            if(CorrectCounter+IncorrectCounter != e.nrExerciseMax)
            {
                Debug.Log("Error giving XP: RightAnswers:"+CorrectCounter+" + WrongAnswers:"+IncorrectCounter+" don't add up to NrAnswers:"+e.nrExerciseMax);
            }
            else
            {
                Close();
            }
        }
        else {
            refreshUi();
        }
    }

    void Close()
    {
        AnswerInput.transform.position = new Vector3(-500, -500, -20);
        Destroy(Question);
        Destroy(Task);
        GameObject.Find("Endscreen").transform.position = new Vector3(0,0,1);
        GameObject.Find("EndText").GetComponent<Text>().text = "Du hast " + CorrectCounter + " Fragen von " + e.nrExerciseMax + " richtig beantwortet." + System.Environment.NewLine +
            "Als Belohnung bekommst du " + GetLeveledXp() + " Erfahrungspunkte.";
        GameObject.Find("SaveQuit").GetComponent<Button>().onClick.AddListener(() => { Save(); });
    }

    void Save()
    {
        GameObject.Find("SaveQuit").GetComponent<Button>().interactable = false;
        Game.current.hero.AddXp(GetLeveledXp());
        SaveLoad.Save();
		SceneManager.LoadScene("Main");
    }

    int GetLeveledXp()
    {
        int xp = 0;
        switch (Game.current.hero.Level)
        {
            case 1:
            case 2:
            case 3:
                xp = 50 + CorrectCounter * 5;
                break;
            case 4:
            case 5:
            case 6:
                xp = 50 + CorrectCounter * 15;
                break;
            case 7:
            case 8:
            case 9:
                xp = 50 + CorrectCounter * 25;
                break;
            case 10:
            case 11:
            case 12:
                xp = 50 + CorrectCounter * 30;
                break;
            default:
                Debug.Log("Error XP konnten nicht ermittelt werden: Level nicht gefunden");
                break;
        }
        return xp;
    }
}

