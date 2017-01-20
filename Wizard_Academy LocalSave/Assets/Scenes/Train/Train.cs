﻿using UnityEngine;
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
        else
        {
            e = MathGen.GenerateList(Game.current.hero.ClassLevel, Game.current.hero.Level, 1);
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
        NextButton = GameObject.Find("Next_Question").GetComponent<Button>();
        AnswerInput.Select();
        running = true;
        Debug.Log("Game is running");
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
        if (AnswerInput.text.Equals(e[eNr].answer))
        {
            Result.text = "Richtig!";
            CorrectCounter++;
        }
        else
        {
            Result.text = "Falsch! Richtige Antwort: " + e[eNr].answer;
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
    }
    void Close()
    {
        AnswerInput.transform.position = new Vector3(-500, -500, -20);
        Destroy(Question);
        Destroy(Task);
        GameObject.Find("Endscreen").transform.position = new Vector3(0, 0, 1);
        GameObject.Find("EndText").GetComponent<Text>().text = "Du hast " + CorrectCounter + " Fragen von " + e.Length + " richtig beantwortet." + System.Environment.NewLine +
            "Als Belohnung bekommst du " + GetLeveledXp() + " Erfahrungspunkte.";
        GameObject.Find("SaveQuit").GetComponent<Button>().onClick.AddListener(() => { Save(); });
    }
    void Save()
    {
        Log.LogEntry("train " + GetLeveledXp() + "xp, " + CorrectCounter + "/" + e.Length + " richtig", 0);
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

    public void Begin()
    {
        Destroy(GameObject.Find("Start"));
    }
}
