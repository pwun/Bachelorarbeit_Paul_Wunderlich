using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour
{
    Text ExerciseCounter;
    Text Question;
    Text Task;
    Text Result;
    InputField AnswerInput;

    public AudioSource Audio_False;
    public AudioSource Audio_NextPage;

    Button SubmitButton;
    Button NextButton;

    int CorrectCounter;
    int IncorrectCounter;
    int eNr;

    bool running = false;

    Entry[] e = new Entry[0];

    void Start()
    {
        SaveLoad.Load();
        EnglishGenerator EnglishGen = new EnglishGenerator();
        MathGenerator MathGen = new MathGenerator();
        CorrectCounter = 0;
        IncorrectCounter = 0;
        GameObject.Find("NameDisplay").GetComponent<Text>().text = Game.current.hero.Name;
        if (Game.current.hero.Subject.Equals("e"))
        {
            e = EnglishGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 1);
        }
        else if (Game.current.hero.Subject.Equals("m"))
        {
            e = MathGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 1);
        }
        else if (Game.current.hero.Subject.Equals("f")) {
            e = MathGen.GenerateList(Game.current.hero.TrainTask);
        }
        while (e.Length < 2)
        {
            //Wait
            Debug.Log("Loading...");
        }
        Debug.Log("Done! "+e.Length+" Entries received");
        eNr = 0;
        initUi();
    }
    void initUi()
    {
        ExerciseCounter = GameObject.Find("ExerciseCounter").GetComponent<Text>();
        Question = GameObject.Find("Question").GetComponent<Text>();
        Task = GameObject.Find("Task").GetComponent<Text>();
        Result = GameObject.Find("Result").GetComponent<Text>();
        AnswerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        SubmitButton = GameObject.Find("Submit_Question").GetComponent<Button>();
        SubmitButton.onClick.AddListener(() => {
            AnswerQuestion();
        });
        NextButton = GameObject.Find("Next_Question").GetComponent<Button>();
        NextButton.onClick.AddListener(() => {
            NextQuestion();
        });
        AnswerInput.Select();
        running = true;
        Debug.Log("Game is running");
        Log.LogEntry("Train start");
        refreshUi();
    }
    void refreshUi()
    {
        ExerciseCounter.text = (eNr + 1) + "/" + e.Length;
        Question.text = e[eNr].question;
        Task.text = e[eNr].task;
    }
    void Update()
    {
        if (running) { refreshUi(); }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameObject.Find("Submit_Question").GetComponent<Button>().enabled) { AnswerQuestion(); }
            else { NextQuestion(); }
        }
    }
    public void AnswerQuestion()
    {
        //Leerzeichen weg, , durch .
        string r1 = AnswerInput.text;
        string r2 = e[eNr].answer;
        
        r1 = r1.Replace(" ", "");
        r1 = r1.Replace(',', '.');
        r1 = r1.Replace("+", "");
        r1 = r1.Replace("*", "");
        if (r1.StartsWith("1x")) { r1 = r1.Replace("1x", "x"); }
        r2 = r2.Replace(" ", "");
        r2 = r2.Replace(',', '.');
        r2 = r2.Replace("+", "");
        r2 = r2.Replace("*", "");
        if (r2.StartsWith("1x")) { r2 = r2.Replace("1x", "x"); }
        if (r1.Equals(r2))
        {
            Result.text = "Richtig!";
            CorrectCounter++;
        }
        else
        {
            Result.text = "Falsch! Richtige Antwort: " + e[eNr].answer;
            Audio_False.Play();
            IncorrectCounter++;
        }
        //switch button
        NextButton.enabled = true;
        SubmitButton.enabled = false;
        SubmitButton.transform.localScale = new Vector3(0, 0, 0);
        refreshUi();
    }
    public void NextQuestion()
    {
        Audio_NextPage.Play();
        SubmitButton.enabled = true;
        NextButton.enabled = false;
        Result.text = "";
        AnswerInput.text = "";
        AnswerInput.Select();
        if (eNr + 1 >= e.Length)
        {
            //End of Test
            if (CorrectCounter + IncorrectCounter != e.Length)
            {
                Debug.Log("Error giving XP: RightAnswers:" + CorrectCounter + " + WrongAnswers:" + IncorrectCounter + " don't add up to NrAnswers:" + e.Length);
            }
            else
            {
                Close();
            }
        }
        else
        {
            eNr++;
            refreshUi();
        }
        SubmitButton.transform.localScale = new Vector3(1, 1, 1);
    }
    void Close()
    {
        AnswerInput.transform.position = new Vector3(-500, -500, -20);
        Destroy(Question);
        Destroy(Task);
        GameObject.Find("Endscreen").transform.position = new Vector3(0, 0, 1);
        GameObject.Find("EndText").GetComponent<Text>().text = "Du hast " + CorrectCounter + " Fragen von " + e.Length + " richtig beantwortet." + System.Environment.NewLine +
            "Als Belohnung bekommst du " + GetLeveledXp() + " Erfahrungspunkte.";
        Game.current.hero.AddXp(GetLeveledXp());
        SaveLoad.Save();
        int answer = -1;
        answer = Log.LogEntry("Train " + GetLeveledXp() + "xp, " + CorrectCounter + "/" + e.Length + " richtig");
        while (answer < 0)
        { //Wait
        }
        GameObject.Find("SaveQuit").GetComponent<Button>().onClick.AddListener(() => { Save(); });
    }
    void Save()
    {
        GameObject.Find("SaveQuit").GetComponent<Button>().interactable = false;
        SceneManager.LoadScene("Main");
    }
    int GetLeveledXp()
    {
        int xp = 0;
        if (Game.current.hero.Subject.Equals("f")) {
            return CorrectCounter*2;
        }
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

    /*public void Begin()
    {
        Destroy(GameObject.Find("Start"));
    }*/
}
