using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Exercises : MonoBehaviour {

    public int nrExercise = 0;
    public int nrExerciseMax = 0;
    public string current_question = "Frage";
    public string current_task = "Task";
    public string current_answer = "Antwort";
    bool ready = false;


    string FetchURL = "http://wunderlich-paul.de/wizard/ExerciseInfo.php";
    public string[] items;
    public string[] exercises;

    public void Start()
    {
        exercises = new string[0];
        ready = false;
    }

    public bool Ready()
    {
        return ready;
    }

    public void StartExercise()
    {
        nrExerciseMax = exercises.Length;
        nrExercise = 1;
        LoadQuestion(1);
    }

    public bool NextQuestion()
    {
        if (nrExercise < nrExerciseMax)
        {
            nrExercise++;
            LoadQuestion(nrExercise);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void LoadQuestion(int i)
    {
        current_question = GetDataValue(exercises[i-1], "question");
        current_task = GetDataValue(exercises[i-1], "task");
        current_answer = GetDataValue(exercises[i-1], "answer");
    }
    
    /*
    HELPER 
    */
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length + 2);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

    List<string> PickRandom(string[] data, int nr)
    {
        List<string> result = new List<string>();
        //if (nr > data.Length) return result;
        List<int> indexes = new List<int>();
        for (int i = 0; i < nr; i++)
        {
            int index = Random.Range(0, data.Length - 1);
            while (indexes.Contains(index))
            {
                index = Random.Range(0, data.Length - 1);
            }
            indexes.Add(index);
            //if clause to prevent empty list entries
            //if (data[index] != null) {
                result.Add(data[index]);
            //}
        }
        return result;
    }
    
    /*
    DATABASE 
    */
    IEnumerator ReadFromDB(string Sub, int Class, int Suits, int Key)
    {
        WWWForm form = new WWWForm();
        form.AddField("subPost", Sub);
        form.AddField("classPost", Class);
        form.AddField("suitablePost", Suits);
        form.AddField("keyPost", Key);
        WWW www = new WWW(FetchURL, form);
        yield return www;
        Debug.Log("Answer from Server:" + www.text);
        string DataString = www.text;
        items = DataString.Split(';');
    }

    public void GetTrainExercises(string Sub, int Class, int Suits, int Lvl)
    {
        switch (Sub)
        {
            case "e":
                switch (Class)
                {
                    case 6:
                        switch (Lvl)
                        {
                            case 1:
                            case 2:
                            case 3:
                                //3x1 4x2 3x3 1x12 1x13
                                StartCoroutine(LoadClass6_1_3(Sub, Class, Suits));
                                break;
                            case 4:
                            case 5:
                            case 6:
                                //2x1 2x2 2x3 4x4 1x12 1x13
                                StartCoroutine(LoadClass6_4_6(Sub, Class, Suits));
                                break;
                            case 7:
                            case 8:
                            case 9:
                                //1x1 3x4 3x5 3x6 2x14
                                StartCoroutine(LoadClass6_7_9(Sub, Class, Suits));
                                break;
                            case 10:
                            case 11:
                            case 12:
                                //1x1 4x4 4x7 3x14
                                StartCoroutine(LoadClass6_10_12(Sub, Class, Suits));
                                break;
                            default:
                                Debug.Log("Error generating questions: Level:"+Lvl+" not found");
                                break;
                        }
                        break;
                    case 8:
                        switch (Lvl)
                        {
                            case 1:
                            case 2:
                            case 3:
                                //1x1 1x2 1x3 2x4 1x5 1x6 2x7 1x12 1x13 1x14
                                StartCoroutine(LoadClass8_1_3(Sub, Class, Suits));
                                break;
                            case 4:
                            case 5:
                            case 6:
                                //1x1 2x4 2x7 1x14 1x8 1x9 2x10 2x11
                                StartCoroutine(LoadClass8_4_6(Sub, Class, Suits));
                                break;
                            case 7:
                            case 8:
                            case 9:
                                //1x1 1x4 1x7 1x10 3x11 3x15 2x17
                                StartCoroutine(LoadClass8_7_9(Sub, Class, Suits));
                                break;
                            case 10:
                            case 11:
                            case 12:
                                //1x1 1x4 1x7 1x10 2x11 3x16 3x17
                                StartCoroutine(LoadClass8_10_12(Sub, Class, Suits));
                                break;
                            default:
                                Debug.Log("Error generating questions: Level:" + Lvl + " not found");
                                break;
                        }
                        break;
                    default:
                        Debug.Log("Error generating questions: Class:" + Class + " not found");
                        break;
                }
                break;
            case "m":
                //Fill with Math Exercise-Coroutines
                break;
            default:
                Debug.Log("Error generating questions: Subject:" + Sub + " not found");
                break;
        }
        
    }
    
    //Class 6 English
    //3x1 4x2 3x3 1x12 1x13
    IEnumerator LoadClass6_1_3(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 2));
        string[] items2 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 3));
        string[] items3 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 12));
        string[] items12 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 13));
        string[] items13 = items;

        List<string> result = PickRandom(items1, 3);
        result.AddRange(PickRandom(items2, 4));
        result.AddRange(PickRandom(items3, 3));
        result.AddRange(PickRandom(items12, 1));
        result.AddRange(PickRandom(items13, 1));

        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for(int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //2x1 2x2 2x3 4x4 1x12 1x13
    IEnumerator LoadClass6_4_6(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 2));
        string[] items2 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 3));
        string[] items3 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 12));
        string[] items12 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 13));
        string[] items13 = items;

        List<string> result = PickRandom(items1, 2);
        result.AddRange(PickRandom(items2, 2));
        result.AddRange(PickRandom(items3, 2));
        result.AddRange(PickRandom(items4, 4));
        result.AddRange(PickRandom(items12, 1));
        result.AddRange(PickRandom(items13, 1));

        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //1x1 3x4 3x5 3x6 2x14
    IEnumerator LoadClass6_7_9(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 5));
        string[] items5 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 6));
        string[] items6 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 14));
        string[] items14 = items;

        List<string> result = PickRandom(items1, 1);
        result.AddRange(PickRandom(items4, 3));
        result.AddRange(PickRandom(items5, 3));
        result.AddRange(PickRandom(items6, 3));
        result.AddRange(PickRandom(items14, 2));

        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //1x1 4x4 4x7 3x14
    IEnumerator LoadClass6_10_12(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 7));
        string[] items7 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 14));
        string[] items14 = items;

        List<string> result = PickRandom(items1, 1);
        result.AddRange(PickRandom(items4, 4));
        result.AddRange(PickRandom(items7, 4));
        result.AddRange(PickRandom(items14, 3));

        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //Class 8 English
    //1x1 1x2 1x3 2x4 1x5 1x6 2x7 1x12 1x13 1x14
    IEnumerator LoadClass8_1_3(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 2));
        string[] items2 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 3));
        string[] items3 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 5));
        string[] items5 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 6));
        string[] items6 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 7));
        string[] items7 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 12));
        string[] items12 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 13));
        string[] items13 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 14));
        string[] items14 = items;

        List<string> result = PickRandom(items1, 1);
        result.AddRange(PickRandom(items2, 1));
        result.AddRange(PickRandom(items3, 1));
        result.AddRange(PickRandom(items4, 2));
        result.AddRange(PickRandom(items5, 1));
        result.AddRange(PickRandom(items6, 1));
        result.AddRange(PickRandom(items7, 2));
        result.AddRange(PickRandom(items12, 1));
        result.AddRange(PickRandom(items13, 1));
        result.AddRange(PickRandom(items14, 1));

        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //1x1 2x4 2x7 1x8 1x9 2x10 2x11 1x14
    IEnumerator LoadClass8_4_6(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 7));
        string[] items7 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 8));
        string[] items8 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 9));
        string[] items9 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 10));
        string[] items10 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 11));
        string[] items11 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 14));
        string[] items14 = items;

        List<string> result = PickRandom(items1, 1);
        result.AddRange(PickRandom(items4, 2));
        result.AddRange(PickRandom(items7, 2));
        result.AddRange(PickRandom(items8, 1));
        result.AddRange(PickRandom(items9, 1));
        result.AddRange(PickRandom(items10, 2));
        result.AddRange(PickRandom(items11, 2));
        result.AddRange(PickRandom(items14, 1));

        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //1x1 1x4 1x7 1x10 3x11 3x15 2x17
    IEnumerator LoadClass8_7_9(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 7));
        string[] items7 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 10));
        string[] items10 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 11));
        string[] items11 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 15));
        string[] items15 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 17));
        string[] items17 = items;

        List<string> result = PickRandom(items1, 1);
        result.AddRange(PickRandom(items4, 1));
        result.AddRange(PickRandom(items7, 1));
        result.AddRange(PickRandom(items10, 1));
        result.AddRange(PickRandom(items11, 3));
        result.AddRange(PickRandom(items15, 3));
        result.AddRange(PickRandom(items17, 2));


        exercises = result.ToArray();
        ready = true;
        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
    //1x1 1x4 1x7 1x10 2x11 3x16 3x17
    IEnumerator LoadClass8_10_12(string Sub, int Class, int Suits)
    {
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 1));
        string[] items1 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 4));
        string[] items4 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 7));
        string[] items7 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 10));
        string[] items10 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 11));
        string[] items11 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 16));
        string[] items16 = items;
        yield return StartCoroutine(ReadFromDB(Sub, Class, Suits, 17));
        string[] items17 = items;

        List<string> result = PickRandom(items1, 1);
        result.AddRange(PickRandom(items4, 1));
        result.AddRange(PickRandom(items7, 1));
        result.AddRange(PickRandom(items10, 1));
        result.AddRange(PickRandom(items11, 2));
        result.AddRange(PickRandom(items16, 3));
        result.AddRange(PickRandom(items17, 3));

        exercises = result.ToArray();

        Debug.Log("Fertige Liste:");
        for (int i = 0; i < exercises.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + exercises[i]);
        }
    }
}