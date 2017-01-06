using UnityEngine;
using System.Collections;

public class Entry {

	public string task;
	public string question;
	public string answer;
    public string[] answers;

	public Entry(string _question, string _answer, string _task, string[] _answers){
		question = _question;
		answer = _answer;
        task = _task;
        answers = _answers;
	}

	public bool CheckAnswer(string _answer){
		return answer.Equals (_answer.Trim());
	}

	public override string ToString(){
		return "Question: " + question + "|\tAnswer: " + answer;
	}
}
