using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishGenerator {
	
	string FetchURL = "http://wunderlich-paul.de/wizard/ExerciseInfo.php";

	public EnglishGenerator(){}

	public Entry[] GenerateList(int _class, int _lvl, int _type){
		List<Entry> e = new List<Entry> ();
		/* Generate List according to Generation Rules
		*/
		switch (_class) {
		case 6:
			//class 6
			switch(_type){
			case 1:
				//typ 1: train
				switch(_lvl){
				case 1:
				case 2:
				case 3:
					//lvl 1-3
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,2),4));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,3),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,12),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,13),1));
					break;
				case 4:
				case 5:
				case 6:
					//lvl 4-6
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,2),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,3),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),4));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,12),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,13),1));
					break;
				case 7:
				case 8:
				case 9:
					//lvl 7-9
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,5),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,6),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,14),2));
					break;
				case 10:
				case 11:
				case 12:
					//lvl 10-12
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),4));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,7),4));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,14),3));
					break;
				default:
					//default lvl
					break;
				}
				break;
			case 2:
				//typ 2: mini1
				break;
			default:
				//default type
				break;
			}
			break;
		case 8:
			//class 8
			switch(_type){
			case 1:
				//typ 1: train
				switch(_lvl){
				case 1:
				case 2:
				case 3:
					//lvl 1-3
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,2),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,3),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,5),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,6),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,7),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,12),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,13),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,14),1));
					break;
				case 4:
				case 5:
				case 6:
					//lvl 4-6
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,7),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,8),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,9),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,10),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,11),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,14),1));
					break;
				case 7:
				case 8:
				case 9:
					//lvl 7-9
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,7),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,10),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,11),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,15),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,17),2));
					break;
				case 10:
				case 11:
				case 12:
					//lvl 10-12
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,1),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,4),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,7),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,10),1));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,11),2));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,16),3));
					e.AddRange(PickRandom(ReadFromDB("e",_class,_type,17),3));
					break;
				default:
					//default lvl
					break;
				}
				break;
			case 2:
				//typ 2: mini1
				break;
			default:
				//default type
				break;
			}
			break;
		default:
			//default class
			break;
		}

		return e.ToArray();
	}

	private Entry[] ReadFromDB(string Sub, int Class, int Suits, int Key)
	{
		List<Entry> e = new List<Entry> ();
		WWWForm form = new WWWForm();
		form.AddField("subPost", Sub);
		form.AddField("classPost", Class);
		form.AddField("suitablePost", Suits);
		form.AddField("keyPost", Key);
		WWW www = new WWW(FetchURL, form);
		while (!www.isDone) {
			//Loading Screen
		}
		//Debug.Log("WWWText:" + www.text);
		string DataString = www.text;
		string[] items = DataString.Split(';');
		for (int i = 0; i < items.Length-1; i++) {
			string task = GetDataValue (items [i], "task");
			string question = GetDataValue (items [i], "question");
			string answer = GetDataValue (items [i], "answer");
			string[] answerPos = GetDataValue(items[i], "answer_pos").Split(',');
			if (answerPos.Length > 2) {
				answerPos[0] = answerPos[0].Replace('{', ' ').Replace(" ", "");
				answerPos[1] = answerPos[1].Replace(" ", "");
				answerPos[2] = answerPos[2].Replace('}', ' ').Replace(" ", "");
			}
			Entry entry = new Entry (task, question, answer, answerPos);
			e.Add (entry);
		}
		return e.ToArray ();
	}

	string GetDataValue(string data, string index)
	{
		string value = data.Substring(data.IndexOf(index) + index.Length + 2);
		if (value.Contains("|"))
		{
			value = value.Remove(value.IndexOf("|"));
		}
		return value;
	}

	List<Entry> PickRandom(Entry[] data, int nr)
	{
		List<Entry> result = new List<Entry>();
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
}
