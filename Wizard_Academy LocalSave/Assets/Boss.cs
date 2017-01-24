using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
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

    Entry[] e1 = new Entry[0];
    Entry[] e2 = new Entry[0];
    Entry[] e = new Entry[0];

    void Start()
    {
        SaveLoad.Load();
        EnglishGenerator EnglishGen = new EnglishGenerator();
        MathGenerator MathGen = new MathGenerator();
        CorrectCounter = 0;
        IncorrectCounter = 0;
        GameObject.Find("NameDisplay").GetComponent<Text>().text = Game.current.hero.Name;
        e1 = EnglishGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 3);
        e2 = MathGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 3);
        while (e1.Length < 2 || e2.Length < 2)
        {
            //Wait
            Debug.Log("Loading...");
        }
        List<Entry> ePuffer = new List<Entry>();
        ePuffer.AddRange(e1);
        ePuffer.AddRange(e2);
        e = shuffle(ePuffer.ToArray());
        Debug.Log("Done! " + e.Length + " Entries received");
        eNr = 0;
        initUi();
    }

    private Entry[] shuffle(Entry[] arr) {
        //Knuth shuffle algorithm
        for (int i = 0; i < arr.Length; i++)
        {
            Entry tmp = arr[i];
            int r = Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
        return arr;
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
        Log.LogEntry("Boss start");
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
            BossHurt();
        }
        else
        {
            Result.text = "Falsch! Richtige Antwort: " + e[eNr].answer;
            Audio_False.Play();
            IncorrectCounter++;
            PlayerHurt();
        }
        //switch button
        NextButton.enabled = true;
        SubmitButton.enabled = false;
        SubmitButton.transform.localScale = new Vector3(0, 0, 0);
        refreshUi();
        //WICHTIG!!!!!
        //minimize UI
        //Play animation
        //maximize ui
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
    void BossHurt() { }
    void PlayerHurt() { }
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
        GameObject.Find("EndText").GetComponent<Text>().text = "Du hast den Boss besiegt und kannst nun in eine neue Region." + System.Environment.NewLine +
            "Als Belohnung bekommst du ein Item";//GetItem//set text of item
                                                 //Game.current.hero.AddXp(GetLeveledXp());
        //Level up
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

    public void Begin()
    {
        Destroy(GameObject.Find("Start"));
    }
}
