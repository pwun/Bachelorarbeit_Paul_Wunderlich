public class Entry{

  public string task;
  public string question;
  public string answer;
  public string[] answerPos;

  public Entry(string _task, string _question, string _answer, string[] _answerpos){
    task = _task;
    question = _question;
    answer = _answer;
    answerPos = _answerpos;
  }
  public override string ToString(){
		string result = task + "\n" + question + "\nAntwort: " + answer+ "\n\n"; //+ "\nAnswers: " + answerPos[0] + ", " + answerPos[1] + ", " + answerPos[2];
		System.IO.File.AppendAllText(@"/Users/paul/Desktop/ausgabe.txt", result);
		return result;
  }
    public void printToFile(string path)
    {
        string result = task + "\n" + question + "\n\n";
        System.IO.File.AppendAllText(@"C:\Users\Paul\Desktop\ausgabe\" + path, result);
    }
}
