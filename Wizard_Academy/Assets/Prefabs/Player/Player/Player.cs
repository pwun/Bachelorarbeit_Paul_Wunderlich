using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameObject go;
	Animator anim;

	public int sex, body = 1, hair = 1, legs = 1, feet = 1, torso = 0, arms = 0, hands = 0, helmet = 0, weapon = 1, belt = 0;
	public int maxSex = 1, maxBody = 2, maxHair = 1, maxLegs = 2, maxFeet = 1, maxTorso = 5, maxArms = 2,maxHands = 1, maxHelmet = 6, maxWeapon = 1, maxBelt = 2;
	public int minSex=1, minBody=1, minHair=1, minLegs=1,minFeet=1,minTorso=0,minArms=1,minHands=1,minHelmet=1,minWeapon=1,minBelt=1;

	UserData data;

	// Use this for initialization
	void Start () {
		go = GetComponent<GameObject> ();
		anim = GetComponent<Animator> ();
		data = GameObject.Find ("User_Data").GetComponent<UserData> ();
		Init ();
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
				anim.SetBool("Idle", false);
				break;
		}
	}

	public void Init(){
		body = data.body;
		legs = data.legs;
		feet = data.feet;
		torso = data.torso;
		hair = data.hair;
		weapon = data.weapon;
		arms = data.arms;
		hands = data.hands;
		helmet = data.helmet;
		belt = data.belt;
	}

	public void Refresh(){
		SetAppearance("Body",body,minBody, maxBody);
		SetAppearance("Pants",legs,minLegs, maxLegs);
		SetAppearance("Feet",feet,minFeet, maxFeet);
		SetAppearance("Torso",torso,minTorso, maxTorso);
		SetAppearance("Hair",hair,minHair, maxHair);
		SetAppearance("Weapon",weapon,minWeapon, maxWeapon);
		SetAppearance("Arms",arms,minArms, maxArms);
		SetAppearance("Hands",hands,minHands, maxHands);
		SetAppearance("Helmet",helmet,minHelmet, maxHelmet);
		SetAppearance("Belt",belt,minBelt, maxBelt);
	}

	public void SetAppearance(string ArmorPart, int id,int min, int max){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wearables_"+ArmorPart)) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if(id>=min&&id<=max)GameObject.Find ("Player_"+ArmorPart+"_"+id).GetComponent<SpriteRenderer> ().enabled = true;
	}
}
