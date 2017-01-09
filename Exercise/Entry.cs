public class Entry{

  public string task;
  public string question;
  public string answer;
  public string[] answers;

  public Entry(string _task, string _question, string _answer, string[] _answers){
    task = _task;
    question = _question;
    answer = _answer;
    answers = _answers;
  }

  public override string ToString(){
  return "Question: " + question + "\t|\tAnswer: " + answer;
}
}
