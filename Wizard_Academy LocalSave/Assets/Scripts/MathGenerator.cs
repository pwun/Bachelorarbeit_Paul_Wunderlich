using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathGenerator {

    string round = "(Runde auf 2 Nachkommastellen, auch wenn diese Null sind)";
    string potenzTask = "Löse nach den Potenzgesetzen auf. (gib das Ergebnis in folgender Form an: Basis^Exponent)";

    public MathGenerator(){	}

    public Entry[] GenerateList(int _type)
    {
        List<Entry> e = new List<Entry>();
        switch (_type) {
            case 0:
                for (int i = 0; i < 10; i++) { e.Add(Einmaleins('n')); }
                break;
            case 1:
                for (int i = 0; i < 10; i++) { e.Add(Einmaleins('z')); }
                break;
            case 2:
                for (int i = 0; i < 10; i++) { e.Add(AddSub('n')); }
                break;
            case 3:
                for (int i = 0; i < 10; i++) { e.Add(AddSub('z')); }
                break;
            case 4:
                for (int i = 0; i < 10; i++) { e.Add(AddSub('q')); }
                break;
            case 5:
                for (int i = 0; i < 10; i++) { e.Add(MulDiv('n')); }
                break;
            case 6:
                for (int i = 0; i < 10; i++) { e.Add(MulDiv('Q')); }
                break;
            case 7:
                for (int i = 0; i < 10; i++) { e.Add(MulDiv('q')); }
                break;
            case 8:
                for (int i = 0; i < 10; i++) { e.Add(Feeling('z')); }
                break;
            case 9:
                for (int i = 0; i < 10; i++) { e.Add(Feeling('q')); }
                break;
            case 10:
                for (int i = 0; i < 10; i++) { e.Add(Runden()); }
                break;
            case 11:
                for (int i = 0; i < 10; i++) { e.Add(ErweiternKürzen()); }
                break;
            case 12:
                for (int i = 0; i < 10; i++) { e.Add(BruchZuDezimal()); }
                break;
            case 13:
                for (int i = 0; i < 10; i++) { e.Add(BruchteilVonZahl()); }
                break;
            case 14:
                for (int i = 0; i < 10; i++) { e.Add(Potenzen()); }
                break;
            case 15:
                for (int i = 0; i < 10; i++) { e.Add(AddBruch()); }
                break;
            case 16:
                for (int i = 0; i < 10; i++) { e.Add(SubBruch()); }
                break;
            case 17:
                for (int i = 0; i < 10; i++) { e.Add(MulBruch()); }
                break;
            case 18:
                for (int i = 0; i < 10; i++) { e.Add(DivBruch()); }
                break;
            case 19:
                for (int i = 0; i < 10; i++) { e.Add(AddSubMulDivPotenz()); }
                break;
            case 20:
                for (int i = 0; i < 10; i++) { e.Add(Extremwert()); }
                break;
            case 21:
                for (int i = 0; i < 10; i++) { e.Add(Gleichung()); }
                break;
            case 22:
                for (int i = 0; i < 10; i++) { e.Add(Maßeinheit(1)); }
                break;
            case 23:
                for (int i = 0; i < 10; i++) { e.Add(Maßeinheit(2)); }
                break;
            case 24:
                for (int i = 0; i < 10; i++) { e.Add(Maßeinheit(3)); }
                break;
            case 25:
                for (int i = 0; i < 10; i++) { e.Add(Trigonometrie()); }
                break;
            case 26:
                for (int i = 0; i < 10; i++) { e.Add(Binom()); }
                break;
        }

        return e.ToArray();
    }


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
					e.Add (AddSub ('n'));
					e.Add (AddSub ('n'));
					e.Add (AddSub ('n'));
					e.Add (Einmaleins ('n'));
					e.Add (Einmaleins ('n'));
					e.Add (Einmaleins ('n'));
					e.Add (MulDiv ('n'));
					e.Add (MulDiv ('n'));
					e.Add (MulDiv ('n'));
					e.Add (Maßeinheit (0));
					e.Add (Maßeinheit (0));
					e.Add (Feeling ('z'));
					break;
				case 4:
				case 5:
				case 6:
					//lvl 4-6
					e.Add (AddSub ('z'));
					e.Add (AddSub ('z'));
					e.Add (Einmaleins ('z'));
					e.Add (Einmaleins ('z'));
					e.Add (MulDiv ('Q'));
					e.Add (MulDiv ('Q'));
					e.Add (MulDiv ('Q'));
                    e.Add(Runden());
                    e.Add(Runden());
                    e.Add (Maßeinheit (1));
					e.Add (Maßeinheit (1));
					e.Add (Feeling ('q'));
					break;
				case 7:
				case 8:
				case 9:
					//lvl 7-9
					e.Add (AddSub ('q'));
					e.Add (AddSub ('q'));
					e.Add (Einmaleins ('z'));
					e.Add (Einmaleins ('z'));
					e.Add (MulDiv ('Q'));
					e.Add (MulDiv ('Q'));
                    e.Add(Runden());
                    e.Add (Maßeinheit (4));
					e.Add (Maßeinheit (4));
					e.Add (ErweiternKürzen ());
					e.Add (ErweiternKürzen ());
					e.Add (Potenzen ());
					break;
				case 10:
				case 11:
				case 12:
					//lvl 10-12
					e.Add (AddSub ('q'));
					e.Add (MulDiv ('Q'));
					e.Add (MulDiv ('Q'));
					e.Add (Maßeinheit (4));
					e.Add (Maßeinheit (2));
					e.Add (Maßeinheit (2));
					e.Add (ErweiternKürzen ());
					e.Add (ErweiternKürzen ());
					e.Add (Potenzen ());
					e.Add (Potenzen ());
					e.Add (BruchZuDezimal ());
					e.Add (BruchteilVonZahl ());
					break;
				default:
					//default lvl
					break;
				}
				break;
			case 2:
                //typ 2: mini1
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
                e.Add(Einmaleins('n'));
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
					e.Add (AddSub ('q'));
					e.Add (AddSub ('q'));
					e.Add (MulDiv ('q'));
					e.Add (MulDiv ('q'));
					e.Add (BruchZuDezimal ());
					e.Add (BruchZuDezimal ());
					e.Add (AddSubMulDivBruch ());
					e.Add (AddSubMulDivBruch ());
					e.Add (AddSubMulDivPotenz ());
					e.Add (AddSubMulDivPotenz ());
					e.Add (Maßeinheit (2));
					e.Add (Maßeinheit (3));
					break;
				case 4:
				case 5:
				case 6:
					//lvl 4-6
					e.Add (BruchZuDezimal ());
					e.Add (BruchZuDezimal ());
					e.Add (AddSubMulDivBruch ());
					e.Add (AddSubMulDivBruch ());
                    e.Add(AddSubMulDivBruch());
                    e.Add(AddSubMulDivPotenz());
                    e.Add (AddSubMulDivPotenz ());
					e.Add (AddSubMulDivPotenz ());
					e.Add (Gleichung ());
					e.Add (Gleichung ());
					e.Add (Binom ());
					e.Add (Binom ());
					break;
				case 7:
				case 8:
				case 9:
					//lvl 7-9
					e.Add (AddSubMulDivBruch ());
                    e.Add(AddSubMulDivBruch());
                    e.Add (AddSubMulDivPotenz ());
					e.Add (Gleichung ());
					e.Add (Gleichung ());
					e.Add (Binom ());
					e.Add (Binom ());
					e.Add (Extremwert ());
					e.Add (Extremwert ());
					e.Add (Trigonometrie ());
					e.Add (Trigonometrie ());
					e.Add (Trigonometrie ());
					break;
				case 10:
				case 11:
				case 12:
                    //lvl 10-12
                    e.Add(AddSubMulDivBruch());
                    e.Add (Gleichung ());
					e.Add (Gleichung ());
                    e.Add(Gleichung());
                    e.Add (Binom ());
					e.Add (Binom ());
					e.Add (Extremwert ());
					e.Add (Extremwert ());
                    e.Add(Extremwert());
                    e.Add (Trigonometrie ());
					e.Add (Trigonometrie ());
                    e.Add(Trigonometrie());
                    break;
				default:
					//default lvl
					break;
				}
				break;
			case 2:
                        //typ 2: mini1
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
                        e.Add(Einmaleins('z'));
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

	public Entry Gleichung(){
		GleichungsGen g = new GleichungsGen ();
		return g.GetEntry ();
	}

	public Entry AddSub(char _c){
		string task = "Berechne:";
		string question = "";
		string answer = "";
		if (_c == 'n') {
			//Zahlenraum N
			int a = Random.Range (1, 100000);
			int b = Random.Range (1, 100000);
			int c = a + b;
			if (Random.Range (0, 2) > 0) {
				//Add
				question = a + " + " + b + " = ";
				answer = c + "";
			} else {
				//Sub
				question = c + " - " + b + " = ";
				answer = a + "";
			}
		}
		if (_c == 'z') {
			//Zahlenraum Z
			int a = Random.Range (-100000, 100000);
			int b = Random.Range (-100000, 100000);
			int c = a + b;
			if (Random.Range (0, 2) > 0) {
				//Add
				question = MUtility.SignedInt(a) + " + " + MUtility.SignedInt(b) + " = ";
				answer = c + "";
			} else {
				//Sub
				question = MUtility.SignedInt(c) + " - " + MUtility.SignedInt(b) + " = ";
				answer = a + "";
			}
		}
		if (_c == 'q') {
			//Zahlenraum Q
			task = "Berechne "+round+":";
			float a = MUtility.Round (Random.Range (-10000f, 10000f));
			float b = MUtility.Round (Random.Range (-10000f, 10000f));
			float c = a + b;
			if (Random.Range (0, 2) > 0) {
				//Add
				question = MUtility.SignedFloat(a) + " + " + MUtility.SignedFloat(b) + " = ";
				answer = MUtility.RoundToString(c) + "";
			} else {
				//Sub
				question = MUtility.SignedFloat(c) + " - " + MUtility.SignedFloat(b) + " = ";
				answer = MUtility.RoundToString(a) + "";
			}
		}
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry MulDiv(char _c){
		string task = "Berechne:";
		string question = "";
		string answer = "";
		if (_c == 'n') {
			//Zahlenraum N
			int a = Random.Range (100, 1000);
			int b = Random.Range (2, 13);
			int c = a * b;
			if (Random.Range (0, 2) > 0) {
				//Mul
				question = a + " * " + b + " = ";
				answer = c + "";
			} else {
				//Div
				question = c + " : " + b + " = ";
				answer = a + "";
			}
		}
		if (_c == 'Q') {
			//Zahlenraum Q+
			task = "Berechne " + round + ":";
			if (Random.Range (0, 2) > 0) {
				//Mul
				float a = Random.Range (0.01f, 100.00f);
				float b = Random.Range (0.01f, 100.00f);
                a = MUtility.Round(a);
                b = MUtility.Round(b);
				float c = a * b;
				question = a + " * " + b + " = ";
				answer = MUtility.RoundToString(c) + "";
			} else {
				//Div
				float a = MUtility.Round(Random.Range (0.01f, 100.00f));
                float b = Random.Range(3f, 9f);
                b = (float)System.Math.Round(b,1);
				float c = a * b;
				question = c + " : " + b + " = ";
				answer = MUtility.RoundToString(a) + "";
			}
		}
		if (_c == 'q') {
			//Zahlenraum Q
			task = "Berechne " + round + ":";
			if (Random.Range (0, 2) > 0) {
				//Mul
				float a = Random.Range (-100.00f, 100.00f);
				while (a == 0) { a = Random.Range (-100.00f, 100.00f); }
				float b = Random.Range (-100.00f, 100.00f);
				while (b == 0) { b = Random.Range (-100.00f, 100.00f); }
                a = MUtility.Round(a);
                b = MUtility.Round(b);
				float c = a * b;
				question = MUtility.SignedFloat(a) + " * " + MUtility.SignedFloat(b) + " = ";
				answer = MUtility.RoundToString(c) + "";
			} else {
				//Div
				float a = Random.Range (-100.00f, 100.00f);
                float b = Random.Range(-9f, 9f);
                b = (float)System.Math.Round(b, 1);
                float c = a * b;
				question = MUtility.SignedFloat(c) + " : " + MUtility.SignedFloat(b) + " = ";
				answer = MUtility.RoundToString(a) + "";
			}
		}
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry Einmaleins(char _c){
        string[] answerPos = new string[3];
		string task = "Berechne:";
		string question = "";
		string answer = "";
		int a;
		int b;
		int c;
		if (_c == 'n') {
			a = Random.Range(2,13);
			b = Random.Range(2,13);
			c = a*b;
			if (Random.Range (0, 2) > 0) {
				//Mul
				question = a + " * " + b + " = ";
				answer = c + "";
                answerPos[0] = c+"";
                if (Random.Range(0, 2) > 0)
                {
                    answerPos[1] = (c + Random.Range(1, 10)) + "";
                }
                else {
                    answerPos[1] = (c - Random.Range(1, 10)) + "";
                }
                if (Random.Range(0, 2) > 0)
                {
                    answerPos[2] = (a*(b+1)) + "";
                }
                else
                {
                    answerPos[2] = (a*(b-1)) + "";
                }
            } else {
				//Div
				question = c + " : " + b + " = ";
				answer = a + "";
                answerPos[0] = a + "";
                if (Random.Range(0, 2) > 0)
                {
                    answerPos[1] = (a + Random.Range(1, 10)) + "";
                }
                else
                {
                    answerPos[1] = (a - Random.Range(1, 10)) + "";
                }
                if (Random.Range(0, 2) > 0)
                {
                    answerPos[2] = (a + Random.Range(1, 10)) + "";
                }
                else
                {
                    answerPos[2] = (a - Random.Range(1, 10)) + "";
                }
            }
		}
		if (_c == 'z') {
            task = "Berechne:";
			a = Random.Range(-12,13);
			while (a == 0) {a = Random.Range(-12,13);}
			b = Random.Range(-12,13);
			while (b == 0) {b = Random.Range(-12,13);}
			c = a*b;
			if (Random.Range (0, 2) > 0) {
				//Mul
				question = MUtility.SignedInt(a) + " * " + MUtility.SignedInt(b) + " = ";
				answer = c + "";
                answerPos[0] = c + "";
                if (Random.Range(0, 2) > 0) {
                    answerPos[1] = (-1 * c) + "";
                    answerPos[2] = (c + Random.Range(1, 10))+"";
                } else {
                    answerPos[1] = (-1 * (c + Random.Range(1, 10))) + "";
                    answerPos[2] = (c + Random.Range(1, 10)) + "";
                }
            } else {
				//Div
				question = MUtility.SignedInt(c) + " : " + MUtility.SignedInt(b) + " = ";
				answer = a + "";
                answerPos[0] = a + "";
                if (Random.Range(0, 2) > 0)
                {
                    answerPos[1] = (-1 * a) + "";
                    answerPos[2] = (a + Random.Range(1, 10)) + "";
                }
                else
                {
                    answerPos[1] = (-1 * (a + Random.Range(1, 10))) + "";
                    answerPos[2] = (a+ Random.Range(1, 10)) + "";
                }
            }
		}
		return new Entry (task, question, answer, shuffle(answerPos));
	}

	public Entry Feeling(char _c){
		string task = "Setze das passende (Un-)Gleichungszeichen ein:";
		string question = "";
		string answer = "";
		if (_c == 'z') {
			int a = Random.Range (-1000, 1000);
			int b = Random.Range (-1000, 1000);
			question = a + " ___ " + b;
			if (a < b) {
				answer = "<";
			} else if (a > b) {
				answer = ">";
			} else {
				answer = "=";
			}
		}
		if (_c == 'q') {
			float a = Random.Range (-1000.00f, 1000.00f);
			float b = Random.Range (-1000.00f, 1000.00f);
			question = a + " ___ " + b;
			if (a < b) {
				answer = "<";
			} else if (a > b) {
				answer = ">";
			} else {
				answer = "=";
			}
		}
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry Runden(){
		int x = Random.Range (0, 4);
		int y = Random.Range (6, 10);
		float q = (float)System.Math.Round(Random.Range (0.00000001f, 100.000000001f),y);
		string task = "Runde auf " + x + " Nachkommastellen, auch wenn diese Null sind:";
		string question = q+"";
		string answer = System.Math.Round(q,x) + "";
		//<-- Make sure that the right amount of decimal places is displayed in string (0 at the end gets cut off)
		if (answer.Contains (".")) {
			string[] r = answer.Split ('.');
			int overlap = x - r [r.Length - 1].Length;
			for (int i = 0; i < overlap; i++) {
				answer += 0;
			}
		} else if(x > 0){
			answer += ".";
			for (int i = 0; i < x; i++) {
				answer += 0;
			}
		}
		//-->
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry ErweiternKürzen(){
		if (Random.Range (0, 2) > 0) {
			//Kürzen
			string task = "Kürze soweit wie möglich (gib den Bruch in folgender Form an: Zähler/Nenner)";
			int z = 1;
			int n = 1;
			int teiler = 1;
			while (teiler == 1 || z == n) {
				z = Random.Range (2, 50);
				n = Random.Range (2, 50);
				teiler = GGT (z, n);
			}
			string question = z+"\n--\n"+n;
			string answer = (z/teiler)+"/"+(n/teiler);
			return new Entry (task, question, answer, new string[3]);
		} else {
			//Erweitern
			int faktor = Random.Range(3,12);
			string task = "Erweitere untenstehenden Bruch um den Faktor " +faktor+ " (gib den Bruch in folgender Form an: Zähler/Nenner)";
			int z = Random.Range (1, 13);
			int n = Random.Range (1, 13);
			string question = z + "\n--\n" + n;
			string answer = (z * faktor) + "/" + (n * faktor);
			return new Entry (task, question, answer, new string[3]);
		}
	}

	private int GGT(int a, int b){
		int teiler;
		if (a > b) {
			teiler = a;
		} else {
			teiler = b;
		}
		while (a % teiler != 0 || b % teiler != 0 || a < teiler || b < teiler) {
			teiler -= 1;
			if (teiler <= 1) {
				return 1;
			}
		}
		return teiler;
	}

	public Entry Potenzen(){
		int a = Random.Range (2, 8);
		int b = Random.Range (2, 8);
		int c = (int)Mathf.Pow (a, b);
		string task = "Berechne:";
		string question = a + " hoch " + b;
		string answer = c + "";
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry BruchZuDezimal(){
		string task = "Wandle den Bruch in eine Dezimalzahl um " + round + ":";
		int a = Random.Range (1,13);
		int b = Random.Range (1,13);
		string question = a+"\n--\n"+b;
		string answer = MUtility.RoundToString((float)a/(float)b)+"";
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry BruchteilVonZahl(){
		int a = Random.Range (1,13);
		int b = Random.Range (1,13);
		int c = Random.Range (1,100);
		string task = "Berechne " + round + ":";
		string question = a + "/" + b + " von " +c;
		string answer = MUtility.RoundToString(((float)a/(float)b)*(float)c)+"";
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry Maßeinheit(int _mode){
		string task = "Wandle um. Gib die Einheit nicht mit an. " + round + ":";
		string question = "";
		string answer = "";
		string[] array = new string[3];
		string[] gewicht = new string[]{ " Milligramm (mg)", " Gramm (g)", " Kilogramm (kg)", " Tonnen (t)" };//1000
		string[] geld = new string[]{ " Cent", " Euro" };//100
		string[] strecke = new string[]{ " Millimeter (mm)", " Zentimeter (cm)", " Dezimeter (dm)", " Meter (m)" };//10
		string[] liter = new string[]{ " Milliliter (ml)", " Zentiliter (cl)", " Deziliter (dl)", " Liter (l)" };//10
        string[] fläche = new string[] { " Quadratmillimeter (mm2)", " Quadratzentimeter (cm2)", " Quadratdezimeter (dm2)", " Quadratmeter (m2)", };
		string[] hohlmaß = new string[]{ " Kubikmillimeter (mm3)", " Kubikzentimeter (cm3)", " Kubikdezimeter (dm3)", " Kubikmeter (m3)" }; //1000
		string[] zeit = new string[]{ " Sekunden (s)", " Minuten (m)", " Stunden (h)", " Tage (d)" }; //1000,60,60,24,7
        if (_mode == 0)
        {
            //Gewicht, Geld, Länge, Liter -> nur 1er Schritte
            int arr = Random.Range(0, 4);
            if (arr == 0)
            {
                array = gewicht;
            }
            if (arr == 1)
            {
                array = geld;
            }
            if (arr == 2)
            {
                array = strecke;
            }
            if (arr == 3)
            {
                array = liter;
            }
            if (Random.Range(0, 2) > 0)
            {
                //1 Schritt runter
                float a = MUtility.Round(Random.Range(0.1f, 10f));
                int i = Random.Range(1, array.Length);
                string einheitA = array[i];
                string einheitB = array[i - 1];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    answer = "" + MUtility.RoundToString(a * 1000);
                }
                if (arr == 1)
                {
                    answer = "" + MUtility.RoundToString(a * 100);
                }
                if (arr == 2)
                {
                    answer = "" + MUtility.RoundToString(a * 10);
                }
                if (arr == 3)
                {
                    answer = "" + MUtility.RoundToString(a * 10);
                }
            }
            else
            {
                //1 Schritt rauf
                float a = MUtility.Round(Random.Range(100f, 10000f));
                int i = Random.Range(0, array.Length - 1);
                string einheitA = array[i];
                string einheitB = array[i + 1];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    answer = "" + MUtility.RoundToString(a / 1000);
                }
                if (arr == 1)
                {
                    answer = "" + MUtility.RoundToString(a / 100);
                }
                if (arr == 2)
                {
                    answer = "" + MUtility.RoundToString(a / 10);
                }
                if (arr == 3)
                {
                    answer = "" + MUtility.RoundToString(a / 10);
                }
            }
        }
        else if (_mode == 1)
        {
            //Gewicht, Geld, Länge, Liter -> belibige Schritte
            int arr = Random.Range(0, 4);
            if (arr == 0)
            {
                array = gewicht;
            }
            if (arr == 1)
            {
                array = geld;
            }
            if (arr == 2)
            {
                array = strecke;
            }
            if (arr == 3)
            {
                array = liter;
            }
            if (Random.Range(0, 2) > 0)
            {
                //n Schritte runter
                float a = MUtility.Round(Random.Range(0.1f, 10f));
                int i = Random.Range(1, array.Length);
                int j = Random.Range(1, array.Length);
                while (i - j < 0)
                {
                    j = Random.Range(1, array.Length);
                }
                string einheitA = array[i];
                string einheitB = array[i - j];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a *= 1000;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 1)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a *= 100;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 2)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a *= 10;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 3)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a *= 10;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
            }
            else
            {
                //n Schritte rauf
                float a = MUtility.Round(Random.Range(100f, 10000f));
                int i = Random.Range(0, array.Length - 1);
                int j = Random.Range(1, array.Length);
                while (i + j >= array.Length)
                {
                    j = Random.Range(1, array.Length);
                }
                string einheitA = array[i];
                string einheitB = array[i + j];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a /= 1000;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 1)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a /= 100;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 2)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a /= 10;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 3)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a /= 10;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
            }
        }
        else if (_mode == 2)
        {
            //Fläche, Hohlmaß
            int arr = Random.Range(0, 2);
            if (arr == 0)
            {
                array = fläche;
            }
            if (arr == 1)
            {
                array = hohlmaß;
            }
            if (Random.Range(0, 2) > 0)
            {
                //n Schritte runter
                float a = MUtility.Round(Random.Range(0.1f, 10f));
                int i = Random.Range(1, array.Length);
                int j = Random.Range(1, 3);
                while (i - j < 0)
                {
                    j = Random.Range(1, array.Length);
                }
                string einheitA = array[i];
                string einheitB = array[i - j];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a *= 100;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 1)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a *= 1000;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
            }
            else
            {
                //1 Schritte rauf
                float a = MUtility.Round(Random.Range(100f, 10000f));
                int i = Random.Range(0, array.Length - 1);
                int j = Random.Range(1, 3);
                while (i + j >= array.Length)
                {
                    j = Random.Range(1, array.Length);
                }
                string einheitA = array[i];
                string einheitB = array[i + j];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a /= 100;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
                if (arr == 1)
                {
                    for (int x = 0; x < j; x++)
                    {
                        a /= 1000;
                    }
                    answer = "" + MUtility.RoundToString(a);
                }
            }
        }
        else if (_mode == 4)
        {
            //Fläche Kubik-> nur 1er Schritte
            int arr = Random.Range(0, 2);
            if (arr == 0)
            {
                array = fläche;
            }
            if (arr == 1)
            {
                array = hohlmaß;
            }
            if (Random.Range(0, 2) > 0)
            {
                //1 Schritt runter
                float a = MUtility.Round(Random.Range(0.1f, 10f));
                int i = Random.Range(1, array.Length);
                string einheitA = array[i];
                string einheitB = array[i - 1];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    answer = "" + MUtility.RoundToString(a * 100);
                }
                if (arr == 1)
                {
                    answer = "" + MUtility.RoundToString(a * 1000);
                }

            }
            else
            {
                //1 Schritt rauf
                float a = MUtility.Round(Random.Range(100f, 10000f));
                int i = Random.Range(0, array.Length - 1);
                string einheitA = array[i];
                string einheitB = array[i + 1];
                question = a + einheitA + " in" + einheitB;
                if (arr == 0)
                {
                    answer = "" + MUtility.RoundToString(a / 100);
                }
                if (arr == 1)
                {
                    answer = "" + MUtility.RoundToString(a / 1000);
                }
            }
        }
        else
        {
            //Zeit
            array = zeit;
            int[] faktoren = new int[] { 60, 60, 24 };
            int min;
            int max;
            int modus;
            float zahl = MUtility.Round(Random.Range(0.1f, 10f));
            int a = Random.Range(0, array.Length); //startindex
            int b = Random.Range(0, array.Length); //endindex
            while (a == b || a - b > 3 || a - b < -2) { b = Random.Range(0, array.Length); }
            if (a < b)
            {
                min = a;
                max = b;
                modus = 0;
            }
            else
            {
                min = b;
                max = a;
                modus = 1;
            }
            int faktor = 1;
            for (int i = 0; i < (max - min); i++)
            {
                faktor *= faktoren[min + i];
            }
            if (modus > 0)
            {
                //n schritte runter
                question = zahl + array[a] + " in" + array[b];
                float ergebnis = (float)zahl * (float)faktor;
                answer = "" + MUtility.RoundToString(ergebnis);
            }
            else
            {
                //n schritte rauf
                question = zahl + array[a] + " in" + array[b];
                float ergebnis = (float)zahl / (float)faktor;
                answer = "" + MUtility.RoundToString(ergebnis);
            }
        }
		return new Entry(task, question, answer, new string[3]);
	}

	public Entry Binom(){
		if (Random.Range (0, 2) > 0) {
			return BinomVorwärts ();
		} else {
			return BinomRückwärts ();
		}
	}

	public Entry BinomVorwärts(){
		string task = "Löse auf:";
		string question = "";
		string answer = "";
		int zahl = Random.Range (1, 13);
		int art = Random.Range (0, 3);
		if (art == 0) {
			question = "(x + "+zahl+")^2";
			answer = "x^2 + " + 2 * zahl + "x + " + (zahl * zahl);
		}else if(art == 1){
			question = "(x - "+zahl+")^2";
			answer = "x^2 - " + 2 * zahl + "x + " + (zahl * zahl);
		}else{
			question = "(x + "+zahl+") * (x - "+zahl+")";
			answer = "x^2 - " + (zahl * zahl); 
		}
		return new Entry (task, question, answer, new string[3]);
	}
	public Entry BinomRückwärts(){
		string task = "Bilde ein Binom aus:";
		string question = "";
		string answer = "";
		int zahl = Random.Range (1, 13);
		int art = Random.Range (0, 7);
		if (art == 0 || art == 1 || art == 2) {
			answer = "(x + "+zahl+")^2";
			question = "x^2 + " + 2 * zahl + "x + " + (zahl * zahl);
		}else if(art == 3 || art == 4 || art == 5)
        {
			answer = "(x - "+zahl+")^2";
			question = "x^2 - " + 2 * zahl + "x + " + (zahl * zahl);
		}else{
			answer = "(x + "+zahl+") * (x - "+zahl+")";
			question = "x^2 - " + (zahl * zahl); 
		}
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry Trigonometrie(){
		int mode = Random.Range (0, 3);
		if (mode == 0) {
			return DreieckSeitenlänge ();
		} else if (mode == 1) {
			return DreieckWinkel ();
		} else {
			return DreieckSeiteWinkel ();
		}
	}

	public Entry DreieckSeitenlänge(){
		string task = "Kann es ein Dreieck geben, mit: (ja/nein)";
		int a = Random.Range (1, 13);
		int b = Random.Range (1, 13);
		int c = Random.Range (1, 13);
		string question = "a = "+ a +" cm\nb = "+b+" cm\nc = "+ c + " cm";
		string answer = "nein";
		if (a > b && a > c) {
			if (a < (b + c)) {
				answer = "ja";
			}
		} else if (b > a && b > c) {
			if (b < (a + c)) {
				answer = "ja";
			}
		} else if (c > a && c > b) {
			if (c < (b + a)) {
				answer = "ja";
			}
		} else {
			answer = "ja";
			return new Entry (task, question, answer, new string[3]);
		}
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry DreieckWinkel(){
		string task = "Berechne den fehlenden Winkel:";
		int a = Random.Range (1, 90);
		int b = Random.Range (1, 90);
		string question = "alpha = " + a + " Grad\nbeta = "+ b + " Grad";
		string answer = ""+ (180 - (a + b));
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry DreieckSeiteWinkel(){
		string task = "Kann es ein Dreieck geben mit: (ja/nein)";
		float a = MUtility.Round(Random.Range (0.5f, 5f));
		float b = MUtility.Round(Random.Range (0.5f, 5f));
		float c = MUtility.Round(Random.Range (0.5f, 5f));
		int w = Random.Range (90, 179);
		string winkel;
		string question;
		string answer = "nein";
		int art = Random.Range (0, 3);
		if (art == 0) {
			winkel = "alpha = "+ w+" Grad";
			question = "a = "+ a + " cm\n" + "b = "+ b + " cm\n" + "c = "+ c + " cm\n"+ winkel;
			if (a > b && a > c && a < (b + c)) {
				answer = "ja";
			}
		} else if (art == 1) {
			winkel = "beta = "+ w+" Grad";
			question = "a = "+ a + " cm\n" + "b = "+ b + " cm\n" + "c = "+ c + " cm\n"+ winkel;
			if(b>a && b>c && b < (a+c)) {
				answer = "ja";
			}
		} else {
			winkel = "gamma = "+ w+" Grad";
			question = "a = "+ a + " cm\n" + "b = "+ b + " cm\n" + "c = "+ c + " cm\n"+ winkel;
			if(c>b && c>a && c < (b+a)) {
				answer = "ja";
			}
		}
		return new Entry (task, question, answer, new string[3]);
	}
		
	public Entry AddSubMulDivBruch(){
		int mode = Random.Range (0, 4);
		switch (mode) {
		case 0:
			return AddBruch ();
		case 1:
			return SubBruch ();
		case 2:
			return MulBruch ();
		case 3:
			return DivBruch ();
		default:
			return AddBruch ();
		}
	}

	public Entry MulBruch(){
		int z1 = Random.Range (1, 13);
		int z2 = Random.Range (1, 13);
		int n1 = Random.Range (1, 13);
		int n2 = Random.Range (1, 13);
		string task = "Berechne (Gib den Ergebnisbruch soweit gekürzt wie möglich in folgender Form an: Zähler/Nenner):";
		string question = " "+z1 + "      " + z2+ "\n--- * --- =\n "+n1 + "      "+n2;
		int neuZ = z1 * z2;
		int neuN  = n1 * n2;
		int teiler = GGT (neuZ, neuN);
		neuZ /= teiler;
		neuN /= teiler;
		string answer = neuZ + "/" + neuN;
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry DivBruch(){
		int z1 = Random.Range (1, 13);
		int z2 = Random.Range (1, 13);
		int n1 = Random.Range (1, 13);
		int n2 = Random.Range (1, 13);
		string task = "Berechne (Gib den Ergebnisbruch soweit gekürzt wie möglich in folgender Form an: Zähler/Nenner):";
		string question = " "+z1 + "      " + z2+ "\n--- + --- =\n "+n1 + "      "+n2;
		int neuZ = z1 * n2;
		int neuN  = n1 * z2;
		int teiler = GGT (neuZ, neuN);
		neuZ /= teiler;
		neuN /= teiler;
		string answer = neuZ + "/" + neuN;
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry SubBruch(){
		int z1 = Random.Range (1, 13);
		int z2 = Random.Range (1, 13);
		int n1 = Random.Range (1, 13);
		int n2 = Random.Range (1, 13);
		string task = "Berechne (Gib den Ergebnisbruch soweit gekürzt wie möglich in folgender Form an: Zähler/Nenner):";
		string question = " "+z1 + "      " + z2+ "\n--- - --- =\n "+n1 + "      "+n2;
		int neuZ = (z1 * n2) - (z2 * n1);
		int neuN  = n1 * n2;
		int teiler = GGT (neuZ, neuN);
		neuZ /= teiler;
		neuN /= teiler;
		string answer = neuZ + "/" + neuN;
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry AddBruch(){
		int z1 = Random.Range (1, 13);
		int z2 = Random.Range (1, 13);
		int n1 = Random.Range (1, 13);
		int n2 = Random.Range (1, 13);
		string task = "Berechne (Gib den Ergebnisbruch soweit gekürzt wie möglich in folgender Form an: Zähler/Nenner):";
		string question = " "+z1 + "      " + z2+ "\n--- + --- =\n "+n1 + "      "+n2;
		int neuZ = (z1 * n2) + (z2 * n1);
		int neuN  = n1 * n2;
		int teiler = GGT (neuZ, neuN);
		neuZ /= teiler;
		neuN /= teiler;
		string answer = neuZ + "/" + neuN;
		return new Entry (task, question, answer, new string[3]);
	}
		
	public Entry AddSubMulDivPotenz(){
		int mode = Random.Range (0, 2);
		switch (mode) {
		case 0:
			return MulPotenz ();
		case 1:
			return DivPotenz ();
		default:
			return MulPotenz ();
		}
	}

	public Entry MulPotenz(){
		string task = potenzTask;
		int b1 = Random.Range (1, 7);
		int e1 = Random.Range (1, 7);
		int b2 = Random.Range (1, 7);
		int e2 = Random.Range (1, 7);
		string question = "";
		string answer = "";
		if (Random.Range (0, 2) > 0) {
			question = "x^" + e1 + " * " + "x^" + e2;
			answer = "x^" + (e1 + e2);
		} else {
            while (b1 == b2) {
                b2 = Random.Range(1, 7);
            }
			question = b1+"^" + e1 + " * " + b2+"^" + e1;
			answer = (b1*b2)+"^" + e1;
		}
		return new Entry (task, question, answer, new string[3]);
	}

	public Entry DivPotenz(){
		string task = potenzTask;
		int b1 = Random.Range (1, 7);
		int e1 = Random.Range (1, 7);
		int b2 = Random.Range (1, 7);
		int e2 = Random.Range (1, 7);
		int bTeilbar = b1 * b2;
		string question = "";
		string answer = "";
		if (Random.Range (0, 2) > 0) {
			question = "x^" + e1 + " : " + "x^" + e2;
			answer = "x^" + (e1 - e2);
		} else {
			question = bTeilbar+"^" + e1 + " : " + b2+"^" + e1;
			answer = b1+"^" + e1;
		}
		return new Entry (task, question, answer, new string[3]);
	}
		
	public Entry Extremwert(){
		string task = "Berechne die Extremwerte (Gib das Ergebnis in folgender Form an: T(min/max)=Ys für x=Xs):";
		int[] scheitel = new int[2];//0 = xs, 1 = ys
		scheitel [0] = Random.Range (-19, 20);
		scheitel [1] = Random.Range (-19, 20);
		float a = (float)System.Math.Round(Random.Range (-2f,2f),1);//pos -> min, neg-> max
		while (a == 0f){a = MUtility.Round(Random.Range (-2f,2f));}
		string question;
		if(a*scheitel[0]<0){
			if ((a * (scheitel [0] * scheitel [0]) + scheitel [1]) < 0) {
				question = a + "x^2 + " + MUtility.Betrag((2 * a * scheitel [0])) + "x - " + MUtility.Betrag((a * (scheitel [0] * scheitel [0]) + scheitel [1]));
			} else {
				question = a + "x^2 + " + MUtility.Betrag((2 * a * scheitel [0])) + "x + " + (a * (scheitel [0] * scheitel [0]) + scheitel [1]);
			}
		} else{
			if ((a * (scheitel [0] * scheitel [0]) + scheitel [1]) < 0) {
				question = a + "x^2 - " + MUtility.Betrag((2 * a * scheitel [0])) + "x - " + MUtility.Betrag((a * (scheitel [0] * scheitel [0]) + scheitel [1]));
			} else {
				question = a + "x^2 - " + MUtility.Betrag((2 * a * scheitel [0])) + "x + " + (a * (scheitel [0] * scheitel [0]) + scheitel [1]);
			}
		}
		//question += "\n(Generiert aus: y = " + a + " * (x - " + scheitel [0] + ")^2 + " + scheitel [1]+" )";
		//minus und minus gibt plus!!
		//a neg max
		string answer;
		if (a > 0) {
			answer = "T(min)=";
		} else {
			answer = "T(max)=";
		}
		answer += scheitel[1]+" für x="+ scheitel[0];
		return new Entry (task, question, answer, new string[3]);
	}

    string[] shuffle(string[] arr) {
        //Knuth shuffle algorithm
        for (int i = 0; i < arr.Length; i++) {
            string tmp = arr[i];
            int r = Random.Range(i, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
        return arr;
    }

}
