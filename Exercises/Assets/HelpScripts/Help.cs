using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Help : MonoBehaviour {

	RectTransform m;
	RectTransform e;
	Text text;

	public void Start(){
		GameObject math = GameObject.Find ("Image_Math");
		m = (RectTransform)math.transform;
		GameObject english = GameObject.Find ("Image_English");
		e = (RectTransform)english.transform;
		text = (Text)GameObject.Find ("Button_Switch").GetComponentInChildren<Text> ();
	}

	public void Close(){
		//current.hero.scene
		SceneManager.LoadScene ("Gleichung Test");
	}
	public void Switch(){
		if (m.localScale.x == 0) {
			m.localScale.Scale (new Vector3 (1, 1, 1));
			e.localScale.Scale (new Vector3 (0, 0, 1));
			text.text = "zu Englisch wechseln";
		} else {
			m.localScale.Scale (new Vector3 (0, 0, 1));
			e.localScale.Scale (new Vector3 (1, 1, 1));
			text.text = "zu Mathe wechseln";

		}
	}
}
