﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mini1_Exercises : MonoBehaviour {

    string FetchURL = "http://wunderlich-paul.de/wizard/ExerciseInfo2.php";
    public string[] items;
    public int nrExercise;
    public Text nrCounter;
    public Text questionText;
    public InputField answerInput;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    //data.getLevel(), data.current_dif, data.current_subject, "%1%", data.getClass()

    public void fetchExercises(int lvl, int dif, string sub, string mode, int classLevel)
    {
        StartCoroutine(ReadFromDB(lvl, dif, sub, mode, classLevel));
    }

    IEnumerator ReadFromDB(int lvl, int dif, string sub, string mode, int classLevel)
    {
        //$sql = "SELECT * FROM `exercises2` WHERE `suitable_for` LIKE '%1%' AND `class` LIKE '%6%' AND `lvl_min` <= 2 AND `lvl_max` >= 2 AND `dif` = 1 AND `subject` = 'e'"

        //sub = "'" + sub + "'";
        string classString = "%" + classLevel + "%";

        WWWForm form = new WWWForm();
        form.AddField("lvl_Post", lvl);
        form.AddField("dif_Post", dif);
        form.AddField("sub_Post", sub);
        form.AddField("suitable_Post", mode);
        form.AddField("class_Post", classString);
        WWW www = new WWW(FetchURL, form);
        yield return www;
        Debug.Log("Answer from Server:" + www.text);
        string DataString = www.text.Split('<')[0];
        items = DataString.Split(';');
        startTrainExercises();
    }

    void startTrainExercises()
    {
        questionText = GameObject.Find("Question").GetComponent<Text>();
        answerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        nrCounter = GameObject.Find("ExerciseCounter").GetComponent<Text>();
        nrExercise = 0;

        LoadQuestion(nrExercise);
    }

    void LoadQuestion(int i)
    {
        questionText.text = GetDataValue(items[i], "'question'");
        nrCounter.text = (i + 1) + "/" + (items.Length - 1);
        answerInput.text = "";
        answerInput.Select();
    }

    public string SubmitQuestion()
    {
        string return_statement;
        string answer = answerInput.text;
        if (answer.Equals(GetDataValue(items[nrExercise], "'answer'")))
        {
            Debug.Log("Richtige Antwort, nächste Frage");
            return_statement = "Richtig!<br>" + GetDataValue(items[nrExercise], "'answer'");
        }
        else
        {
            Debug.Log("Falsche Antwort");
            return_statement = "Falsch!<br>Richtige Antwort:" + GetDataValue(items[nrExercise], "'answer'");
        }
        return return_statement;
    }

    public void next()
    {
        nrExercise++;
        if (nrExercise < items.Length - 1)
        {
            LoadQuestion(nrExercise);
        }
        else
        {
            Debug.Log("Last Question");
            //Save XP
            SceneManager.LoadScene("Main");
        }
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length + 1);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

}