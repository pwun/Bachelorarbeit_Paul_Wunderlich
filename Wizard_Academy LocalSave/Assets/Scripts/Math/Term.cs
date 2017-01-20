public class Term {

	float startX2;
	float startX;
	float start;
	float startF;
	float[] term;

	public Term(float _x2, float _x, float _z, float _f){
		startX2 = _x2;
		startX = _x;
		start = _z;
		startF = _f;
		term = new float[]{_x2, _x, _z, _f};
	}
	public void Add(int _pos, float _amount){
		term [_pos] += _amount;
	}
	public void Multiply(float _amount){
		term [0] *= _amount;
		term [1] *= _amount;
		term [2] *= _amount;
	}
	public void Faktor(float _amount){
		term [0] /= _amount;
		term [1] /= _amount;
		term [2] /= _amount;
		term [3] = _amount;
	}
	public override string ToString ()
	{
		string print0 = "";
		string print1 = "";
		string print2 = "";
		string rz1 = "";
		string rz2 = "";
		if (term [0] != 0f) {
			if (term [0] == 1f) {
				print0 = "x^2";
			} else {
				print0 = term [0] + "x^2";
			}
		}
		if (term [1] != 0f) {
			if (term [1] == 1f) {
				print1 = "x";
			} else {
				print1 = term [1] + "x";
			}
		}
		if (term [2] != 0f) {
			print2 =  term [2] + "";
		}
		if (term [0] != 0 && term [1] != 0) {
			rz1 = " + ";
		}
		if(term [1] != 0 && term [2] != 0) {
			rz2 = " + ";
		}
		else if(term [0] != 0 && term [2] != 0){
			rz2 = " + ";
		}
		if (term [3] != 1f) {
			return term [3] + "(" + print0 +rz1+ print1 +rz2+ print2 + ")";
		} else {
			return print0 +rz1+ print1 +rz2+ print2;
		}
	}
}
