using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	GameObject go;
	Animator anim;
    public AudioSource Audio_Cloth;

	// Use this for initialization
	void Start () {
		go = GameObject.Find("Player");
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
            case "StopWalking":
                anim.SetBool("Idle", true);
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
        setColor();
	}

    public void setColor() {
        Color c = Color.white;
        switch (Game.current.hero.color) {
            case 1: c = new Color(0.75f,1f,1f);break;
            case 2: c = new Color(0.75f, 0.75f, 1f); break;
            case 3: c = new Color(1f, 0.75f, 1f); break;
            case 4: c = new Color(1f, 0.75f, 0.75f); break;
            case 5: c = new Color(1f, 1f, 0.75f); break;
            case 6: c = new Color(0.75f, 0.75f, 0.75f); break;
            case 7: c = new Color(1f, 0.5f, 0.75f); break;
            case 8: c = new Color(0.75f, 0.5f, 1f); break;
            case 9: c = new Color(0.5f, 0.75f, 1f); break;
            case 10: c = new Color(1f, 0.75f, 0.5f); break;
            case 11: c = new Color(0.5f, 0.5f, 0.5f); break;
            case 12: c = new Color(0.25f, 0.25f, 0.25f); break;
        }
        foreach (SpriteRenderer s in go.GetComponentsInChildren<SpriteRenderer>())
        {
            s.color = c;
        }
        GameObject.Find("Player_Body_1").GetComponent<SpriteRenderer>().color = Color.white;
        GameObject.Find("Player_Hair_1").GetComponent<SpriteRenderer>().color = Color.white;
    }

	public void SetAppearance(string ArmorPart, int id){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wearables_"+ArmorPart)) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
		}
        GameObject.Find("Player_" + ArmorPart + "_" + id).GetComponent<SpriteRenderer>().enabled = true;
    }
}
