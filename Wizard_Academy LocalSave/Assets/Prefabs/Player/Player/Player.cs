using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	GameObject go;
	Animator anim;
    public AudioSource Audio_Cloth;

	// Use this for initialization
	void Start () {
		go = GetComponent<GameObject> ();
		anim = GetComponent<Animator> ();
		Refresh();
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
            case "Pause":
                anim.enabled = false;
                break;
            case "Continue":
                anim.enabled = true;
                break;
		}
	}

    public void Refresh(){
		SetAppearance("Body",Game.current.hero.Body);
		SetAppearance("Pants", Game.current.hero.Legs);
		SetAppearance("Feet", Game.current.hero.Feet);
		SetAppearance("Torso", Game.current.hero.Torso);
		SetAppearance("Hair", Game.current.hero.Hair);
		SetAppearance("Weapon", Game.current.hero.Weapon);
		SetAppearance("Arms", Game.current.hero.Arms);
		SetAppearance("Hands", Game.current.hero.Hands);
		SetAppearance("Helmet", Game.current.hero.Helmet);
		SetAppearance("Belt", Game.current.hero.Belt);
	}

	public void SetAppearance(string ArmorPart, int id){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wearables_"+ArmorPart)) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
		}
        GameObject.Find("Player_" + ArmorPart + "_" + id).GetComponent<SpriteRenderer>().enabled = true;
    }
}
