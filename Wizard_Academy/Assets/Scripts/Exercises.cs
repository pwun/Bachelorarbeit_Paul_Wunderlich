using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exercises : MonoBehaviour {

    string FetchURL = "localhost/wizard_academy/ExerciseInfo.php";
    public string[] items;
    public int nrExercise;
    public Text questionText;
    public InputField answerInput;
    // Use this for initialization
    void Start()
    {
        fetchExercises();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fetchExercises()
    {
        StartCoroutine(ReadFromDB());
    }

    IEnumerator ReadFromDB()
    {
        //WWWForm form = new WWWForm();
        //form.AddField("usernamePost", username);
        //WWW www = new WWW(LoginURL, form);
        WWW www = new WWW(FetchURL);
        yield return www;
        Debug.Log("Answer from Server:" + www.text);
        string DataString = www.text;
        items = DataString.Split(';');
        startExercises();
    }

    void startExercises()
    {
        questionText = GameObject.Find("Question").GetComponent<Text>();
        answerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        nrExercise = 0;

        LoadQuestion(nrExercise);
    }

    void LoadQuestion(int i)
    {
        questionText.text = GetDataValue(items[i], "'question'");
        answerInput.Select();
    }

    public void SubmitQuestion()
    {
        string answer = answerInput.text;
        if (answer.Equals(GetDataValue(items[nrExercise], "'answer'")))
        {
            Debug.Log("Richtige Antwort, nächste Frage");
        }
        else
        {
            Debug.Log("Falsche Antwort");
        }
        nrExercise++;
        LoadQuestion(nrExercise);
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
