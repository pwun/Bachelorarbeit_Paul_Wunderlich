using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Training_Script : MonoBehaviour {

    string subject = "english";
    int nrExercises = 10;
    int nrExercise = 1;
    string textExercise = "How much is the fish?";
    string answerExercise = "42";

    Text prog;
    Text question;
    GameObject answer;

	// Use this for initialization
	void Start () {
        //Get List of exercises fitting for level and subject
        prog = GameObject.Find("Progress").GetComponent<Text>();
        question = GameObject.Find("Question").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        prog.text = nrExercise + "/" + nrExercises;
        question.text = textExercise;
	}

    public void next()
    {
        //Check if answer s correct

        //Give Feedback

        //Switch to next Question
        if(nrExercise< nrExercises)
        {
            //TODO: Get next Question
            nrExercise++;
            if(nrExercise == nrExercises)
            {
                //Last Question
                //TODO: Change Button to Submit
            }
        }
        else
        {
            Debug.Log("Error Loading Exercises");
            return;
        }
    }
}
