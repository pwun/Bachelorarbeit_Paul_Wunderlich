using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameObject go;
	Animator anim;

	public int sex, body, hair, legs, torso, arms, helmet = 0;

	// Use this for initialization
	void Start () {
		go = GetComponent<GameObject> ();
		anim = GetComponent<Animator> ();
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
		SetAppearance("Body",body);
		SetAppearance("Pants",legs);
	}

	public void SetAppearance(string ArmorPart, int id){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wearables_"+ArmorPart)) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
		}
		GameObject.Find ("Player_"+ArmorPart+"_"+id).GetComponent<SpriteRenderer> ().enabled = true;
	}
}
