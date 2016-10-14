using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Exercises : MonoBehaviour {

    string FetchURL = "http://wunderlich-paul.de/wizard/ExerciseInfo.php";
    public string[] items;

    void fetchExercises(string Sub, int Class, int Suits, int Key)
    {
        StartCoroutine(ReadFromDB(Sub, Class, Suits, Key));
    }

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
        string DataString = www.text;//.Split('<')[0];
        items = DataString.Split(';');
    }

    public void getTrainExercises(string Sub, int Class, int Suits, int Lvl)
    {
        switch (Class)
        {
            case 6:
                switch (Lvl)
                {
                    case 1:
                    case 2:
                    case 3:
                        //3x1 4x2 3x3 1x12 1x13
                        StartCoroutine(LoadClass6_1_3(Sub,Class,Suits));
                        break;
                    case 4:
                    case 5:
                    case 6:
                        //do sth
                        break;
                    case 7:
                    case 8:
                    case 9:
                        //do sth
                        break;
                    case 10:
                    case 11:
                    case 12:
                        //do sth
                        break;
                    default:
                        break;
                }
                break;
            case 8:
                switch (Lvl)
                {
                    case 1:
                    case 2:
                    case 3:
                        //
                        break;
                    case 4:
                    case 5:
                    case 6:
                        //do sth
                        break;
                    case 7:
                    case 8:
                    case 9:
                        //do sth
                        break;
                    case 10:
                    case 11:
                    case 12:
                        //do sth
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
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

        items = result.ToArray();
        Debug.Log("Fertige Liste:");
        for(int i = 0; i < items.Length; i++)
        {
            Debug.Log("Fertig" + i + ": " + items[i]);
        }
    }

    List<string> PickRandom(string[] data, int nr)
    {
        List<string> result = new List<string>();
        //if (nr > data.Length) return result;
        List<int> indexes = new List<int>();
        for (int i = 0; i < nr; i++)
        {
            int index = Random.Range(0, data.Length);
            while (indexes.Contains(index))
            {
                index = Random.Range(0, data.Length);
            }
            indexes.Add(index);
            result.Add(data[index]);
        }
        return result;
    }
}