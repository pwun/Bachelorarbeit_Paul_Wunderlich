using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomizerUI : MonoBehaviour {

	Player player;

	public int sex, body, hair, feet, legs, torso, arms, helmet = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();

		GameObject.Find ("Walk").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Walk"));
		GameObject.Find ("Attack").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Attack"));
		GameObject.Find ("Hurt").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Hurt"));
		GameObject.Find ("Die").GetComponent<Button> ().onClick.AddListener (() => player.Do ("Die"));

		GameObject.Find ("Refresh").GetComponent<Button> ().onClick.AddListener (() => refresh());
	}
	
	void refresh(){
		player.refresh ();
	}
}
