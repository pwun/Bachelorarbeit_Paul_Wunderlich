using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MUtility {

	//Rounds every Result to 2 decimals
	public static float Round(float i){
		return (float)System.Math.Round(i, 2);
	}

	public static string RoundToString(float i){
        double a = System.Math.Round(i, 2);
        string result = a + "";
		if (result.Contains (".")) {
			string[] r = result.Split ('.');
			if (r [r.Length - 1].Length == 1) {
				result += "0";
			}
		} else {
			result += ".00";
		}
		return result;
	}

	public static string SignedInt(int _nr){
		if (_nr <= 0) {
			return "( " + _nr + " )";
		} else {
			return "( +" + _nr+" )";
		}
	}

	public static string SignedFloat(float _nr){
		if (_nr <= 0) {
			return "( " + _nr + " )";
		} else {
			return "( +" + _nr+" )";
		}
	}

	public static float Betrag(float _x){
		if (_x < 0) {
			_x *= -1;
		}
		return _x;
	}
}
