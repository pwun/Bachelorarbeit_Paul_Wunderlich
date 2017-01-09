public class EnglishGenerator{

  string FetchURL = "http://wunderlich-paul.de/wizard/ExerciseInfo.php";
  private string[] items;

  public EnglishGenerator(){}

  public Entry[] GenerateList(int _lvl, int _class){
    List<Entry> Entries = new List<Entry>();
    switch (_class){
      case 6:
      switch(_lvl){
        case 1:
          6_1(Entries);
          break;
        default:
          break;
      }
      case 8:
      switch (_lvl){
        case 1:
          break;
        default:
          break;
      }
      default:
        Debug.Log("Class "+ _class + "does not match any known Classes");
    }
    return Entries.ToArray();
  }

  private void 6_1(List<Entry> Entries){
    //Entries.Add(PickRandom());
  }

  IEnumerator ReadFromDB(string Sub, int Class, int Suits)
  {
    WWWForm form = new WWWForm();
    form.AddField("subPost", Sub);
    form.AddField("classPost", Class);
    form.AddField("suitablePost", Suits);
    form.AddField("keyPost", 1);
    WWW www = new WWW(FetchURL, form);
    yield return www;
    Debug.Log("Answer from Server:" + www.text);
    string DataString = www.text;
    items = DataString.Split(';');
  }
}
