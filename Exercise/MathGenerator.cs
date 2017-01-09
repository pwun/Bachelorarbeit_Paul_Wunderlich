public class MathGenerator(){
  public MathGenerator(){}

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
    Entries.Add(Grundrechenarten1Mixed());
    //...Add Other Entries
  }
//Testing only
	public Entry Generate(string _methodName){
		if (this.GetType ().GetMethod (_methodName) != null) {
			MethodInfo mi = this.GetType ().GetMethod (_methodName);
			return (Entry)mi.Invoke (this, null);
		} else {
			return Fallback ();
		}
	}
	//fallback entry in case a method isn't found by name
	private Entry Fallback(){
		int a = Random.Range (0, 10);
		int b = Random.Range (0, 10);
		int c = Random.Range (0, 10);
		string question = a + "+" + b + "*" + c + "=";
		string answer = a + b * c + "";
		return new Entry (question, answer, "Berechne als Ganzzahl:");
	}
//!Testing only

	//Grundrechenarten
	public Entry Grundrechenarten1Mixed(){
		int a = Random.Range (-50, 50);
		int b = Random.Range (-50, 50);
		int vz = Random.Range (0, 2);
		string question;
		string answer;
		if (vz > 0) {
			question = "("+ getSignedInt(a) + ") + (" + getSignedInt(b) + ") =";
			answer = a + b + "";
		} else {
			question = "("+ getSignedInt(a) + ") - (" + getSignedInt(b) + ") =";
			answer = a - b + "";
		}
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten1MixedPos(){
		int a = Random.Range (1, 10000);
		int b = Random.Range (1, 10000);
		int vz = Random.Range (0, 2);
		string question;
		string answer;
		if (vz > 0) {
			question = a + " + " + b + " =";
			answer = a + b + "";
		} else {
			question = a + " - " + b + " =";
			answer = a - b + "";
		}
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten1Addition(){
		int a = Random.Range (-50, 50);
		int b = Random.Range (-50, 50);
		int vz = Random.Range (0, 2);
		string question = "("+ getSignedInt(a) + ") + (" + getSignedInt(b) + ") =";
		string answer = a + b + "";
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten1Subtraktion(){
		int a = Random.Range (-50, 50);
		int b = Random.Range (-50, 50);
		int vz = Random.Range (0, 2);
		string question = "("+ getSignedInt(a) + ") - (" + getSignedInt(b) + ") =";
		string answer = a - b + "";
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten2Mixed(){
		int a = Random.Range (-13, 13);
		int b = Random.Range (-13, 13);
		// !!! a & b != 0
		int vz = Random.Range (0, 2);
		string question;
		string answer;
		if (vz > 0) {
			question = "("+ getSignedInt(a) + ") * (" + getSignedInt(b) + ") =";
			answer = a * b + "";
		} else {
			int c = a * b;
			question = "("+ getSignedInt(c) + ") : (" + getSignedInt(b) + ") =";
			answer = a + "";
		}
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten2MixedPos(){
		int a = Random.Range (1, 100);
		int b = Random.Range (1, 50);
		int vz = Random.Range (0, 2);
		string question;
		string answer;
		if (vz > 0) {
			question = a + " * " + b + " =";
			answer = a * b + "";
		} else {
			int c = a * b;
			question = c + " : " + b + " =";
			answer = a + "";
		}
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten2Multiplikation(){
		int a = Random.Range (-13, 13);
		int b = Random.Range (-13, 13);
		// !!! a & b != 0
		string question = "("+ getSignedInt(a) + ") * (" + getSignedInt(b) + ") =";
		string answer = a * b + "";
		return new Entry (question, answer, "Berechne:");
	}

	public Entry Grundrechenarten2Division(){
		int a = Random.Range (-13, 13);
		int b = Random.Range (-13, 13);
		// !!! a & b != 0
		int c = a * b;
		string question = "("+ getSignedInt(c) + ") : (" + getSignedInt(b) + ") =";
		string answer = a * b + "";
		return new Entry (question, answer, "Berechne:");
	}

	//Runden
	public Entry Round(float _a, float _b, int _c){
		float i = Random.Range (_a, _b);
		return new Entry ("Runde "+ i + " auf "+ _c + " Nachkommastellen", "" + (float)System.Math.Round(i,_c), "");
		//bei .00 nicht abschneiden
	}

	//Maßeinheiten
	//Gewicht, Längenmaße, Währung, Flächenmaß, Hohlmaße, FlächenHohlmaß gemischt, Volumen, Zeit
	public Entry Umrechnung(float _a, float _b, float _mul, string _e1, string _e2, int _nkst, int _nkstResult){
		float i = (float)System.Math.Round(Random.Range (_a, _b),_nkst);
		return new Entry (i + " " + _e1 + " in " + _e2, (float)System.Math.Round(i * _mul, _nkstResult) + " " + _e2, "Führe die Umrechnung durch");
	}

	//Gleichung Ungleichung
	public Entry Ungleichung1(){
		float a = (float)System.Math.Round(Random.Range (-5.00f, 5.00f),2);
		float b = (float)System.Math.Round(Random.Range (-5.00f, 5.00f),2);
		string question = a + "___" + b;
		string answer;
		if (a == b) {
			answer = "=";
		}
		else if (a < b) {
			answer = "<";
		}
		else answer = ">";
		return new Entry (question, answer, "Füge das richtige Ungleichungszeichen ein (<, >, oder =):");
	}

	//Bruch
	public Entry BruchErweitern(int _min, int _max, int _mulMin, int _mulMax){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_min, _max);
		int mul = Random.Range(_mulMin, _mulMax);

		return new Entry(b+" / "+a +" = " + "x / "+ a*mul, b*mul+"","Erweitere folgenden Bruch auf den vorgegeben Nenner ");
	}

	public Entry BruchKürzen(int _min, int _max, int _mulMin, int _mulMax){
		int a = Random.Range(_min, _max);
		int b = getRandomPrime (0,0);
		int mul = Random.Range(_mulMin, _mulMax);
		//Bruch darf nicht weiter kürzbar sein!
		return new Entry(a*mul+" / "+b*mul, a+" / "+b+"","Kürze soweit wie möglich");
		//evtl mit gegebenem bruch anfangen, kgv berechnen
	}

	public Entry BruchAddierenAlsDezimalzahl(int _min, int _max){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_min, _max);
		int c = Random.Range(_min, _max);
		int d = Random.Range(_min, _max);
		return new Entry (a + " / "+ b + " + " + c + " / " + d, ""+((float)a/(float)b+(float)c/(float)d), "Berechne als Dezimalzahl");
	}

	public Entry BruchSubtrahierenAlsDezimalzahl(int _min, int _max){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_min, _max);
		int c = Random.Range(_min, _max);
		int d = Random.Range(_min, _max);
		return new Entry (a + " / "+ b + " - " + c + " / " + d, ""+((float)a/(float)b-(float)c/(float)d), "Berechne als Dezimalzahl");
	}

	public Entry BruchMultiplizierenAlsDezimalzahl(int _min, int _max){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_min, _max);
		int c = Random.Range(_min, _max);
		int d = Random.Range(_min, _max);
		return new Entry (a + " / "+ b + " * " + c + " / " + d, ""+((float)a/(float)b)*((float)c/(float)d), "Berechne als Dezimalzahl");
	}

	public Entry BruchDividierenAlsDezimalzahl(int _min, int _max){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_min, _max);
		int c = Random.Range(_min, _max);
		int d = Random.Range(_min, _max);
		return new Entry (a + " / "+ b + " : " + c + " / " + d, ""+((float)a/(float)b)/((float)c/(float)d), "Berechne als Dezimalzahl");
	}

	//Potenz
	public Entry Potenz(int _min, int _max, int _minPot, int _maxPot){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_minPot, _maxPot);
		// while a ^ b > 1000 a = new Random, b = new Random
		return new Entry (a + " hoch " + b, System.Math.Pow (a, b)+"", "Berechne");
	}

	public Entry PotenzMultiplizierenMitGleicherBasis(int _min, int _max, int _minPot, int _maxPot){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_minPot, _maxPot);
		int c = Random.Range(_minPot, _maxPot);
		// while a ^ b > 1000 a = new Random, b = new Random
		return new Entry (a + "^" + b + " * " + a + "^" + c , a+"^"+(b+c), "Berechne ");
	}

	public Entry PotenzDividierenMitGleicherBasis(int _min, int _max, int _minPot, int _maxPot){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_minPot, _maxPot);
		int c = Random.Range(_minPot, _maxPot);
		// while a ^ b > 1000 a = new Random, b = new Random
		return new Entry (a + "^" + b + " : " + a + "^" + c , a+"^"+(b-c), "Berechne ");
	}

	public Entry PotenzMultiplizierenMitGleichemExponenten(int _min, int _max, int _minPot, int _maxPot){
		int a = Random.Range(_min, _max);
		int b = Random.Range(_min, _max);
		int c = Random.Range(_minPot, _maxPot);
		// while a ^ b > 1000 a = new Random, b = new Random
		return new Entry (a + "^" + c + " * " + b + "^" + c , (a*b)+"^"+c, "Berechne ");
	}

	public Entry PotenzDividierenMitGleichemExponenten(int _min, int _max, int _minPot, int _maxPot){
		int basis2 = Random.Range(_min, _max);
		int a = Random.Range(_min, _max);
		int basis1 = basis2 * a;
		int c = Random.Range(_minPot, _maxPot);
		// while a ^ b > 1000 a = new Random, b = new Random
		return new Entry (basis1 + "^" + c + " : " + basis2 + "^" + c , a+"^"+c, "Berechne ");
	}

	private string getSignedInt(int _nr){
		if (_nr <= 0) {
			return _nr + "";
		} else {
			return "+" + _nr;
		}
	}

	private int getRandomPrime(int _min, int _max){
		//
		return 3;
	}
}
