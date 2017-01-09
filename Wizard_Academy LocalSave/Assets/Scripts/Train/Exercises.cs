public class Exercises{

  private Entries[] eList;
  public int correctCounter;
  public int nrExercises;
  public int current;

  public Exercises(string _sub, int _lvl, int _class){
    if(_sub.Equals("m")){
      MathGenerator mGen = new MathGenerator();
      eList = mGen.GenerateList(_lvl, _class);
    }else if(_sub.Equals("e")){
      EnglishGenerator eGen = new EnglishGenerator();
      eList = eGen.GenerateList(_lvl, _class);
    }
    correctCounter = 0;
    nrExercises = eList.Length();
    current = 0;
  }
  public string GetTask(){return eList[current].task;}
  public string GetQuestion(){return eList[current].question;}
  public string GetAnswer(int _i){return eList[current].answers[_i];}
  public string GetRightAnswer(){return eList[current].answer;}
  public bool Answer(string _answer){
    if(eList[current].answer.Equals(_answer.Trim())){
      Next();
      correctCounter++;
      return true;
    }else{
      Next();
      return false;
    }
  }
  private void Next(){
    if(current < nrExercises){current ++;}
  }
}
