using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//LogFile();

		/*System.IO.File.AppendAllText(@"/Users/paul/Desktop/ausgabe.txt", "Mathe 8. Klasse Lvl 10:\n\n");
		MathGenerator mg = new MathGenerator ();
		Entry[] em = mg.GenerateList (8, 10, 1);
		for (int i = 0; i < em.Length; i++) {
			Debug.Log (em [i].ToString ());
		}*/

		System.IO.File.AppendAllText(@"ausgabe.txt", "Mathe 6. Klasse Lvl 1:\n\n");
		MathGenerator mg = new MathGenerator ();
		Entry[] em = mg.GenerateList (6, 1, 1);
		for (int i = 0; i < em.Length; i++) {
			Debug.Log (em [i].ToString ());
		}
		System.IO.File.AppendAllText(@"ausgabe.txt", "Englisch 6. Klasse Lvl 1:\n\n");
		EnglishGenerator eg = new EnglishGenerator ();
		Entry[] ee = eg.GenerateList (6, 1, 1);
		for (int i = 0; i < ee.Length; i++) {
			Debug.Log (ee [i].ToString ());
		}
	}
}
