using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GleichungsGen{
	//Uses 2 Term-Class Objects to represent a "Gleichung"
	Term left;
	Term right;
	public GleichungsGen(){}

	// Returns an Entry of "Gleichung"
	public Entry GetEntry(){
		left = new Term (0, 1, 0, 1);
		right = new Term (0, 0, Random.Range (1, 10), 1);
		string answer = ToString ();
		ApplyChanges ();
		string question = ToString();
		return new Entry ("Vereinfache folgende Gleichung soweit wie möglich:", question, answer, new string[3]);
	}

	//Basic Changes to Generate a more difficult "Gleichung"
	private void ApplyChanges(){
		float x = (float)System.Math.Round(Random.Range (-10f, 10f),0);
		left.Add (1, x);
		right.Add (1, x);
		x = (float)System.Math.Round(Random.Range (-10f, 10f),0);
		left.Add (2, x);
		right.Add (2, x);
		x = (float)System.Math.Round(Random.Range (1f, 3f),0);
		left.Multiply (x);
		right.Multiply (x);
		x = (float)System.Math.Round(Random.Range (1f, 3f),0);
		left.Faktor (x);
	}

	//returns formatted string
	public override string ToString ()
	{
		return left.ToString () + " = " + right.ToString ();
	}

}
