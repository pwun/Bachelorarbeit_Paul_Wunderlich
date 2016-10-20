using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameObject go;
	Animator anim;

	public int sex, body = 1, hair = 1, legs = 1, feet = 1, torso = 0, arms = 0, hands = 0, helmet = 0, weapon = 1, belt = 0;

	// Use this for initialization
	void Start () {
		go = GetComponent<GameObject> ();
		anim = GetComponent<Animator> ();
		refresh ();
		SetAppearance ("Torso", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Do(string action){
		switch (action) {
			case "Attack":
			case "Hurt":
			case "Die":
				anim.SetTrigger (action);
				break;
			case "Walk":
				anim.SetBool ("Idle", false);
				break;
		}
	}

	public void refresh(){
		if(body!=0)SetAppearance("Body",body);
		if(legs!=0)SetAppearance("Pants",legs);
		if(feet!=0)SetAppearance("Feet",feet);
		if(torso!=0)SetAppearance("Torso",torso);
		if(hair!=0)SetAppearance("Hair",hair);
		if(weapon!=0)SetAppearance("Weapon",weapon);
		if(arms!=0)SetAppearance("Arms",arms);
		if(hands!=0)SetAppearance("Hands",hands);
		if(weapon!=0)SetAppearance("Weapon", weapon);
		if (helmet!=0)SetAppearance("Helmet",helmet);
		if (belt!=0)SetAppearance("Belt",belt);
	}

	public void SetAppearance(string ArmorPart, int id){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wearables_"+ArmorPart)) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
		}
		GameObject.Find ("Player_"+ArmorPart+"_"+id).GetComponent<SpriteRenderer> ().enabled = true;
	}
}
