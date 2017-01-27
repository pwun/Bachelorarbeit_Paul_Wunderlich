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
        int[,] colors = new int[,] { {255,255,255},
        { 0,255,0},{ 0,255,128},{ 128,255,0},{ 255,255,0},
        { 255,0,255},{ 255,0,128},{ 255,0,0},{ 255,128,0},
        { 128,0,255},{ 0,0,255},{ 0,128,255},{ 0,255,255}
        };
        c = new Color(colors[Game.current.hero.color, 0] / 255f, colors[Game.current.hero.color, 1] / 255f, colors[Game.current.hero.color, 2] / 255f);
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
